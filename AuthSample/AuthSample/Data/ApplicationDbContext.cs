using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthSample.Data
{
    //用自定义的User类替换原有的User类
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //修改用户表主键类型
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //模型创建，这里可以进行数据库表的相关设置
        //也可以在实体类中通过标签的方式进行设置
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUser>(b => {
                //配置表之间的映射关系
                b.HasMany(p => p.Products);

                //修改表名称
                b.ToTable("User");

                //配置字段属性
                b.Property(t => t.UserName).HasMaxLength(50);
            });

            builder.Entity<IdentityRole>(b => {
                b.ToTable("Role");
            });

            //更改架构
            builder.HasDefaultSchema("uc");
        }

        public DbSet<Product> Products { get; set; }
    }
}
