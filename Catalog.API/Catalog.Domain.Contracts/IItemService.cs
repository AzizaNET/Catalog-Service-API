using Catalog.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Contracts
{
    public interface IItemService
    {
        Task<ItemModel> Create(ItemModel model);
        IEnumerable<ItemModel> GetAll();

        ItemModel Get(int id);

        Task<Guid> Update(ItemModel model);

        Task Delete(int id);
    }
}
