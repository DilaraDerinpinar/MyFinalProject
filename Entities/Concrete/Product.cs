using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Concrete
{
    //bu classa diğer katmanlar ulaşabilsin diye public yaptık.
    public class Product:IEntity
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } //stok adeti tutar
        public decimal UnitPrice { get; set; } //parayı tutar

        //Product da bir db tablosudur. Çünkü IEntity yi implemente etmiş
    }
}
