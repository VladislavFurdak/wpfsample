using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System.Collections.Generic;

namespace ReferenceData.BAL
{
    public interface IBusSubdivision : IGetEntity<Subdivision, int>, IGetList<Subdivision>
    {
        Dictionary<int, SubdivisionBusModel> GetSimpleSubdivisionList();
        IEnumerable<SubdivisionBusModel> GetAllByCountryId(int countryId);
    }
}
