using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRelax.Models
{
    public class EntityModel
    {
        public string GetNewCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        
    }
}