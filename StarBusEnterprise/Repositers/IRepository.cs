using StarBusEnterprise.Models;
using System.Collections.Generic;

namespace StarBusEnterprise.Repositers
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int Id);

        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
