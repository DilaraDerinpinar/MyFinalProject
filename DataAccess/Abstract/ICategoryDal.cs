using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //bunları yorum içine aldım çünkü ientityrepositoryden alıcak zaten
        //List<Category> GetAll();

        //void Add(Category category);

        //void Update(Category category);


        //void Delete(Category category);

        //List<Category> GetAllByCategory(int categoryId);
    }
}
