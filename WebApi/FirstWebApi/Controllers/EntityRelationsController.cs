using FirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FirstWebApi.Models.DTOs;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace FirstWebApi.Controllers
{
    //介绍EF如何加载相关实体，以及如何在模型类中处理循环导航属性
    //使用fiddler对api进行测试，再输出日志中查看sql语句验证预先加载、延迟加载和显式加载
    public class EntityRelationsController : ApiController
    {
        Models.FirstWebApiEntities db = new Models.FirstWebApiEntities();

        //api/EntityRelations
        public IQueryable<Book> GetBooks()//在返回的json数据中即使该书包含有效的作者Author 但Author 属性为 null。 这是因为 EF 未加载相关的作者实体。 可以查看SQL 查询的跟踪日志确认
        {
            return db.Books;
        }


        //我们来看看如何将作者Author返回为 JSON 数据的一部分。 有三种方法可以在实体框架中加载相关数据：预先加载、延迟加载和显式加载。


        //预先加载，则 EF 会将相关实体加载到初始数据库查询中。 若要执行预先加载，请使用system.web.Include扩展方法
        [HttpGet]
        [Route("api/EagerLoad")]
        public IQueryable<Book> EagerLoadGetBooks()
        {
            return db.Books.Include(b => b.Author);
        }


        //使用延迟加载，EF自动加载相关实体时，要启用延迟加载，请将实体对象的属性的导航属性设置为虚拟virtual：public virtual Author Author { get; set; }  //Virtual navigation property启用延迟加载
        [HttpGet]
        [Route("api/LazyLoad")]
        public IHttpActionResult LazyLoadGetBooks()
        {
            var books = db.Books.ToList();  // Does not load authors
            var author = books[0].Author;   // Loads the author for books[0]  Author的查询sql在执行这段代码时才执行，在Books的查询sql中并没有执行
            return Ok(author);
        }
        //延迟加载需要多个数据库行程，因为在每次检索相关实体时 EF 都会发送一个查询。 通常，您希望为您序列化的对象禁用延迟加载。 序列化程序必须读取模型上的所有属性，这将触发加载相关实体
        //有时可能需要使用延迟加载。 预先加载可能会导致 EF 生成非常复杂的联接。 或者，可能需要一小部分数据的相关实体，延迟加载会更有效。
        //避免序列化问题的一种方法是序列化数据传输对象（Dto）而不是实体对象。
        //为序列化关闭延迟加载
        //延迟加载和序列化不会很好地混合，如果您不小心，只是因为启用了延迟加载，最终就可以对整个数据库进行查询。 大多数序列化程序通过访问类型实例上的每个属性来工作。 属性访问会触发延迟加载，因此会序列化更多的实体。 
        //在这些实体上，将访问这些实体的属性，甚至还会加载更多实体。 在对实体进行序列化之前，最好关闭延迟加载
        [HttpGet]
        [Route("api/LazyLoad1")]
        public IHttpActionResult LazyLoadGetBooks1()
        {
            var books = db.Books.ToList();  
            return Ok(books);//延迟加载序列化问题； 会触发延迟加载；Author也将序列化到json中   //可以Author导航属性关闭延迟加载。关闭所有实体的延迟加载：在FirstWebApiEntities上下文对象构造函数中添加this.Configuration.LazyLoadingEnabled = false;
        }


        //显式加载：即使已禁用延迟加载，仍可能会延迟加载相关实体，但必须通过显式调用来完成此操作。 为此，请对相关实体的条目使用 Load 方法
        [HttpGet]
        [Route("api/ExplicitLoad")]
        public IHttpActionResult ExplicitLoadGetBooks()
        {
            var b = db.Books.Find(1);
            db.Entry(b).Reference(s => s.Author).Load();
            //db.Entry(b).Collection(s => s.Author).Load();

            return Ok();
        }


        //使用 Query 计算相关实体而不加载它们
        //有时，了解数据库中与另一个实体相关的实体的数量并不实际产生加载所有这些实体的成本是非常有用的。 带有 LINQ Count 方法的 Query 方法可用于执行此操作
        [HttpGet]
        [Route("api/QueryLoad")]
        public IHttpActionResult QueryLoadGetBooks()
        {
            var b = db.Books.Find(1);
            db.Entry(b).Reference(s => s.Author).Load();
            //db.Entry(b).Collection(s => s.Author).Load();

            var count = db.Entry(b)
                                   .Reference(a => a.Author)//Collection一对多时查记录
                                   .Query()
                                   .Count();

            return Ok(count);
        }


        //Author和Book属性中存在循环引用时。当 JSON 或 XML 格式化程序尝试序列化时，将引发异常。 这两个格式化程序引发不同的异常消息







        //web API 将数据库实体公开给客户端。 客户端接收直接映射到数据库表的数据。 但是，这并不总是一个好主意。 有时，您需要更改发送到客户端的数据的形状例如，你可能希望：
        //删除循环引用（请参阅上一节）。
        //隐藏客户端不应查看的特定属性。
        //省略某些属性以减小负载大小。
        //平展包含嵌套对象的对象图，以使它们更适合客户端。
        //避免出现 "过度发布" 漏洞。
        //将服务层与数据库层分离。

        //若要实现此目的，可以定义数据传输对象（DTO）如Models/DTOs/BookDetailDto 和 Models/DTOs/BookDto
        [HttpGet]
        [Route("api/LoadBookDto")]
        public IQueryable<BookDto> LoadBookDto()
        {
            var books = from b in db.Books
                        select new BookDto()
                        {
                            Title = b.Title,
                            Genre = b.Genre,
                            Author = b.Author.Name
                        };

            return books;
        }

        // GET api/LoadBookDetailDto/1
        [HttpGet]
        [Route("api/LoadBookDetailDto/{id:int}")]
        [ResponseType(typeof(BookDetailDto))]
        public async Task<IHttpActionResult> GetBookDetail(int id)
        {
            var book = await (from b in db.Books.Include(b => b.Author)
                              where b.BookId == id
                              select new BookDetailDto
                              {
                                  Title = b.Title,
                                  Genre = b.Genre,
                                  PublishDate = b.PublishDate,
                                  Price = b.Price,
                                  Description = b.Description,
                                  Author = b.Author.Name
                              }).FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
