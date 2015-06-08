using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.DAL
{
    public class LocationsRepo : CommonRepository<Location>, IRepoLocations
    {
        public IEnumerable<Location> GetAllBySubdivisionId(int Id)
        {
            using (var connection = new ReferenceDataEntities())
            {
                return connection.Set<Location>().Where(x => x.SubdivisionId == Id).ToList();
            }
        }
    }
}
