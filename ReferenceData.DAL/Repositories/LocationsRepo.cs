using ReferenceData.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace ReferenceData.DAL
{
    public class LocationsRepo : CommonRepository<Location>, IRepoLocations
    {
        public IEnumerable<Location> GetAllBySubdivisionId(int Id)
        {
            using (var connection = new ReferenceDataEntities())
            {
                return connection.Set<Location>().
                                  Where(x => x.SubdivisionId == Id).
                                  ToList();
            }
        }
    }
}
