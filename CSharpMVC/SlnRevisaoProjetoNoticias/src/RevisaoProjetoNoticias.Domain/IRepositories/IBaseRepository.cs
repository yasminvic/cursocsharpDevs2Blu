using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.IRepositories
{
    //passando o tipo T, onde T é uma classe
    //quando usar esse IBaseRepository vamos ter que passar uma classe
    public interface IBaseRepository<T> where T: class//pra economizar código
    {
        
        IQueryable<T> FindAll(); //é uma lista de query
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Delete(T entity);

    }
}
