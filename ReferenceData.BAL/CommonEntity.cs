using ReferenceData.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL
{
    public abstract class CommonBus<TEntityModel, TEntityID> where TEntityModel : class , IDataEntity
    {
        private readonly ReferenceData.DAL.IGetEntity<TEntityModel, TEntityID> repoGet;
        private readonly IAddUpdateEntity<TEntityModel> repoUpdate;
        private readonly IAddUpdateEntity<TEntityModel> repoAdd;
        private readonly IGetAllEntities<TEntityModel> repoGetAll;
     
        protected CommonBus(
                              ReferenceData.DAL.IGetEntity<TEntityModel, TEntityID> repoGet = null,
                              IAddUpdateEntity<TEntityModel> repoAdd = null,
                              IAddUpdateEntity<TEntityModel> repoUpdate = null,
                              IGetAllEntities<TEntityModel> repoGetAll = null
                              )
        {
            this.repoGet = repoGet;
            this.repoUpdate = repoUpdate;
            this.repoGetAll = repoGetAll;
            this.repoAdd = repoAdd;
        }

        public virtual TEntityModel Get(TEntityID id){
            if (this.repoGet == null)
                throw new NotImplementedException("Get() is not supported for this business entity");

            TEntityModel model = null;
            try
            {
                model = repoGet.GetItem(id);
            }
            catch
            {

            }
            return model;
        }

        public virtual TEntityModel Add(TEntityModel model)
        {
            if (this.repoAdd == null)
                throw new NotImplementedException("Add() is not supported for this business entity");
            try
            {
                repoAdd.AddOrUpdate(model);
            }
            catch
            {
            }
            return model;
        }

        public virtual TEntityModel Update(TEntityModel model)
        {
            if (this.repoUpdate == null)
                throw new NotImplementedException("Update() is not supported for this business entity");
            try
            {
                repoUpdate.AddOrUpdate(model);
            }
            catch
            {
            }
            return model;
        }

        public IEnumerable<TEntityModel> GetAll()
        {
            if (this.repoGetAll == null)
                throw new NotImplementedException("GetList() is not supported for this business entity");

            return repoGetAll.GetItems().ToList();
        }

    }
}
