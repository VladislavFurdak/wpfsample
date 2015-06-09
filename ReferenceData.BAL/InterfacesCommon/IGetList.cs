using System.Collections.Generic;

namespace ReferenceData
{
    public interface IGetList<out T>
    {
        IEnumerable<T> GetAll();
    }
}
