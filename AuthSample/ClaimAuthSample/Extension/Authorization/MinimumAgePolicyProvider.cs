using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension.Authorization
{
    public class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "MinimumAge";
        
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public MinimumAgePolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if(policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) 
                && int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out int age))
            {
                var policyBuilder = new AuthorizationPolicyBuilder();
                policyBuilder.RequireMinAge(age);
                //policyBuilder.AddRequirements(new MinimumAgeRequirement(age));
                return Task.FromResult(policyBuilder.Build());
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();
    }
}
