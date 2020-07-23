using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models
{
    public class FirstWebApiEntities: DbContext//数据库上下文对象
    {
        public FirstWebApiEntities() : base("name=FirstWebApiEntities")
        {
            //查看 EF 生成的 SQL 查询。 跟踪 SQL。输出日志
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}