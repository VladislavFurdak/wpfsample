using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL
{
    public interface IBusLocation : IGetEntity<Location, int>, IGetList<Location>
    {
        Dictionary<int, LocationBusModel> GetSimpleLocationList();
        IEnumerable<LocationBusModel> GetBySubdivisionId(int countryId);
    }
}
