# Take-Home-Assignment
API in ASP.NET Core

Clone or download and open in Visual Studio.
Build and run locally with IIS Express option and the url api/HistoricalExchangeRate/2018-01-15/2018-02-12/SEK/NOK will be launced in browser.

https://localhost:44337/api/HistoricalExchangeRate/2018-01-15/2018-02-12/SEK/NOK

Response:
{
   "minimumExchangeRate": {
   "date": "2018-02-02T00:00:00",
   "rate": 0.973936858
   },
   "maximumExchangeRate": {
   "date": "2018-02-09T00:00:00",
   rate": 0.9852686831
   },
   "averageExchangeRate": 0.9788884374904761904761904762
}

API documentation is provided by Swagger UI on the base application url: https://localhost:44337/ 

![Alt text](https://github.com/svenssonr76/Take-Home-Assignment/blob/master/Swagger%20Documentation/Get%20HistoricalExchangeRate.PNG?raw=true "Get HistoricalExchangeRate")
![Alt text](https://github.com/svenssonr76/Take-Home-Assignment/blob/master/Swagger%20Documentation/Response%20HistoricalExchangeRate.PNG?raw=true "Response HistoricalExchangeRate")
![Alt text](https://github.com/svenssonr76/Take-Home-Assignment/blob/master/Swagger%20Documentation/Models%20HistoricalExchangeRate.PNG?raw=true "Models HistoricalExchangeRate")
