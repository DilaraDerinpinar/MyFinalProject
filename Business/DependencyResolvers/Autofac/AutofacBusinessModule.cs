using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            //uygulama hayata geçtiğinde çalışan kısımdır.
            builder.RegisterType <ProductManager>().As<IProductService>().SingleInstance(); //biri Iproductservice isterse productmanager instance i ver ona demektir bu kod. singleinstance tek bir instance oluşturuluyo ona veriliyor.
            
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance(); //biri Iproductservice isterse productmanager instance i ver ona demektir bu kod. singleinstance tek bir instance oluşturuluyo ona veriliyor.

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }


    }
}
