using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        //DATA TRANSFORMATION OBJECT=DTO. TAŞIYCAĞIMIZ OBJELERİ İFADE EDER.

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }




    }
}
