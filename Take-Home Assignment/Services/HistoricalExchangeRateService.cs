using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Take_Home_Assignment.Models;
using Take_Home_Assignment.Models.Exceptions;

namespace Take_Home_Assignment.Controllers
{
    public class HistoricalExchangeRateService : IHistoricalExchangeRateService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public HistoricalExchangeRateService(IHttpClientWrapper httpClientWrapper)
        {
            this._httpClientWrapper = httpClientWrapper;
        }

        public async Task<HistoricalExchangeRate> GetHistoricalExchangeRate(DateTime startDate, DateTime endDate,
            string baseCurrency, string targetCurrency)
        {
            History history = await GetHistory(startDate, endDate, baseCurrency, targetCurrency);

            // Flatten out rates
            List<DayRate> dayRates = history.Rates.Select(x => new DayRate
            {
                Date = DateTime.Parse(x.Key),
                Rate = x.Value.Where(target => target.Key == targetCurrency).Select(rate => rate.Value).FirstOrDefault()
            }).OrderBy(x => x.Date).ToList();

            HistoricalExchangeRate historicalExchangeRate = new HistoricalExchangeRate
            {
                MinimumExchangeRate = dayRates.FirstOrDefault(x => x.Rate == dayRates.Min(y => y.Rate)),
                MaximumExchangeRate = dayRates.FirstOrDefault(x => x.Rate == dayRates.Max(y => y.Rate)),
                AverageExchangeRate = dayRates.Average(x => x.Rate),
            };
            return historicalExchangeRate;
        }

        private async Task<History> GetHistory(DateTime startDate, DateTime endDate, string baseCurrency, string targetCurrency)
        {
           string response = await _httpClientWrapper.GetAsync($"https://api.exchangeratesapi.io/history?" +
                                                  $"start_at={startDate:yyyy-MM-dd}" +
                                                  $"&end_at={endDate:yyyy-MM-dd}" +
                                                  $"&symbols={targetCurrency}" +
                                                  $"&base={baseCurrency}");

            History history = await GetResponse<History>(response);
            return history;
        }

        private async Task<T> GetResponse<T>(string responseString)
        {
           
            if (String.IsNullOrEmpty(responseString))
            {
                throw new NotFoundException();
            }

            return JsonConvert.DeserializeObject<T>(responseString);
            // One maybe should handle exceptions from JsonConvert.DeserializeObject
        }

       
    }
}

