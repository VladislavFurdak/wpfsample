using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData
{
    public interface IGetEntity <out TEntity, TEntityID>
    {
         TEntity Get(TEntityID id);
    }
}
