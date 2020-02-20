using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceAuthorizeSample.Extensions;
using ResourceAuthorizeSample.Models;

namespace ResourceAuthorizeSample.Controllers
{
    public class ProductController : Controller
    {
        //注入授权服务
        private readonly IAuthorizationService _authorizationService;
        public ProductController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Read(int productId)
        {
            //模拟从数据库获取资源实体
            Product product = new Product { Id = productId };
            //进行资源的权限判断
            //这里可能操作多个资源，需要对多个资源分别进行权限的判断
            var authorizeResult = await _authorizationService.AuthorizeAsync(User, product, Operation.Read);
            if(authorizeResult.Succeeded)
            {
                return View(product);
            }
            return new ForbidResult();
        }
    }
}