using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Services;
//using TDKRSports.DataStore.HardCoded;
using TDKRSports.DataStore.SQL.Dapper;
using TDKRSports.StateStore.DI;
using TDKRSports.UseCases.OrderConfirmationScreen;
using TDKRSports.UseCases.PluginInterfaces.DataStore;
using TDKRSports.UseCases.PluginInterfaces.StateStore;
using TDKRSports.UseCases.PluginInterfaces.UI;
using TDKRSports.UseCases.SearchProductScreen;
using TDKRSports.UseCases.ShoppingCartScreen;
using TDKRSports.UseCases.ViewProductScreen;
using TDKRSports.UseCases.AdminPortal.OutstandingOrdersScreen;
using TDKRSports.UseCases.AdminPortal.ProccesedOrdersScreen;
using TDKRSports.UseCases.AdminPortal.OrderDetailScreen;
using TDKRSports.Web.Data;
using TDKRSports.UseCases.AdminPortal.OrderDetailScreen.Interfaces;

namespace TDKRSports.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication("TDKRSports.CookieAuth")
                    .AddCookie("TDKRSports.CookieAuth", config =>
                    {
                        config.Cookie.Name = "TDKRSports.CookieAuth";
                        config.LoginPath = "/authenticate";
                    });
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            //dependency injection SINGLETONS
            //singleton je za inmemory
            //services.AddSingleton<IProductRepository, ProductRepository>();
            //services.AddSingleton<IOrderRepository, OrderRepository>();

            //dependency injection SCOPES
            services.AddScoped<IShoppingCart, TDKRSports.ShoppingCart.LocalStorage.ShoppingCart>(); // ako je singleton svi useri ce moci vidjeti , ovako ce samo user vidit sam svoj cart
            services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

            // BAZA DI
            services.AddTransient<IDataAccess>(sp => new DataAccess(Configuration.GetConnectionString("Default")));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();


            //dependency injection TRANSIENTS
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
            services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
            services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();


            services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
            services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
            services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
            services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
