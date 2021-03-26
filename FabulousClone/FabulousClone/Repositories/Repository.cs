using FabulousClone.IRepositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FabulousClone.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public SQLiteAsyncConnection Connection;
        public Repository()
        {
            string filename = "FabulousCloneDatabase.db3";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
            Connection = new SQLiteAsyncConnection(path);

            //Migrate databases
            Connection.CreateTableAsync<T>();
        }

        public async Task<T> FindById(object id) 
        {
            try
            {
                return await Connection.FindAsync<T>(id);
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        public async Task<List<T>> Get()
        {
            try
            {
                return await Connection.Table<T>().ToListAsync();
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            try 
            {
                var query = Connection.Table<T>();

                if (predicate != null)
                    query = query.Where(predicate);

                if (orderBy != null)
                    query = query.OrderBy(orderBy);

                return await query.ToListAsync();
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await Connection.FindAsync<T>(predicate);
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }


        public async Task<int> Insert(T entity)
        {
            try
            {
                return await Connection.InsertOrReplaceAsync(entity);
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }


        public async Task<int> Update(T entity)
        {
            try
            {
                return await Connection.UpdateAsync(entity);
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }


        public async Task<int> Delete(T entity)
        {
            try
            {
                return await Connection.DeleteAsync(entity);
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }
        
    }
}
