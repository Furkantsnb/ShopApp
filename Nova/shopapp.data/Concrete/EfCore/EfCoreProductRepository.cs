﻿using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {//neden using kullanmısızz araştır.

        public EfCoreProductRepository(ShopContext context) : base(context)
        { 
        }
        private ShopContext ShopContext
        {
            get { return context as ShopContext;}
        }
        public Product GetByIdWithCategories(int id)
        {
           
                return ShopContext.Products
                                .Where(i => i.ProductId == id)
                                .Include(i => i.ProductCategories) //bu iki satır arasındaki fark nedir. neden then ınclude kullanmış
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault(); // birden fazla eleman varsa ilk bulunan elamanı döndürür.       
                             // .SingleOrDefault(); //sorgu sonucunda yalnız bir eleman varsa bu elemanı döndürür. hiç yoksa ve birden fazla ise hata fırlatır.
            
        }

        public int GetCountByCategory(string category) //out keywordune baksan iyi olur
        {
            
                var products = ShopContext.Products.Where(i => i.IsApproved).AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == category));
                }

                return products.Count();
            
        }
        public List<Product> GetHomePageProducts()
        {
            
                return ShopContext.Products
                    .Where(i => i.IsApproved && i.IsHome).ToList();
            
        }
        public Product GetProductDetails(string url)
        {
            
                return ShopContext.Products
                                .Where(i => i.Url == url)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();

            
        }
        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            
                var products = ShopContext
                    .Products
                    .Where(i => i.IsApproved)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList(); 
            
        }
        public List<Product> GetSearchResult(string searchString)
        {
            
                var products = ShopContext
                    .Products
                    .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                    .AsQueryable(); //queryable ve containse bak !!

                return products.ToList();
            
        }

        public void Update(Product entity, int[] categoryIds)
        {
            
                var product = ShopContext.Products
                                    .Include(i => i.ProductCategories)
                                    .FirstOrDefault(i => i.ProductId == entity.ProductId);


                if (product != null) //objectmapper.Map<Product, Entity>(product, entity);
                { // automapper (mappleme)
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;
                    product.IsApproved = entity.IsApproved;
                    product.IsHome = entity.IsHome;

                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = catid
                    }).ToList();

                    context.SaveChanges();
                }
            
        }
    }
}