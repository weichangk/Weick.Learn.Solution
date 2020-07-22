using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models.DTOs
{
    public class BookDto//为返回特定子集创建对象
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}