using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Contracts;
using Catalog.Domain.Contracts.Models;

namespace Catalog.Domain.Implementations
{
    public class ItemService : IItemService
    {
        public Task<ItemModel> Create(ItemModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ItemModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Update(ItemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
