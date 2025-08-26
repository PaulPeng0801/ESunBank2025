namespace MonthlyRevenueAPI.DTOs
{
    public class MonthlyRevenueReq
    {
        public string? ReportDate { get; set; }
        public string? DataYearMonth { get; set; }
        public string? CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? CurrentMonthRevenue { get; set; }
        public string? PreviousMonthRevenue { get; set; }
        public string? LastYearSameMonthRevenue { get; set; }
        public string? MonthOverMonthChange { get; set; }
        public string? YearOverYearChange { get; set; }
        public string? CurrentCumulativeRevenue { get; set; }
        public string? LastYearCumulativeRevenue { get; set; }
        public string? PriorPeriodChange { get; set; }
        public string? Notes { get; set; }
    }
}
