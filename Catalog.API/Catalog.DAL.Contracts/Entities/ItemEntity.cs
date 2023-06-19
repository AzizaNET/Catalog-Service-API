using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Contracts.Entities
{
    public class ItemEntity
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; } = string.Empty;

        public CategoryEntity Category { get; set; }
    }
}
