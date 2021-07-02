using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
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
            //AutoFac,Ninject... gibi IoC container alt yap�s� hizmeti verenler de vard�r.
            //AOP = Bir metodun �n�nde veya sonunda hata verdi�inde �al��an kod par�ac�klar�n� bu mimari ile yazar�z. Business katman�nda yaz�labilir. [] parantezler i�inde yaz�l�r. bu sebeple autofac gibi hizmetler kullan�l�r. asp.net in kendi IoC alt yap�s� bu kadar�na yeterli de�ildir.
            services.AddControllers();
            //singleton : uygulama ilk aya�a kalkt��� anda, servisin tek bir instance�� olu�turularak memory�de 
            //tutulur ve daha sonras�nda her servis �a�r�s�nda bu instance g�nderilir. Ancak i�erisinde parametre olmamas� laz�m.
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
