namespace ReferenceData.DAL
{
    public interface IAddUpdateEntity<T>
    {
         T AddOrUpdate(T country);
    }
}
