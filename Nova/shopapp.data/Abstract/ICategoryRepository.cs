using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface ICategoryRepository :IRepository<Category>
    {
        Category GetByIdWithProducts(int categoryId);//belirli bir kategori kimlik (ID) değeri ile birlikte o kategoriye ait ürünleri almak için kullanılır.

        void DeleteFromCategory(int productId, int categoryId);//belirli bir ürünün belirli bir kategoriden silinmesi için kullanılır. 
    }
}
