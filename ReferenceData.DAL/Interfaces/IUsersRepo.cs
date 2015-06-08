using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.DAL
{
    public interface IRepoUser : IAddUpdateEntity<User>, IGetAllEntities<User>, IGetEntity<User, int> 
    {
    }
}
