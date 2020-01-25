using api_customer_satisfaction.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_customer_satisfaction.Models.DataManager
{
    public class EvaluationManager : IDataRepository<Evaluation>
    {
        readonly Context _context;
        public EvaluationManager(Context context)
        {
            _context = context;
        }
        public void Add(Evaluation entity)
        {
            entity.EvaluationDate = DateTime.Now;
            _context.Evaluations.Add(entity);
            _context.SaveChanges();
        }
        public Evaluation GetById(int id)
        {
            return _context.Evaluations.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<Evaluation> GetAll()
        {
            return _context.Evaluations.ToList();
        }
        public IEnumerable<Evaluation> GetAllByDateRange(DateTime begin, DateTime end)
        {
            return _context.Evaluations.Where(f => f.EvaluationDate >= begin && f.EvaluationDate <= end).ToList();
        }
        public void Update(Evaluation evaluation, Evaluation entity)
        {
            evaluation.FirstName = entity.FirstName;
            evaluation.LastName = entity.LastName;
            evaluation.Email = entity.Email;
            evaluation.Qualification = entity.Qualification;
            evaluation.EvaluationDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}