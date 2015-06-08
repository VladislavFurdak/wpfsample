using System;
using System.Collections.Generic;
using System.Linq;
using ReferenceData.DAL.Model;
using ReferenceData.DAL;
using ReferenceData.BAL.BusModels;
using AutoMapper;

namespace ReferenceData.BAL
{
    /// <summary>
    /// Contains business logic to work with Users
    /// </summary>
    public class BusUser : CommonBus<User,int>, IBusUser
    {
        private readonly IRepoUser userRepo;
        private readonly IRepoCountry repoCountry;
        private readonly IRepoLocations repoLocation;
        private readonly IRepoSubdivision repoSubdiv;

        public BusUser(IRepoUser userRepo, IRepoCountry repoCountry, IRepoLocations repoLocation, IRepoSubdivision repoSubdiv)
            : base(userRepo, userRepo, userRepo, userRepo)
        {
          this.userRepo = userRepo;
          this.repoCountry = repoCountry;
          this.repoLocation = repoLocation;
          this.repoSubdiv = repoSubdiv;
        }

        public  Dictionary<int, UserBusModel> UserList()
        {
          return this.GetAll().
                 Select(x => Mapper.Map<UserBusModel>(x)).
                 ToDictionary(x => x.Id);
        }

        public UserBusModel AddBusModel(UserBusModel model)
        {
          if (!model.IsValid) throw new ArgumentException();
          var Id =  this.Add(Mapper.Map<UserBusModel, User>(model)).Id;
          return Mapper.Map<User, UserBusModel>(Get(Id));
        }

        public UserBusModel UpdateBusModel(UserBusModel model)
        {
            if (!model.IsValid) throw new ArgumentException();
            Update(Mapper.Map<UserBusModel, User>(model));
            return Mapper.Map<User, UserBusModel>(Get(model.Id));
        }


    }
}
