using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension
{
    public class MemoryCacheTickeStore : ITicketStore
    {
        private const string MyPrefix = "Ticket";
        private IMemoryCache _menoryCache;

        public MemoryCacheTickeStore(IMemoryCache memoryCache)
        {
            _menoryCache = memoryCache;
        }

        public Task RemoveAsync(string key)
        {
            _menoryCache.Remove(key);
            return Task.CompletedTask;
        }

        public Task RenewAsync(string key, AuthenticationTicket ticket)
        {
            var option = new MemoryCacheEntryOptions();
            var expiresUtc = ticket.Properties.ExpiresUtc;
            if(expiresUtc.HasValue)
            {
                option.SetAbsoluteExpiration(expiresUtc.Value);
            }
            option.SetSlidingExpiration(TimeSpan.FromHours(1));
            _menoryCache.Set(key, ticket, option);
            return Task.CompletedTask;
        }

        public Task<AuthenticationTicket> RetrieveAsync(string key)
        {
            _menoryCache.TryGetValue(key, out AuthenticationTicket ticket);
            return Task.FromResult(ticket);
        }

        public async Task<string> StoreAsync(AuthenticationTicket ticket)
        {
            var key = MyPrefix + Guid.NewGuid().ToString();
            await RenewAsync(key, ticket);
            return key;
        }
    }
}
