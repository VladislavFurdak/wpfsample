using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData
{
    public interface IUpdateEntity<T>
    {
        T Update(T entity);
    }
}
