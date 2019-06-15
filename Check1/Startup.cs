namespace Check1
{
    using System.Collections.Generic;

    using Check1.Domain;
    using Check1.Repository;
    using Check1.Service;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<ICollection<Item>>(p => new List<Item>());
            services.AddSingleton<ICollection<Vendor>>(p => new List<Vendor>());
            services.AddSingleton<ICollection<Order>>(p => new List<Order>());

            services.AddScoped<IItemDataStore, ItemDataStore>();
            services.AddScoped<IVendorDataStore, VendorDataStore>();
            services.AddScoped<IOrderDataStore, OrderDataStore>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var items = app.ApplicationServices.GetRequiredService<ICollection<Item>>();
            items.Add(new Item { Id = 1, Color = Domain.Enums.ItemColor.Red, Name = "T-Shirt1", Size = Domain.Enums.ItemSize.L, Type = Domain.Enums.ItemType.TShirt });
            items.Add(new Item { Id = 2, Color = Domain.Enums.ItemColor.Red, Name = "T-Shirt2", Size = Domain.Enums.ItemSize.M, Type = Domain.Enums.ItemType.TShirt });
            items.Add(new Item { Id = 3, Color = Domain.Enums.ItemColor.Blue, Name = "T-Shirt3", Size = Domain.Enums.ItemSize.L, Type = Domain.Enums.ItemType.TShirt });
            items.Add(new Item { Id = 4, Color = Domain.Enums.ItemColor.Blue, Name = "T-Shirt4", Size = Domain.Enums.ItemSize.M, Type = Domain.Enums.ItemType.TShirt });
            items.Add(new Item { Id = 5, Color = Domain.Enums.ItemColor.Red, Name = "T-Shirt5", Size = Domain.Enums.ItemSize.L, Type = Domain.Enums.ItemType.DressShirt });
            items.Add(new Item { Id = 6, Color = Domain.Enums.ItemColor.Red, Name = "T-Shirt6", Size = Domain.Enums.ItemSize.M, Type = Domain.Enums.ItemType.DressShirt });
            items.Add(new Item { Id = 7, Color = Domain.Enums.ItemColor.Blue, Name = "T-Shirt7", Size = Domain.Enums.ItemSize.L, Type = Domain.Enums.ItemType.DressShirt });
            items.Add(new Item { Id = 8, Color = Domain.Enums.ItemColor.Blue, Name = "T-Shirt8", Size = Domain.Enums.ItemSize.M, Type = Domain.Enums.ItemType.DressShirt });
            var vendors = app.ApplicationServices.GetRequiredService<ICollection<Vendor>>();
            var vendor = new Vendor
            {
                Id = 1,
                BuyPrices = { { Domain.Enums.ItemType.TShirt, 6 }, { Domain.Enums.ItemType.DressShirt, 8 } },
                SellPrices = { { Domain.Enums.ItemType.TShirt, 12 }, { Domain.Enums.ItemType.DressShirt, 20 } }
            };
            vendors.Add(vendor);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}