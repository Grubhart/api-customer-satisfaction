using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_customer_satisfaction.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        IEnumerable<TEntity> GetAllByDateRange(DateTime begin, DateTime end);
    }
}