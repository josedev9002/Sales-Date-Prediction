namespace Sales_Date_Prediction_.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
