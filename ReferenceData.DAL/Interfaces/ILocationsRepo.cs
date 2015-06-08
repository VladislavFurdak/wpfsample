using ReferenceData.DAL.Model;
using System.Collections.Generic;

namespace ReferenceData.DAL
{
    public interface IRepoLocations : IGetAllEntities<Location>, IGetEntity<Location, int> 
    {
        IEnumerable<Location> GetAllBySubdivisionId(int Id);
    }
}
