using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs; //referans oluşturuldu.

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product> //public i unutma asla!!!
    {
        //productlarla ilgili yapılacak operasyonlar burada tanımlanacak

        //List<Product> GetAll(); 

        //başka katmanı kullanmak istediğimizde referans vermek
        //zorundayız. Entities i kullancağımız için onu referans edicez.
        //aynı zamanda dependencies e de eklendi.Dependencies 
        //bağımlılıkları ifade eder.


        //void Add(Product product);

        //void Update(Product product);


        //void Delete(Product product);

        //List<Product> GetAllByCategory(int categoryId);



        List<ProductDetailDto> GetProductDetails();
       



        //NOT: INTERFACEIN KENDİSİ PUBLİC DEĞİLDİR. O YÜZDEN PUBLİC KOYUYORUZ. ANCAK METODLARI
        //HER ZAMAN DEFAULT PUBLİCTİR.
    }
}
