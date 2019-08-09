using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class FilterDto : PaginationFiltersDto
    {

        public FilterDto() : base() { }

        public string CdGrupo { set; get; }
        public string CdCliente { set; get; }
    }
    //public class DownloadablePaginationFiltersDto : PaginationFiltersDto
    //{
    //    public DownloadablePaginationFiltersDto() { }
        
    //    public bool Download { get; set; }
    //    public PaginationSettingsDto PaginationSettings { get; set; }
    //}
    public class PaginationSettingsDto
    {
        public PaginationSettingsDto() {
            PageIndex = 0;
            PageSize = 1000;
        }

        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public SortSettingsDto SortSettings { get; set; }
    }
    public class SortSettingsDto
    {
        public SortSettingsDto() {
            Direction = SortDirection.Desc;
        }
        public string OrderBy { get; set; }
        public SortDirection? Direction { get; set; }
    }
    public enum SortDirection
    {
        Asc = 0,
        Desc = 1
    }
    public class PaginationFiltersDto
    {
        public PaginationFiltersDto() { }

        public string SearchTerm { get; set; }
        public PaginationSettingsDto PaginationSettings { get; set; }
    }
}
