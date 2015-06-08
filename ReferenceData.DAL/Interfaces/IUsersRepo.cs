using ReferenceData.DAL.Model;

namespace ReferenceData.DAL
{
    public interface IRepoUser : IAddUpdateEntity<User>, IGetAllEntities<User>, IGetEntity<User, int> 
    {
    }
}
