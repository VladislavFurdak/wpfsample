using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL
{
    public interface IBusSubdivision : IGetEntity<Subdivision, int>, IGetList<Subdivision>
    {
        Dictionary<int, SubdivisionBusModel> GetSimpleSubdivisionList();
        IEnumerable<SubdivisionBusModel> GetAllByCountryId(int countryId);
    }
}
