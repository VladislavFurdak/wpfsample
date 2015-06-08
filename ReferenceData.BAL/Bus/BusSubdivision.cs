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
            var subdivisions = this.GetAll().Select(x => Mapper.Map<SubdivisionBusModel>(x)).ToDictionary(x=>x.Id);
            return subdivisions;
        }

        public IEnumerable<SubdivisionBusModel> GetAllByCountryId(int countryId)
        {
            return subdivisionRepo.GetAllByCountryId(countryId).Select(x => Mapper.Map<SubdivisionBusModel>(x));
        }
    }
}
