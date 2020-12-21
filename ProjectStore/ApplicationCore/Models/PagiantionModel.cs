using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class PaginationModel
    {
        public string searchValue { get; set; } = "";
        public int pageSize { get; set; } = 10;
        public int currentPage { get; set; } = 0;
        public string sort { get; set; }
        public string sortKey { get; set; }
        public string catelogs { get; set; }
        public int fromPrice { get; set; }
        public int toPrice { get; set; }
    }
}