using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRCharSample.Models
{
    public class LoginModel
    {
        [DisplayName("用户名")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
