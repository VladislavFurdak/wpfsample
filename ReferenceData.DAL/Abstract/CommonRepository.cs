using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.DAL
{
    /// <summary>
    /// Common repository class what provides standard Get, Add and Update functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CommonRepository<T> : IAddUpdateEntity<T>, IGetAllEntities<T>, IGetEntity<T, int> 
        where T : class, IDataEntity
    {
        public T AddOrUpdate(T entity)
        {
            using (var connection = new ReferenceDataEntities())
            {
                T oldValue = connection.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
                if (oldValue != null)
                {
                    connection.Entry(oldValue).CurrentValues.SetValues(entity);
                    connection.SaveChanges();
                }
                else
                {
                    connection.Set<T>().Add(entity);
                    connection.SaveChanges();
                }
                return entity;
            }
        }

        public virtual IEnumerable<T> GetItems()
        {
            List<T> entities;
            using (var connection = new ReferenceDataEntities())
            {
                entities = connection.Set<T>().ToList();
            }
            return entities;
        }

        public virtual T GetItem(int id)
        {
            T entity;
            using (var connection = new ReferenceDataEntities())
            {
                entity = connection.Set<T>().FirstOrDefault(x => x.Id == id);
            }
            return entity;
        }
    }
}
