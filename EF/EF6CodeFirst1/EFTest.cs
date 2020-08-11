using EF6CodeFirst1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst1
{
    public class EFTest
    {
        public static void Show()
        {
            #region 基础的增删改查 延迟查询

            using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            {
                //Book Book1 = context.Books.Find(1);//即时查询

                //var BookList = context.Books.Where(u => u.BookId > 0);
                ////延时查询：必须是IQueryable类型   里面其实是一个表达式目录树(数据结构，可以翻译成sql，)这时候并没执行到数据库， 真的要用数据的时候(遍历/ToList()/Count())，就会去查询       

                //var BookList1 = BookList.ToList();//执行查询// //IEnumrable的Where也是延时，那个是基于迭代器延迟  linq to object

                //foreach (var item in BookList)
                //{
                //    Console.WriteLine(item.Title);
                //}

                //Book1.Description += "test";
                //context.SaveChanges();//把context全部的变化更新到数据库

                //Book Book2 = context.Books.FirstOrDefault(u => u.BookId == 2);//针对数据库查询

                //new List<int>().FirstOrDefault(i => i > 10);//针对内存数据的linq to object




                //Author author = new Author()
                //{
                //    Name = "李白"
                //};
                //context.Authors.Add(author);
                //context.SaveChanges();//自增主键在插入成功后，会自动赋值过去
                //context.Authors.Remove(author);
                //context.SaveChanges();//本身就是一个事务

            }

            #endregion

            #region 其他查询
            using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            {
                //var list = context.Authors.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.AuthorId));//in查询
                //list = list.Where(v => v.AuthorId < 5);
                //list = list.OrderBy(v => v.AuthorId);
                ////3次 只会跟数据库交互一次 为什么要延迟查询? 可以用来拼接查询语句
                ////tolist 就会大量加载数据  再过滤操作
                //foreach (var user in list)
                //{
                //    Console.WriteLine(user.Name);
                //}

                {
                    //    //没有任何差别，只有写法上的熟悉
                    //    var list1 = from u in context.Authors
                    //               where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.AuthorId)
                    //               select u;

                    //    foreach (var item in list1)
                    //    {
                    //        Console.WriteLine(item.Name);
                    //    }
                }

                {
                    //var list2 = context.Authors.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.AuthorId))
                    //                          .OrderBy(u => u.AuthorId)
                    //                          .Select(u => new
                    //                          {
                    //                              id = u.AuthorId,
                    //                              firstname = u.Name
                    //                          }).Skip(2).Take(5);
                    //foreach (var item in list2)
                    //{
                    //    Console.WriteLine(item.firstname);
                    //}
                }

                {
                    //var list3 = from a in context.Authors
                    //            where new int[] { 1, 2, 3, 4 }.Contains(a.AuthorId)
                    //            orderby a.AuthorId
                    //            select new
                    //            {
                    //                id = a.AuthorId,
                    //                firstname = a.Name
                    //            };
                    //foreach (var item in list3)
                    //{
                    //    Console.WriteLine(item.id);
                    //}
                }

                {
                    //var list4 = context.Authors.Where(u => u.Name.StartsWith("R") && u.Name.EndsWith("a"))
                    //                           .Where(u => u.Name.EndsWith("a"))
                    //                           .Where(u => u.Name.Contains("Ran"))
                    //                           .Where(u => u.Name.Length < 100)
                    //                           .OrderBy(u => u.AuthorId);

                    //foreach (var item in list4)
                    //{
                    //    Console.WriteLine(item.Name);
                    //}
                }

                {
                    //var list5 = from a in context.Authors
                    //            join b in context.Books on a.AuthorId equals b.AuthorId
                    //            where new int[] { 1, 2 ,3,4,5,6,7,8}.Contains(b.BookId)
                    //            select new
                    //            {
                    //                bookid = b.BookId,
                    //                aid = a.AuthorId,
                    //                bookname = b.Title,
                    //                aname = a.Name
                    //            };
                    //foreach (var item in list5)
                    //{
                    //    Console.WriteLine($"aname:{item.aname}  bookname:{item.bookname}");
                    //}
                }

                {
                    //var list6 = from a in context.Authors
                    //            join b in context.Books 
                    //            on a.AuthorId equals b.AuthorId
                    //            into temp
                    //            select new
                    //            {
                    //                BooksTemp = temp,
                    //                AuthorsName = a.Name
                    //            };
                    //foreach (var item in list6)
                    //{
                    //    Console.WriteLine(item.AuthorsName);
                    //    foreach (var b in item.BooksTemp)
                    //        Console.WriteLine(b.Description);
                    //}

                }

                {
                    //DbContextTransaction trans = null;
                    //try
                    //{
                    //    trans = context.Database.BeginTransaction();
                    //    string sql = "Update [Authors] Set Name='小新' WHERE AuthorId=@Id";
                    //    SqlParameter parameter = new SqlParameter("@Id", 7);
                    //    context.Database.ExecuteSqlCommand(sql, parameter);
                    //    trans.Commit();
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (trans != null)
                    //    {
                    //        trans.Rollback();
                    //        throw ex;
                    //    }
                    //}
                    //finally
                    //{
                    //    trans.Dispose();
                    //}
                }

                {
                    //DbContextTransaction trans = null;
                    //try
                    //{
                    //    trans = context.Database.BeginTransaction();
                    //    string sql = "SELECT * FROM [Authors] WHERE AuthorId=@Id";
                    //    SqlParameter parameter = new SqlParameter("@Id", 1);
                    //    List<Author> AuthorsList = context.Database.SqlQuery<Author>(sql, parameter).ToList<Author>();
                    //    trans.Commit();
                    //    foreach (var item in AuthorsList)
                    //    {
                    //        Console.WriteLine(item.Name);
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (trans != null) trans.Rollback();
                    //    throw ex;
                    //}
                    //finally
                    //{
                    //    trans.Dispose();
                    //}
                }
            }
            #endregion

            #region 其他的增删改
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    Author author = new Author()
            //    {
            //        Name = "李白白"
            //    };//直接外部实例化了一个数据
            //    context.Authors.Add(author);
            //    context.SaveChanges();//自增主键在插入成功后，会自动赋值过去
            //    author.Name += 1;//可以直接修改对象数据同步到数据库
            //    context.SaveChanges();//更新 删除都没问题
            //}


            //context实例会跟踪数据(插入/查询) 修改过就会有个状态变化
            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    Author author = new Author()
            //    {
            //        AuthorId = 1,
            //        Name = "Ralls, Kim"
            //    };//直接外部实例化了一个数据

            //    context.Authors.Attach(author);//直接保存无效 Attach一下,附加之后就可以监控
            //    author.Name += 2;//可以直接修改对象数据同步到数据库
            //    context.SaveChanges();//更新 删除都没问题

            //    author.Name = "Ralls, Kim";//可以直接修改对象数据同步到数据库
            //    context.SaveChanges();//更新 删除都没问题
            //}

            //using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            //{
            //    Author author = new Author()
            //    {
            //        AuthorId = 1,
            //        Name = "Ralls, Kim"
            //    };
            //    author = context.Authors.Find(author.AuthorId);//可以查询实现状态跟踪；在状态被跟踪前修改对象不能SaveChanges到数据库
            //    author.Name += 2;//可以直接修改对象数据同步到数据库
            //    context.SaveChanges();//更新 删除都没问题

            //    author.Name = "Ralls, Kim";//可以直接修改对象数据同步到数据库
            //    context.SaveChanges();//更新 删除都没问题
            //}
            using (EFCodeFirst1Entities context = new EFCodeFirst1Entities())
            {
                Author author = new Author()
                {
                    AuthorId = 1,
                    Name = "Ralls, Kim"
                };
                author.Name += 2;
                context.Entry<Author>(author).State = EntityState.Modified;//可以直接修改对象数据同步到数据库
                context.SaveChanges();
                author.Name = "Ralls, Kim";
                context.Entry<Author>(author).Property<string>("Name").IsModified = true;//只更新某字段
                context.SaveChanges();
            }

            #endregion
        }
    }
}
