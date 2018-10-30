using System;
using System.Threading.Tasks;
using Take_Home_Assignment.Models;

namespace Take_Home_Assignment.Controllers
{
    public interface IHistoricalExchangeRateService
    {
        Task<HistoricalExchangeRate> GetHistoricalExchangeRate(DateTime startDate, DateTime endDate, string baseCurrency, string targetCurrency);
    }
}

