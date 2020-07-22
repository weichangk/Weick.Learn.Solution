using FirstWebApi.Models;
using FirstWebApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace FirstWebApi.Controllers
{
    //使用 ASP.NET Web API 2 中的特性路由创建 RESTful API
    //在设计 API 的 Uri 时，特性路由可提供更多控制和更大的灵活性。

    //添加路由属性
    //将控制器转换为使用属性路由。 首先，将RoutePrefix属性添加到控制器。 此属性定义此控制器上所有方法的初始 URI 段 api/bookssss。
    //然后将 [Route] 特性添加到控制器集体操作

    [RoutePrefix("api/bookssss")]
    public class BooksController : ApiController
    {
        Models.FirstWebApiEntities db = new Models.FirstWebApiEntities();

        //[HttpGet]
        //public IEnumerable<Book> GetEmployees()
        //{
        //    return db.Books.ToList();
        //}

        //[HttpGet]
        //public Book GetEmployee(int id)
        //{
        //    Book b = db.Books.Find(id);
        //    if (b == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return b;
        //}


        //创建表达式树对象返回特定子集对象BookDto（多表查询）
        private static readonly Expression<Func<Book, BookDto>> AsBookDto = x => new BookDto
        {
            Title = x.Title,
            Author = x.Author.Name,
            Genre = x.Genre
        };

        // GET api/bookssss
        [Route("")]
        public IQueryable<BookDto> GetBooks()
        {
            return db.Books.Include(b => b.Author).Select(AsBookDto);//无法将lamdba表达式转换为string类型，因为他不是委托类型。using System.Data.Entity;可解决。。。
        }

        // GET api/bookssss/1
        [Route("{id:int}")]//路由约束，参数为int类型
        [ResponseType(typeof(BookDto))]//指定返回实体类型
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDto book = await db.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .Select(AsBookDto)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //通过特性路由获取书籍详细信息
        [Route("{id:int}/details")]//api/bookssss/1/details
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


        //使用特性路由按流派获取书籍  /api/bookssss/fantasy      /api/bookssss/1将不会进来（因为上面有 [Route("{id:int}")]//路由约束，参数为int类型）
        [Route("{genre}")]
        public IQueryable<BookDto> GetBooksByGenre(string genre)
        {
            return db.Books.Include(b => b.Author)
                .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .Select(AsBookDto);
        }


        //使特性路由按作者获取书籍
        [Route("~/api/authors/{authorId:int}/books")]//路由模板中的波形符 (~) 会替代RoutePrefix属性中的路由前缀      /api/authors/1/books
        public IQueryable<BookDto> GetBooksByAuthor(int authorId)
        {
            return db.Books.Include(b => b.Author)
                .Where(b => b.AuthorId == authorId)
                .Select(AsBookDto);
        }


        ////////使用特性路由按发布日期获取书籍
        ////////        /api/bookssss/date/Thu, 01 May 2008
        ////////        /api/bookssss/date/2000-12-16T00:00:00
        //////[Route("date/{pubdate:datetime}")]

        ////////通过将正则表达式约束添加到路由模板，来限制特定日期格式的路由
        ////////[Route("date/{pubdate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]  //     /api/bookssss/date/2013/06/17
        //////public IQueryable<BookDto> GetBooks(DateTime pubdate)
        //////{
        //////    return db.Books.Include(b => b.Author)
        //////        .Where(b => DbFunctions.TruncateTime(b.PublishDate)
        //////            == DbFunctions.TruncateTime(pubdate))
        //////        .Select(AsBookDto);
        //////}
    }
}
