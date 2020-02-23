﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension.Authorization
{
    public class MinimumAgeAuthorizeAttribute : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "MinimumAge";

        public MinimumAgeAuthorizeAttribute(int age) => Age = age;

        public int Age {
            get 
            { 
                if(int.TryParse(Policy.Substring(POLICY_PREFIX.Length), out int age))
                {
                    return age;
                }
                return default(int);
            }
            set
            {
                Policy = $"{POLICY_PREFIX}{value}";
            }
        }
    }
}
