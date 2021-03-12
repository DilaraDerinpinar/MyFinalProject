using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
    public class Category:IEntity //implemente edildiği yere bakılırsa category bir db tablosu.
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
