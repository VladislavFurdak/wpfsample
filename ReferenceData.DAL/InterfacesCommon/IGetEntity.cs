using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.DAL
{
    public interface IGetEntity<out T, TKey> 
    {
        T GetItem(TKey id);
    }
}
