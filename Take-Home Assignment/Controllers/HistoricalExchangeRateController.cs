using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Take_Home_Assignment.Models;
using Take_Home_Assignment.Models.Exceptions;

namespace Take_Home_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricalExchangeRateController : ControllerBase
    {
        private readonly IHistoricalExchangeRateService _historicalExchangeRateService;

        public HistoricalExchangeRateController(IHistoricalExchangeRateService historicalExchangeRateService)
        {
            this._historicalExchangeRateService = historicalExchangeRateService;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(502)]
        [HttpGet("{startDate}/{endDate}/{baseCurrency}/{targetCurrency}")]
        public async Task<ActionResult<HistoricalExchangeRate>> Get(
            DateTime startDate,
            DateTime endDate,
            string baseCurrency,
            string targetCurrency)
        {
            // TODO
            // Unit tests
            // Versioning
            // Structuring projects and files - Models, Services, Interfaces... 
            // Data structure in History-class maybe should be flattened and more strongly typed.

            if (startDate < new DateTime(1999, 1, 1)
                || startDate > endDate)
            {
                // api.exchangeratesapi.io has historical rates since 1999.
                return StatusCode(StatusCodes.Status400BadRequest , startDate);
            }
            if (!GetCurrencyIsValid(baseCurrency))
            {
                return StatusCode(StatusCodes.Status400BadRequest, baseCurrency);
            }
            if (!GetCurrencyIsValid(targetCurrency)
            || baseCurrency.Equals(targetCurrency, StringComparison.OrdinalIgnoreCase))
            {
                return StatusCode(StatusCodes.Status400BadRequest, targetCurrency);
            }
            

            try
            {
                return await _historicalExchangeRateService.GetHistoricalExchangeRate(
                        startDate,
                        endDate,
                        baseCurrency, 
                        targetCurrency);
            }
            // Exception handling and logging would i normally put in a middleware or base class to keep
            // controllers clean and  to avoid code duplication.
            catch (BadRequestException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (BadGatewayException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool GetCurrencyIsValid(string currency)
        {
            // TODO 
            // Validate currency eg SEK, USD, EUR ...
            // Check format three letters, only one currency ...
            // and maybe put in a "helper class" for re-useability
            return true;
        }

        
    }
}

