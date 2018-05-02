using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bbs.AppTemplate.Models
{
    public class DbContext
    {
        Exception exception;
        public Exception GetException { get { return exception; } }

        SQLiteAsyncConnection ctx;
        bool isInitialized;

        public DbContext(string dbPath)
        {
            ctx = new SQLiteAsyncConnection(dbPath, false);
            isInitialized = false;
        }

        public virtual async Task InitializeDb() { throw new NotImplementedException("This method must be implemented!!!"); }

        public virtual async Task<DbResult> SaveItemAsync<T>(T entity) where T : DbTableService, new()
        {
            exception = null;
            if (entity == null)
            {
                exception = new ArgumentException($"Impossible to insert or update a null object!", nameof(entity));
                return new DbResult(DbActions.Delete, DbResults.Error, null, typeof(T).ToString(), exception.Message);
            }

            var action = DbActions.Undefined;
            var result = DbResults.Undefined;
            try
            {
                int count = 0;
                if (entity.GetID() > 0)
                {
                    action = DbActions.Update;
                    count = await ctx.UpdateAsync(entity);
                }
                else
                {
                    action = DbActions.Insert;
                    count = await ctx.InsertAsync(entity);
                }

                result = count > 0 ? DbResults.Success : DbResults.Fail;
                return new DbResult(action, result, entity.GetID(), typeof(T).ToString(), null);
            }
            catch (SQLiteException ex)
            {
                exception = ex;
                result = DbResults.Error;
                return new DbResult(action, result, entity.GetID(), typeof(T).ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                exception = ex;
                result = DbResults.Error;
                return new DbResult(action, result, entity.GetID(), typeof(T).ToString(), ex.Message);
            }
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync<T>() where T : DbTableService, new()
        {
            exception = null;
            try
            {
                var entities = await ctx.Table<T>().ToListAsync();
                return entities ?? null;
            }
            catch (SQLiteException ex)
            {
                exception = ex;
                return null;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public virtual async Task<T> GetItemAsync<T>(int id) where T : DbTableService, new()
        {
            exception = null;
            if (id <= 0)
            {
                exception = new ArgumentException($"The key must be greater then zero!", nameof(id));
                return null;
            }

            try
            {
                var entity = await ctx.Table<T>().Where(e => e.GetID() == id).FirstOrDefaultAsync();
                return entity ?? null;
            }
            catch (SQLiteException ex)
            {
                exception = ex;
                return null;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public virtual async Task<DbResult> DeleteItemAsync<T>(T entity) where T : DbTableService, new()
        {
            exception = null;
            if (entity == null)
            {
                exception = new ArgumentException($"Impossible to delete a null object!", nameof(entity));
                return new DbResult(DbActions.Delete, DbResults.Error, null, typeof(T).ToString(), exception.Message);
            }

            try
            {
                var count = await ctx.DeleteAsync(entity);
                if (count > 0)
                    return new DbResult(DbActions.Delete, DbResults.Success, null, typeof(T).ToString(), null);
                else
                    return new DbResult(DbActions.Delete, DbResults.Fail, entity.GetID(), typeof(T).ToString(), null);
            }
            catch (SQLiteException ex)
            {
                exception = ex;
                return new DbResult(DbActions.Delete, DbResults.Error, entity.GetID(), typeof(T).ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                exception = ex;
                return new DbResult(DbActions.Delete, DbResults.Error, entity.GetID(), typeof(T).ToString(), ex.Message);
            }
        }
    }
}
