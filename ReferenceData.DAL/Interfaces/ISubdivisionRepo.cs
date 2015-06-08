using ReferenceData.DAL.Model;
using System.Collections.Generic;

namespace ReferenceData.DAL
{
    public interface IRepoSubdivision : IGetAllEntities<Subdivision>, IGetEntity<Subdivision, int> 
    {
         IEnumerable<Subdivision> GetAllByCountryId(int Id);
    }
}
