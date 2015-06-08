using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.DAL
{
    public class SubdivisionRepo : CommonRepository<Subdivision>, IRepoSubdivision
    {
        public IEnumerable<Subdivision> GetAllByCountryId(int Id)
        {
            using (var connection = new ReferenceDataEntities())
            {
               return connection.Set<Subdivision>().Where(x => x.CountryId == Id).ToList();
            }
        }
    }

}
