using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        //Constructor ile IProducRepository ait bilgileri kullanır
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        
        public bool Create(Product entity)//yeni ürün oluşturmak için kullanılır
        {
            if (Validation(entity))//entity parametresi geçerli ise veri tabanına yeni bir ürün eklenir. 
            {
                _productRepository.Create(entity);
                return true;
            }
            return false;
        }
        
        public void Delete(Product entity)//var olan bir ürünü silmek için kullanır.        
        {
            _productRepository.Delete(entity);
        }

        
        public List<Product> GetAll()//tüm ürün nesnelerini bir liste halinde döndürür.
        {
            return _productRepository.GetAll();
        }

        
        public Product GetById(int id) //belirli id göre ürün getirir.
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)//id numarasına sahip ürünü ve bu ürünün bulunduğu kategoriyi getirir.
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)//ilgili kategoride bulunan ürün sayısını getirir.
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()//Anasayfada gösterilecek ürünleri listeler.
        {
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)//url göre detay gösterme
        {
            return _productRepository.GetProductDetails(url);
        }

        //Belirli bir kategoriye ait olan ürünleri sayfalama yaparak getirmek için kullanılır.
        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)//arama yaparak ürün listeleme
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)//var olan ürünü güncelleme
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
