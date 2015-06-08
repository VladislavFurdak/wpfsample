using AutoMapper;
using ReferenceData.BAL.BusModels;
using ReferenceData.DAL;
using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL
{
    /// <summary>
    /// Contains business logic to work with Locations
    /// </summary>
    public class BusLocation : CommonBus<Location, int>, IBusLocation
    {
        private readonly IRepoLocations locationRepo;
        public BusLocation(IRepoLocations locationRepo)
            : base(locationRepo, null, null, locationRepo)
        {
            this.locationRepo = locationRepo;
        }

        public Dictionary<int, LocationBusModel> GetSimpleLocationList()
        {
         return this.GetAll().
                Select(x => Mapper.Map<LocationBusModel>(x)).
                ToDictionary(x => x.Id);
        }

        public IEnumerable<LocationBusModel> GetBySubdivisionId(int subivisionId)
        {
         return locationRepo.
                GetAllBySubdivisionId(subivisionId).
                Select(x => Mapper.Map<LocationBusModel>(x));
        }
    }
}
