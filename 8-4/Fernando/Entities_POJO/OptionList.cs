using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO_Entities.Entities
{
    public class OptionList : BaseEntity
    {
        public string ListId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
