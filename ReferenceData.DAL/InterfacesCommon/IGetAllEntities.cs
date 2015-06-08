using System.Collections.Generic;

namespace ReferenceData.DAL
{
    public interface IGetAllEntities<out TModel>
    {
        IEnumerable<TModel> GetItems();
    }
}
