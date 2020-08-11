using EF6CodeFirst1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EF6CodeFirst1
{
    public class EFTest1
    {
        public static void Show()
        {
            #region context生命周期管理
            //在一个context上下文对象中；SaveChanges();一次性保存全部的变化,是一个事务， 
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    Book book4 = context.Books.Find(4);
            //    book4.AuthorId = 4;
            //    Book book5 = context.Books.Find(5);
            //    book4.AuthorId = 55;
            //    context.SaveChanges();

            //    //1 context更新时保存全部变化，不能全局都是一个context
            //    //2 不同的context 也不能join的，除非都load到内存之后再去操作
            //    //3 context是一个数据库连接+内存对象，资源开销
            //    //4 一次请求，就是一个context，也不排除可能多个；
            //    //5 更多的时候，是一个service一个context实例；
            //    //6 多个请求 /多线程 最好是不同的context
            //}


            ////本地缓存
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    context.Database.Log += c => Console.WriteLine(c);

            //    var list = context.Books.Where(b => b.BookId < 2).ToList();
            //    Console.WriteLine("*****************0*****************");
            //    var user1 = context.Books.Find(2);
            //    Console.WriteLine("*****************1*****************");
            //    var user2 = context.Books.Where(b => b.BookId == 2).ToList();
            //    Console.WriteLine("*****************2*****************");
            //    var user3 = context.Books.Find(2);
            //    Console.WriteLine("*****************3*****************");
            //    var user4 = context.Books.Where(b => b.BookId == 2).ToList();
            //    Console.WriteLine("*****************4*****************");

            //    //Where查询不缓存；Find先在本地缓存查找(可能脏读，性能好处)
            //}

            #endregion

            #region 导航属性 预先加载/延迟加载/显式加载
            ////public class Author
            ////{
            ////    [Key]
            ////    public int AuthorId { get; set; }
            ////    [Required]
            ////    public string Name { get; set; }
            ////    //public ICollection<Book> Books { get; set; }//Book中已经有Author的属性，在这Author添加Book属性将出现循环引用导致在序列化模型时出现问题
            ////}

            ////public class Book
            ////{
            ////    [Key]
            ////    public int BookId { get; set; }
            ////    [Required]
            ////    public string Title { get; set; }
            ////    public decimal Price { get; set; }
            ////    public string Genre { get; set; }
            ////    public DateTime PublishDate { get; set; }
            ////    public string Description { get; set; }
            ////    public int AuthorId { get; set; }
            ////    [ForeignKey("AuthorId")]//外键关联
            ////    public Author Author { get; set; }//virtual navigation property   启用延迟加载   virtual修饰
            ////}


            //Include预先加载
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    context.Database.Log += c => Console.WriteLine(c);
            //    var books = context.Books.Include(b => b.Author);
            //    foreach (var item in books)
            //    {
            //        Console.WriteLine(item.BookId);
            //    }
            //}


            ////延迟加载
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    context.Database.Log += c => Console.WriteLine(c);
            //    var books = context.Books;// Does not load Books
            //    foreach (var item in books)//load Books; // Does not load authors
            //    {
            //        Console.WriteLine(item.BookId);
            //    }

            //    var author = books.ToList()[0].Author;   // Loads the author for books[0]  Author的查询sql在执行这段代码时才执行，在Books的查询sql中并没有执行
            //}
            ////延迟加载需要多个数据库行程，因为在每次检索相关实体时 EF 都会发送一个查询。 通常，您希望为您序列化的对象禁用延迟加载。 序列化程序必须读取模型上的所有属性，这将触发加载相关实体
            ////有时可能需要使用延迟加载。 预先加载可能会导致 EF 生成非常复杂的联接。 或者，可能需要一小部分数据的相关实体，延迟加载会更有效。
            ////避免序列化问题的一种方法是序列化数据传输对象（Dto）而不是实体对象。
            ////为序列化关闭延迟加载
            ////延迟加载和序列化不会很好地混合，如果您不小心，只是因为启用了延迟加载，最终就可以对整个数据库进行查询。 大多数序列化程序通过访问类型实例上的每个属性来工作。 属性访问会触发延迟加载，因此会序列化更多的实体。 
            ////在这些实体上，将访问这些实体的属性，甚至还会加载更多实体。 在对实体进行序列化之前，最好关闭延迟加载
            ////延迟加载序列化问题； 会触发延迟加载；Author也将序列化到json中   //可以Author导航属性关闭延迟加载。关闭所有实体的延迟加载：在dbcontext上下文对象构造函数中添加this.Configuration.LazyLoadingEnabled = false;或在导航属性去掉virtual修饰

            ////延迟加载也有其他好处：1动态拼接sql；2读取最新数据（在语句确定后，数据加载前，数据发生变化将被读取到）


            ////显式加载：即使已禁用延迟加载，仍可能会延迟加载相关实体，但必须通过显式调用来完成此操作。 为此，请对相关实体的条目使用 Load 方法
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    context.Database.Log += c => Console.WriteLine(c);

            //    var b = context.Books.Find(1);
            //    context.Entry(b).Reference(s => s.Author).Load();
            //    Console.WriteLine(b.AuthorId);
            //}

            #endregion

            #region 插入数据自增id
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    Author author = new Author
            //    {
            //        Name = "xxx"
            //    };

            //    Book book1 = new Book()
            //    {
            //        Title = "xxx",
            //        Genre = "xxx",
            //        PublishDate = new DateTime(2000, 12, 16),
            //        Description ="xxx",
            //        Price = 14.95M
            //    };

            //    Book book2 = new Book()
            //    {
            //        Title = "yyy",
            //        Genre = "yyy",
            //        PublishDate = new DateTime(2000, 12, 16),
            //        Description = "yyy",
            //        Price = 14.95M
            //    };

            //    author.Books = new List<Book>() { book1, book2 };//主表和从表同时插入； 插入数据自增id
            //    context.Authors.Add(author);
            //    context.SaveChanges();//一次事务
            //}



            ////保存  TransactionScope是Window系统支持的DTC  可以支持一个context多次操作
            ////也可以支持多个context，甚至多个数据库(单机/局域网需要配置服务)
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    context.Database.Log += c => Console.WriteLine(c);
            //    using (TransactionScope trans = new TransactionScope())
            //    {

            //        Author author = new Author
            //        {
            //            Name = "zzz"
            //        };
            //        context.Authors.Add(author);
            //        context.SaveChanges();//author.id赋值了

            //        Book book1 = new Book()
            //        {
            //            Title = "zzz",
            //            Genre = "zzz",
            //            PublishDate = new DateTime(2000, 12, 16),
            //            Description = "zzz",
            //            Price = 14.95M,
            //            AuthorId = author.AuthorId,//要显示加外键值
            //        };
            //        context.Books.Add(book1);
            //        context.SaveChanges();//book1.id赋值了

            //        trans.Complete();//提交事务  不需要rollback
            //    }
            //}
            #endregion

            #region 主从级联删除 物理删除
            ////级联删除 就直接删主表, 数据库会自动把从表删了
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    var author = context.Authors.Find(12);
            //    context.Authors.Remove(author);
            //    context.SaveChanges();
            //}

            #endregion
        }

    }
}
