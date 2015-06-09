
namespace ReferenceData
{
    public interface IGetEntity <out TEntity, TEntityID>
    {
         TEntity Get(TEntityID id);
    }
}
