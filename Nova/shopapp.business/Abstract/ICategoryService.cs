using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService: IValidator<Category>
    {
        Category GetById(int id);//Kimliğe göre al

        Category GetByIdWithProducts(int categoryId);// kategori id ürünlerine göre almak

        List<Category> GetAll(); //Hepsini al

        void Create(Category entity);//oluşturmak

        void Update(Category entity);//güncelleme
        void Delete(Category entity);//silmek
        void DeleteFromCategory(int productId, int categoryId);//katogoriden silme
    }
}
