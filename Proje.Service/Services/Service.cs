using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Proje.Core.Repositories;
using Proje.Core.Services;
using Proje.Core.UnitOfWorks;

namespace Proje.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    { 
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork,IRepository<TEntity> repository)
        {
            _unitOfWork=unitOfWork;
            _repository=repository;
        }


         public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);

            await _unitOfWork.CommitAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);

            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _repository.Update(entity);

            _unitOfWork.Commit();

            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        //--------------------------------------------
        //  public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        // {
            
        // }

        // public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        // {
            
        // }

    }
}