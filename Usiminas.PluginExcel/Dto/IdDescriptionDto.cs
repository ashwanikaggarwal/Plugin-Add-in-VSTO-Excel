using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Dto
{
    public class IdDescriptionDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IdDescriptionDto(string id, string description)
        {
            Id = id;
            Description = description;
        }
        public IdDescriptionDto(){}
    }
}
