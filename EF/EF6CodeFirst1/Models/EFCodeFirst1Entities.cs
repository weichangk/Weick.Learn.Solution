using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst1.Models
{
    public class EFCodeFirst1Entities: DbContext
    {
        public EFCodeFirst1Entities() : base("name=EFCodeFirst1Entities")
        {
            //查看 EF 生成的 SQL 查询。 跟踪 SQL。输出日志
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Database.Log = s => File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "/sql.txt", s);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
