using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSample.Data
{
    //修改主键类型，IdentityUser有泛型版本
    public class ApplicationUser : IdentityUser<int>
    {
        [MaxLength(20)]
        public string CustomTag { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
