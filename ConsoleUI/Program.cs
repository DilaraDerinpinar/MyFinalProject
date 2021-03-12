using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //SOLID
    //O:Open closed Prencible yaptık biz.
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager=new ProductManager(new IProductDal());
            //ProductTest();
            //CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach(var item in productManager.GetProductDetails())
            {
                Console.WriteLine($"{item.CategoryName} ------ {item.ProductName}");
                //iki tablodan dataları joinleyip getirdik
            }

            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine(item.ProductName + "/" + item.CategoryName);
            }
        }
    }
}
