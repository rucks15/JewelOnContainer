using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace JewelWebClient.ViewModels
{
    public class PaginationInfo
    {
        public long TotalItems { get; set; }
        public long ItemsPerPage { get; set; }
        public int ActualPage { get; set; }
        public int TotalPages { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}
