
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //bağımlılık enjeksiyonu (dependency injection) constructor method ICategoryRepository türünden bir bağımlılık enjekte eder. Yani, CategoryManager sınıfı,
        //bir ICategoryRepository nesnesine ihtiyaç duyar ve bu ihtiyacı kurucu yöntemi aracılığıyla alır.
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(Category entity) // yeni bir kategoriy nesnesi oluşturmak için kullanılır.
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)// varolan bir kategoriyi silmek için kullanılır.
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int productId, int categoryId)//bir ürünü(productId) bir kategoriden(categoryId) çıkarmak için kullanılır. 
        {
            _categoryRepository.DeleteFromCategory(productId, categoryId);
        }

        public List<Category> GetAll() // tüm kategorileri getirmek için kullanır.
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)//belirli bir kimliğe sahip olan kategoriyi getirmek için kullanılır.
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdWithProducts(int categoryId)// belirli bir kimliğe sahip olan kategoriyi ve bu kategoriye ait olan ürünleri getirmek için kullanılır. 
        {
            return _categoryRepository.GetByIdWithProducts(categoryId);
        }

        public void Update(Category entity)//varolan bir kategoriyi güncellemek için kullanılır
        {
            _categoryRepository.Update(entity);
        }

        public bool Validation(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
