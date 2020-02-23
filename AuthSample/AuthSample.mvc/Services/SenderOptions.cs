using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSample.mvc.Services
{
    public class SenderOptions
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public bool UseSsl { get; set; }

        public string AliAccessKey { get; set; }

        public string AliAccessSecret { get; set; }

        public string AliSignName { get; set; }

        public string AliTemplateCode { get; set; }
    }
}
