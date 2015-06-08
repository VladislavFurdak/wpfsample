using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.DAL
{
    public interface IRepoCountry : IGetAllEntities<Country>, IGetEntity<Country, int> 
    {
    }
}
