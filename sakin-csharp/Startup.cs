using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sakin_csharp.Data;
using sakin_csharp.EventLogCollector;
using sakin_csharp.Repositories;

namespace sakin_csharp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Gerekli servisleri ekle
            services.AddDbContext<SakinDbContext>(); // Veritabanı bağlamı
            services.AddScoped<ISystemEventRepository, SystemEventRepository>(); // Olay deposu
            services.AddScoped<EventLogService>(); // Olay günlüğü servisi
            services.AddRazorPages(); // Razor sayfaları
            services.AddControllers(); // API denetleyicileri
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Geliştirme ve üretim ortamları için hata ayıklama
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // HTTPS yönlendirmesi ve statik dosyalar
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); // Yönlendirme

            app.UseAuthorization(); // Yetkilendirme

            // Uygulama uç noktalarını yapılandır
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // API uç noktaları
                endpoints.MapRazorPages(); // Razor sayfaları
            });
        }
    }
}