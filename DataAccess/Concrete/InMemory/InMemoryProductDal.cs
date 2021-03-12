using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        //BELLEKTEKİ ÜRÜN ERİŞİM KODLARININ YAZILACAĞI YERDİR BURASI
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> //bellekte ürünler oluşturmuş gibi simüle ettik
            {
                new Product {ProductID = 1, CategoryID = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductID = 2, CategoryID = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product
                {
                    ProductID = 3, CategoryID = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2
                },
                new Product {ProductID = 4, CategoryID = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductID = 5, CategoryID = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };

            //ODEV 3 CALISMLALARI:

            //var result=_products.Any(p => p.ProductName == "Bardak"); //bardak varsa true yoksa false döner.LINQ olmasa döngü ile tek tek bakıcaktık.
            //Console.WriteLine(result);


            //var result = _products.Find(p => p.ProductID == 3); //id si 3 olan ürünün tüm biglilerini dönderiyo.
            //Console.WriteLine(result.ProductName);


            //var result=_products.FindAll(p => p.ProductName.Contains("Tel")); //içinde tel kelimesi içeren ürünü dönderir.
            //Console.WriteLine(result);


            //var result=_products.Where(p => p.ProductName.Contains("Tel")).OrderByDescending(p=>p.UnitPrice).ThenByDescending(p=>p.ProductName); //içinde tel kelimesi geçen ürünü dönderir ve unitprice ı büyükten küçüğe olacak şekilde dönderir.Daha sonra da alfabetik olarak azalan şekilde sıralar.
            //Console.WriteLine(result);


            //var result = from p in _products //bu şekilde de filtreleyip arayabiliyoruz
            //             where p.UnitPrice>3
            //             orderby p.UnitPrice descending,p.ProductName ascending 
            //             select p;

            //foreach (var product in result)
            //{
            //    Console.WriteLine(product.ProductName);

            //}



            //var result = from p in _products //bu şekilde de filtreleyip arayabiliyoruz
            //    where p.UnitPrice > 3
            //    orderby p.UnitPrice descending, p.ProductName ascending
            //    select new ProductDTO{ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = p.UnitPrice};

            //foreach (var product in result) //burada artık productDTO dolaşılır.
            //{
            //    Console.WriteLine(product.ProductName);

            //}


            //BİR NESNE OLUŞTURACAĞIZ O DA PRODUCTDTO. ID,NAME,UNITPRICE PRODUCTSTAN, CATEGORYNAME ISE CATEGORY TABLOSUNDAN
            //GELECEK BU DURUMDA JOINLER KULLANILIR:

            //var result = from p in _products
            //             join c in categories on p.CategoryID equals c.CategoryID
            //             where p.UnitPrice>5000
            //             orderby p.UnitPrice descending 
            //             select new ProductDTO
            //             {
            //                 ProductID = p.ProductID,
            //                 CategoryName = c.CategoryName,
            //                 ProductName = p.ProductName,
            //                 UnitPrice = p.UnitPrice
            //             };

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ProductName);
            //    Console.WriteLine(item.CategoryName);
            //}




        }

        public List<Product> GetAll()
        {
            //veritabanındaki datayı businessa döndermem gerekir burda
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün idsine sahip olan listedeki ürünü bul demektir bu.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);

            //bilgileri güncelleyebilirsin:
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }

        public void Delete(Product product)
        {
            //LINQ Language Integrated Query Dile Gömülü Sorgulama
            //Product productToDelete=null;

            //foreach (var p in _products)
            //{
            //    if (product.ProductID == p.ProductID)
            //    {
            //        productToDelete = p;
            //    }
            //}

            

            //products i tek tek gezer yani üstteki foreachin yaptığını yapar:
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID);

            _products.Remove(productToDelete);

        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where şartı içindeki ifadeye uyanları listeler sql deki where koşulu gibi.
            return _products.Where(p => p.CategoryID == categoryId).ToList();

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }

    class ProductDTO
    {

        public int ProductID { get; set; }
        public string CategoryName { get; set; }

        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }


    }



}
