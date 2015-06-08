﻿using AutoMapper;
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
    /// Contains business logic to work with Countries
    /// </summary>
    public class BusCountry : CommonBus<Country, int>, IBusCountry
    {
        private readonly IRepoCountry countryRepo;
        private readonly IRepoSubdivision subdivisionRepo;

        public BusCountry(IRepoCountry countryRepo, IRepoSubdivision subdivisionRepo)
            : base(countryRepo, null, null, countryRepo)
        {
            this.countryRepo = countryRepo;
            this.subdivisionRepo = subdivisionRepo;
        }

        public Dictionary<int, CountryBusModel> GetSimpleCountryList()
        {
            var countries = this.GetAll().Select(x => Mapper.Map<CountryBusModel>(x)).ToDictionary(x => x.Id);
            return countries;
        }

      
    }
}