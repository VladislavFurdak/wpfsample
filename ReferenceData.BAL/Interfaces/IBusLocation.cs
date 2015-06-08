using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System.Collections.Generic;

namespace ReferenceData.BAL
{
    public interface IBusLocation : IGetEntity<Location, int>, IGetList<Location>
    {
        Dictionary<int, LocationBusModel> GetSimpleLocationList();
        IEnumerable<LocationBusModel> GetBySubdivisionId(int countryId);
    }
}
