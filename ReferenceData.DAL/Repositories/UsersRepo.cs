﻿using ReferenceData.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ReferenceData.DAL
{
    public class UsersRepo : CommonRepository<User> , IRepoUser
    {
        public override IEnumerable<User> GetItems()
        {
            List<User> entities;
            using (var connection = new ReferenceDataEntities())
            {
                entities = connection.Users.Include(x=>x.Country).Include(x=>x.Location).Include(x=>x.Subdivision).ToList();
            }
            return entities;
        }

        public override User GetItem(int id)
        {
            using (var connection = new ReferenceDataEntities())
            {
                return connection.Users.Include(x => x.Country).Include(x => x.Location).Include(x => x.Subdivision).FirstOrDefault(x => x.Id == id);
            }
        }
    }

 
}
