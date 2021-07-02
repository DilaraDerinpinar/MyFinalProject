using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ATTRIBUTE:Bir class ile ilgili bilgi verir attribute. Burada bu classın bir api controller olduğunu söylemek istiyor bu attribute.
    public class ProductsController : ControllerBase
    {
        //looosely coupled = gevşek bağımlılık
        //IoC = Inversion of Control = Değişimin kontrolü anlamındadır.
        IProductService _productService; //field tanımladık. fieldların defaultu private tır. bu private mesela. Bu sebeple _productService şeklinde bir naming convension yapılır.

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency chain = bağımlılık zinciri
            
            var result= _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       [HttpGet("getbyid")]

       public IActionResult GetById(int id)
       {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
       }




        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product); //clienttan(vue,react,angular vs.) gelen bilgiyi ekledik.
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
