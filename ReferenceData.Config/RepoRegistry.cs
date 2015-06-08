using ReferenceData.DAL;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.Config
{
    public class RepoRegistry : Registry
    {
        public RepoRegistry()
        {
            For<IRepoCountry>().Use<CountriesRepo>();
            For<IRepoLocations>().Use<LocationsRepo>();
            For<IRepoSubdivision>().Use<SubdivisionRepo>();
            For<IRepoUser>().Use<UsersRepo>();
        }

    }
}
