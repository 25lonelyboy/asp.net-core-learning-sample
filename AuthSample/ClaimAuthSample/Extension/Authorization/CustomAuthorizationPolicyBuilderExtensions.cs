using ClaimAuthSample.Extension.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    public static class CustomAuthorizationPolicyBuilderExtensions
    {
        public static AuthorizationPolicyBuilder RequireMinAge(this AuthorizationPolicyBuilder builder, int minAge)
        {
            return builder.AddRequirements(new MinimumAgeRequirement(minAge));
        }
    }
}
