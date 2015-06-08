using ReferenceData.BAL;
using ReferenceData.DAL;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.Config
{
    public class RegistryBus : Registry
    {
        public RegistryBus()
        {
            For<IBusCountry>().Use<BusCountry>();
            For<IBusLocation>().Use<IBusLocation>();
            For<IBusSubdivision>().Use<BusSubdivision>();
            For<IBusUser>().Use<BusUser>();
        }

    }
}
