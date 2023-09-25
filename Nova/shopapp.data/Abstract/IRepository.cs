namespace shopapp.data.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);// ıd değerine göre veri tabanından nesne almak için kullanılıyor.

        List<T> GetAll();// bu metot veri tabanından tüm nesneleri alır.

        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);
    }
}
