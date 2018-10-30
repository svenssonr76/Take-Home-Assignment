namespace Take_Home_Assignment.Models
{
    public class HistoricalExchangeRate
    {
        public DayRate MinimumExchangeRate { get; set; }
        public DayRate MaximumExchangeRate { get; set; }
        public decimal AverageExchangeRate { get; set; }
    }
}

