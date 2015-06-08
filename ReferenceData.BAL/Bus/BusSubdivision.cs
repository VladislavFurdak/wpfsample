using AutoMapper;
using ReferenceData.BAL.BusModels;
using ReferenceData.DAL;
using ReferenceData.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace ReferenceData.BAL
{
    /// <summary>
    /// Contains business logic to work with Subdivisions
    /// </summary>
    public class BusSubdivision : CommonBus<Subdivision, int> , IBusSubdivision
    {
        private readonly IRepoSubdivision subdivisionRepo;

        public BusSubdivision(IRepoSubdivision subdivisionRepo)
            : base(subdivisionRepo, null, null, subdivisionRepo)
        {
            this.subdivisionRepo = subdivisionRepo;
        }

        public Dictionary<int, SubdivisionBusModel> GetSimpleSubdivisionList()
        {
          return GetAll().
                 Select(x => Mapper.Map<SubdivisionBusModel>(x)).
                 ToDictionary(x=>x.Id);
        }

        public IEnumerable<SubdivisionBusModel> GetAllByCountryId(int countryId)
        {
           return subdivisionRepo.
                  GetAllByCountryId(countryId).
                  Select(x => Mapper.Map<SubdivisionBusModel>(x));
        }
    }
}
