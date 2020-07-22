using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<FirstWebApiEntities>//使用db first当数据模型改变时重新创建数据库并播种（数据库原始数据）
    {
        protected override void Seed(FirstWebApiEntities context)
        {
            var Authors = new List<Author>
            {
                new Author() { Name = "Ralls, Kim" },
                new Author() { Name = "Corets, Eva" },
                new Author() { Name = "Randall, Cynthia" },
                new Author() { Name = "Thurman, Paula" }
            };
            var Books = new List<Book>
            {
                new Book() { Title= "Midnight Rain", Genre = "Fantasy",
                PublishDate = new DateTime(2000, 12, 16), AuthorId = 1, Description =
                "A former architect battles an evil sorceress.", Price = 14.95M },

                new Book() { Title = "Maeve Ascendant", Genre = "Fantasy",
                    PublishDate = new DateTime(2000, 11, 17), AuthorId = 2, Description =
                    "After the collapse of a nanotechnology society, the young" +
                    "survivors lay the foundation for a new society.", Price = 12.95M },

                new Book() { Title = "The Sundered Grail", Genre = "Fantasy",
                    PublishDate = new DateTime(2001, 09, 10), AuthorId = 2, Description =
                    "The two daughters of Maeve battle for control of England.", Price = 12.95M },

                new Book() { Title = "Lover Birds", Genre = "Romance",
                    PublishDate = new DateTime(2000, 09, 02), AuthorId = 3, Description =
                    "When Carla meets Paul at an ornithology conference, tempers fly.", Price = 7.99M },

                new Book() { Title = "Splish Splash", Genre = "Romance",
                    PublishDate = new DateTime(2000, 11, 02), AuthorId = 4, Description =
                    "A deep sea diver finds true love 20,000 leagues beneath the sea.", Price = 6.99M},
            };
            context.Authors.AddRange(Authors);
            context.Books.AddRange(Books);

            base.Seed(context);


            //context.Authors.AddOrUpdate(new Author[] {
            //    new Author() { Name = "Ralls, Kim" },
            //    new Author() { Name = "Corets, Eva" },
            //    new Author() { Name = "Randall, Cynthia" },
            //    new Author() { Name = "Thurman, Paula" }
            //});

            //context.Books.AddOrUpdate(new Book[] {
            //    new Book() { Title= "Midnight Rain", Genre = "Fantasy",
            //    PublishDate = new DateTime(2000, 12, 16), AuthorId = 1, Description =
            //    "A former architect battles an evil sorceress.", Price = 14.95M },

            //    new Book() { Title = "Maeve Ascendant", Genre = "Fantasy",
            //        PublishDate = new DateTime(2000, 11, 17), AuthorId = 2, Description =
            //        "After the collapse of a nanotechnology society, the young" +
            //        "survivors lay the foundation for a new society.", Price = 12.95M },

            //    new Book() { Title = "The Sundered Grail", Genre = "Fantasy",
            //        PublishDate = new DateTime(2001, 09, 10), AuthorId = 2, Description =
            //        "The two daughters of Maeve battle for control of England.", Price = 12.95M },

            //    new Book() { Title = "Lover Birds", Genre = "Romance",
            //        PublishDate = new DateTime(2000, 09, 02), AuthorId = 3, Description =
            //        "When Carla meets Paul at an ornithology conference, tempers fly.", Price = 7.99M },

            //    new Book() { Title = "Splish Splash", Genre = "Romance",
            //        PublishDate = new DateTime(2000, 11, 02), AuthorId = 4, Description =
            //        "A deep sea diver finds true love 20,000 leagues beneath the sea.", Price = 6.99M},
            //});

            //base.Seed(context);
        }
    }
}