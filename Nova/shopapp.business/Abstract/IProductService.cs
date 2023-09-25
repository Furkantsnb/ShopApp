using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService:IValidator<Product>
    {
        Product GetById(int id);//Ürün Kimliğine Göre Al
        Product GetByIdWithCategories(int id);//Kategorilerle Kimliğe Göre Ürün Al
        Product GetProductDetails(string url);// Ürün Detaylarını Al
        List<Product> GetProductsByCategory(string name, int page, int pageSize);//Ürünü Listele  ve Ürünleri Kategoriye Göre Al
        int GetCountByCategory(string category);//Kategoriye Göre Sayımı Alın

        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        List<Product> GetAll();
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        bool Update(Product entity, int[] categoryIds);
    }
}
