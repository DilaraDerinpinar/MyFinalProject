using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success)
        {

            Message = message;
           
        }

        public Result(bool success)
        {

            
            Success = success;
        }

        public bool Success { get; } //sadece get oldugu için read only dir yani değer ataması yapılamaz.AMA SADECE CONSTRUCTOR İÇİNDE DEĞER ATAMASI YAPILABİLİR!!!

        public string Message { get; }
    }
}
