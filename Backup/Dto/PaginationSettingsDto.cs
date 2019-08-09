
namespace Usiminas.PluginExcel.Entitys
{
    public class PaginationSettingsDto
    {

        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public SortSettingsDto SortSettings { get; set; }
    }
}
