using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Infra.Data.Repositories
{
    


    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //injenção de dependencia
        private readonly SQLServerContext _context;

        public BaseRepository(SQLServerContext context)
        {
            this._context = context;
        }

        public Task<int> Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            return this._context.SaveChangesAsync();
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public async Task<T> FindById(int id) 
        {
            return await this._context.Set<T>().FindAsync(id); //retorna uma value task, por isso usamos o async aqui e nao no Save()
        }

        public Task<int> Save(T entity)
        {
            //esse Set<T> é como se estivessemos colocando o nome da table no banco
            //esse set da certo pq colocamos aquele where T : class
            this._context.Set<T>().Add(entity);
            return this._context.SaveChangesAsync(); //retorna uma task<int>
        }

        public Task<int> Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            return this._context.SaveChangesAsync();
        }
    }
}
