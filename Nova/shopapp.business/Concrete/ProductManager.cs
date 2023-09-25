using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        //bağımlılık enjeksiyonu (dependency injection)
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Bu metot bir ürün eklemek için kullanılır.
        public bool Create(Product entity)
        {
            if (Validation(entity))
            {
                _productRepository.Create(entity);// eğer doğru ise ürün ekleme yapar.
                return true;
            }
            return false;
        }
        //Ürün silme 
        public void Delete(Product entity)
        {
            // iş kuralları
            _productRepository.Delete(entity);
        }

        
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        
        public Product GetById(int id) 
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        //ürün güncelleme esnasında kategoriy ekleme işlemlerinde kullanılıyor.
        public bool Update(Product entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelisiniz.";
                    return false;
                }
                _productRepository.Update(entity, categoryIds);
                return true;
            }
            return false;
        }

        public string ErrorMessage { get; set; }

        public bool Validation(Product entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))// IsNullOrEmpty : entity ismine göre bir string değerini kontrol eder.
            {
                ErrorMessage += "ürün ismi girmelisiniz.\n";
                isValid = false;
            }

            if (entity.Price < 0)
            {
                ErrorMessage += "ürün fiyatı negatif olamaz.\n";
                isValid = false;
            }

            return isValid;
        }
    }
}
