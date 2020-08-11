using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst1.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }//Book中已经有Author的属性，在这Author添加Book属性将出现循环引用导致在序列化模型时出现问题
    }
}
