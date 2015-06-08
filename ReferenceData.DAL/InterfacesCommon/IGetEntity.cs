namespace ReferenceData.DAL
{
    public interface IGetEntity<out T, TKey> 
    {
        T GetItem(TKey id);
    }
}
