using Microsoft.AspNetCore.Identity;
using shopapp.business.Abstract;
using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using ShopApp.WebUI.EmailServices;

namespace ShopApp.WebUI.Extensons
{

    public static class ServiceExtensions
    {
       
        public static void IOCService(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IOrderService, OrderManager>();


        }


        public static void EmailSenderConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
            new SmtpEmailSender(
                   configuration["EmailSender:Host"],
                   configuration.GetValue<int>("EmailSender:Port"),
                   configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   configuration["EmailSender:UserName"],
                   configuration["EmailSender:Password"])
               );


        }



    }
}


