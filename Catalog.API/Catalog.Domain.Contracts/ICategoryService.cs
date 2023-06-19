using Catalog.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Contracts
{
    public interface ICategoryService
    {
        Task<Guid> Create(CategoryModel category);

        IEnumerable<CategoryModel> GetAll();
        
        CategoryModel Get(Guid id);
        Task<Guid> Update(CategoryModel category);
        Task Delete(Guid id);
    }
}
