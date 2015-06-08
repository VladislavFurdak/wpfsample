using ReferenceData.DAL.Model;

namespace ReferenceData.DAL
{
    public interface IRepoCountry : IGetAllEntities<Country>, IGetEntity<Country, int> 
    {
    }
}
