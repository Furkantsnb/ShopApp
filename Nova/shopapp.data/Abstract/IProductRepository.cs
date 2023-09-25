using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url); // url ile ürün detaylarını alır.
        Product GetByIdWithCategories(int id);//(ID) değeri ile birlikte kategorileriyle birlikte detaylarını alır.
        List<Product> GetProductsByCategory(string name, int page, int pageSize);//kategori adına göre sayfa numarası  ve sayfa da bulunan ürün sayısını verir.
        List<Product> GetSearchResult(string searchString); // ürün arama sonuçlarını liste olarak döndürür.
        List<Product> GetHomePageProducts();//ana sayfaya özel ürünleri filtrelemek üçün kullanılır.
        int GetCountByCategory(string category);//belirli kategoride olan ürün sayısını verir
        void Update(Product entity, int[] categoryIds);
    }
}
