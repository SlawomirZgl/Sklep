using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class PaginationDto
    {
        public string SortColumn { get; set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public bool SortAscending { get; set; }
    }
}
