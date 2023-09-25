using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService: IValidator<Category>
    {
        Category GetById(int id);

        Category GetByIdWithProducts(int categoryId);// kategori id ürünlerine göre almak

        List<Category> GetAll(); 

        void Create(Category entity);//oluşturmak

        void Update(Category entity);//güncelleme
        void Delete(Category entity);//silmek
        void DeleteFromCategory(int productId, int categoryId);//katogoriden silme
    }
}
