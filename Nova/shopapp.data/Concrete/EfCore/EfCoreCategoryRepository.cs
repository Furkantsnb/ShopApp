using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }
        public void DeleteFromCategory(int productId, int categoryId)//belirli bir ürünün belirli bir kategoriden silinmesini sağlar. 
        {
             var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
            //ExecuteSqlRaw yöntemi, SQL sorgusunu doğrudan veritabanına iletmek için kullanılır. Bu sorgu, productId ve categoryId
            //parametreleriyle birlikte çalışır. Ancak, SQL sorgusu olması gereken yerine Entity Framework Core ile LINQ kullanılarak da gerçekleştirilebilirdi.

            ShopContext.Database.ExecuteSqlRaw(cmd, productId, categoryId);

        }

        public Category GetByIdWithProducts(int categoryId)
        {
           
                return ShopContext.Categories
                            .Where(i => i.CategoryId == categoryId)
                            .Include(i => i.ProductCategories)//ilişkili verilerin yüklendiğinden emin olmak için kullanılır.
                            .ThenInclude(i => i.Product)
                            .FirstOrDefault();// ise sorgunun yalnızca ilk sonucunu alır ve Category nesnesini döndürür.
            
        }

    }
}
