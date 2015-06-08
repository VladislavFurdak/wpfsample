using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System.Collections.Generic;

namespace ReferenceData.BAL
{
    public interface IBusCountry : IGetEntity<Country, int>, IGetList<Country>
    {
        Dictionary<int, CountryBusModel> GetSimpleCountryList();
    }
}
