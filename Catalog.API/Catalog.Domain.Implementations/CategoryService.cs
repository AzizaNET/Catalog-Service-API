using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.DAL.Contracts;
using Catalog.DAL.Contracts.Entities;
using Catalog.Domain.Contracts;
using Catalog.Domain.Contracts.Models;

namespace Catalog.Domain.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public CategoryService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Create(CategoryModel category)
        {
            var entity = _mapper.Map<CategoryEntity>(category);
            var result = await _dbRepository.Add(entity);

            await _dbRepository.SaveChangesAsync();

            return result;
            
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var collection = _dbRepository.GetAll<CategoryEntity>();
            var result = _mapper.Map<IEnumerable<CategoryModel>>(collection);

            if (result == null || !result.Any())
            {
                return null;
            }
            return result;
        }
        public CategoryModel Get(Guid id)
        {
            var entity = _dbRepository.Get<CategoryEntity>(x => x.Id == id).FirstOrDefault();
            var model = _mapper.Map<CategoryModel>(entity);

            return model;
        }
        public async Task<Guid> Update(CategoryModel category)
        {
            var entity = _mapper.Map<CategoryEntity>(category);
            await _dbRepository.Update(entity);
            await _dbRepository.SaveChangesAsync();

            return entity.Id;
        }
        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<CategoryEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

        
    }
}
