using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Contracts.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; } = string.Empty;

        public CategoryModel Category { get; set; }
    }
}
