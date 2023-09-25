using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using shopapp.data.Concrete.EfCore;
using ShopApp.WebUI.Extensons;
using ShopApp.WebUI.Identity;

namespace ShopApp.WebUI
{
    public class Program
    {



        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
          
           // Servisler burdan çaðrýlýyor
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
            builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            builder.Services.IOCService();
            builder.Services.EmailSenderConfiguration(builder.Configuration);
            builder.Services.AddControllersWithViews();//mvc

            //builder.Services.AddAuthentication();//
            //builder.Services.AddAuthorization();//




            var app = builder.Build();
           
            
            app.UseStaticFiles(); // wwwroot klasöründeki dosyalarý servis et


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });

            if (app.Environment.IsDevelopment())
            {
               // SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                     name: "orders",
                     pattern: "orders",
                     defaults: new { controller = "Cart", action = "GetOrders" }
                 );


            app.MapControllerRoute(
              name: "checkout",
              pattern: "checkout",
              defaults: new { controller = "Cart", action = "Checkout" }
          );

            app.MapControllerRoute(
                name: "cart",
                pattern: "cart",
                defaults: new { controller = "Cart", action = "Index" }
            );

            app.MapControllerRoute(
               name: "adminuseredit",
               pattern: "admin/user/{id?}",
               defaults: new { controller = "Admin", action = "UserEdit" }
           );

            app.MapControllerRoute(
               name: "adminusers",
               pattern: "admin/user/list",
               defaults: new { controller = "Admin", action = "UserList" }
           );

            app.MapControllerRoute(
                name: "adminroles",
                pattern: "admin/role/list",
                defaults: new { controller = "Admin", action = "RoleList" }
            );

            app.MapControllerRoute(
                name: "adminrolecreate",
                pattern: "admin/role/create",
                defaults: new { controller = "Admin", action = "RoleCreate" }
            );


            app.MapControllerRoute(
                name: "adminroleedit",
                pattern: "admin/role/{id?}",
                defaults: new { controller = "Admin", action = "RoleEdit" }
            );

            app.MapControllerRoute(
                name: "adminproducts",
                pattern: "admin/products",
                defaults: new { controller = "Admin", action = "ProductList" }
            );

            app.MapControllerRoute(
                name: "adminproductcreate",
                pattern: "admin/products/create",
                defaults: new { controller = "Admin", action = "ProductCreate" }
            );

            app.MapControllerRoute(
                name: "adminproductedit",
                pattern: "admin/products/{id?}",
                defaults: new { controller = "Admin", action = "ProductEdit" }
            );

            app.MapControllerRoute(
               name: "admincategories",
               pattern: "admin/categories",
               defaults: new { controller = "Admin", action = "CategoryList" }
           );

            app.MapControllerRoute(
                name: "admincategorycreate",
                pattern: "admin/categories/create",
                defaults: new { controller = "Admin", action = "CategoryCreate" }
            );

            app.MapControllerRoute(
                name: "admincategoryedit",
                pattern: "admin/categories/{id?}",
                defaults: new { controller = "Admin", action = "CategoryEdit" }
            );

            // localhost/search    
            app.MapControllerRoute(
                name: "search",
                pattern: "search",
                defaults: new { controller = "Shop", action = "search" }
            );

            app.MapControllerRoute(
                name: "productdetails",
                pattern: "{url}",
                defaults: new { controller = "Shop", action = "details" }
            );

            app.MapControllerRoute(
                name: "products",
                pattern: "products/{category?}",
                defaults: new { controller = "Shop", action = "list" }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );


            // Create a scope to get the services
            using (var scope = app.Services.CreateScope())
            {
                // Get the UserManager and RoleManager from the service provider
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Call the SeedIdentity.Seed method with the required parameters
                SeedIdentity.Seed(userManager, roleManager, builder.Configuration).Wait();
            }

            app.Run();

        }
    }

}