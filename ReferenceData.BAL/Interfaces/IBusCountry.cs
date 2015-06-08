using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL
{
    public interface IBusCountry : IGetEntity<Country, int>, IGetList<Country>
    {
        Dictionary<int, CountryBusModel> GetSimpleCountryList();
    }
}
