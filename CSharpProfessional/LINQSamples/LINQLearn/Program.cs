using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //QuerySyntaxTest();
                //Console.WriteLine("*****************************");
                //MethodSyntaxTest();
                //Console.WriteLine("*****************************");
                //WhereTest();
                //Console.WriteLine("*****************************");
                //OfTypeTest();
                //Console.WriteLine("*****************************");
                //OrderByTest();
                //Console.WriteLine("*****************************");
                //ThenByTest();
                //Console.WriteLine("*****************************");
                //GroupByTest();
                //Console.WriteLine("*****************************");
                //ToLookupTest();
                //Console.WriteLine("*****************************");
                JoinTest();
                Console.WriteLine("*****************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }

            public int StandardID { get; set; }
            public override string ToString()
            {
                return $"StudentID:{this.StudentID} StudentName:{this.StudentName} Age:{this.Age} StandardID:{this.StandardID}";
            }
        }

        class Standard
        {
            public int StandardID { get; set; }
            public string StandardName { get; set; }
            public override string ToString()
            {
                return $"StandardID:{this.StandardID} StandardName:{this.StandardName}";
            }
        }
        // string collection
        static IList<string> stringList = new List<string>() {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials" ,
                "Java"
            };
        // Student collection
        static IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13, StandardID = 1} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21, StandardID = 1} ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2} ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 },
                new Student() { StudentID = 6, StudentName = "Ram" , Age = 18 },
            };

        static IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
};


        #region LINQ Query Syntax; LINQ Method Syntax
        //有两种基本的方法可以为IEnumerable集合或IQueryable数据源编写LINQ查询。
        //查询语法或查询表达式语法：询语法类似于数据库的SQL(结构化查询语言)。
        //方法语法或方法扩展语法
        static void QuerySyntaxTest()//查询语法或查询表达式语法
        {
            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            // LINQ Query Syntax to find out teenager students
            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;
            foreach (var item in teenAgerStudent)
            {
                Console.WriteLine(item);
            }
        }

        static void MethodSyntaxTest()//方法语法或方法扩展语法;Where接收委托参数；lambda表达式
        {
            // LINQ Method Syntax
            var result = stringList.Where(s => s.Contains("Tutorials"));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // LINQ Method Syntax to find out teenager students
            var teenAgerStudent = studentList.Where(s => s.Age > 12 && s.Age < 20);
            foreach (var item in teenAgerStudent)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region Query Operators  
        static void WhereTest()
        {
            // //可以在一个LINQ查询中多次调用Where()扩展方法。
            //var filteredResult = from s in studentList
            //                     where s.Age > 12
            //                     where s.Age < 20
            //                     select s;
            var filteredResult = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);
            foreach (var item in filteredResult)
            {
                Console.WriteLine(item);
            }
        }

        static void OfTypeTest()
        {
            //OfType操作符根据将集合中的元素强制转换为指定类型对集合进行筛选
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>()
                               select s;

            var intResult = from s in mixedList.OfType<int>()
                            select s;

            foreach (var item in stringResult)
            {
                Console.WriteLine(item);
            }
            foreach (var item in intResult)
            {
                Console.WriteLine(item);
            }
        }

        static void OrderByTest()
        {
            //排序
            //var orderByResult = from s in studentList
            //                    orderby s.StudentName
            //                    select s;
            //var orderByDescendingResult = from s in studentList
            //                    orderby s.StudentName descending
            //                    select s;
            var orderByResult = studentList.OrderBy(s => s.StudentName);
            var orderByDescendingResult = studentList.OrderByDescending(s => s.StudentName);
            foreach (var item in orderByResult)
            {
                Console.WriteLine(item);
            }
            foreach (var item in orderByDescendingResult)
            {
                Console.WriteLine(item);
            }
        }
  
        static void ThenByTest()
        {
            //OrderBy()方法根据指定的字段按升序对集合进行排序。在OrderBy之后使用ThenBy()方法在另一个字段上按升序对集合排序。
            //Linq将首先根据OrderBy方法指定的主字段对集合进行排序，然后再根据ThenBy方法指定的次字段对结果集合进行升序排序。
            var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);
            var thenByDescResult = studentList.OrderByDescending(s => s.StudentName).ThenByDescending(s => s.Age);
            foreach (var item in thenByResult)
            {
                Console.WriteLine(item);
            }
            foreach (var item in thenByDescResult)
            {
                Console.WriteLine(item);
            }
        }

        static void GroupByTest()
        {

            //分组操作符执行与SQL查询的GroupBy子句相同的操作。分组操作符根据给定的键创建一组元素。
            //这个组包含在一个特殊类型的集合中，该集合实现了一个IGrouping<TKey,TSource>接口，其中TKey是一个键值，在这个键值上形成了组，而TSource是与分组键值匹配的元素的集合。
            var groupedResult = studentList.GroupBy(s => s.Age);          
            foreach (var item in groupedResult)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i.StudentName);
                } 
            }
        }
        //GroupBy & ToLookup返回一个集合，该集合具有一个键和一个基于键字段值的内部集合。
        static void ToLookupTest()
        {
            //ToLookup和GroupBy是一样的;唯一的区别是GroupBy的执行是延迟的，而ToLookup的执行是立即的。
            var lookupResult = studentList.GroupBy(s => s.Age);
            foreach (var item in lookupResult)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i.StudentName);
                }
            }
        }

        //Join操作符操作两个集合:内部集合和外部集合。
        //它返回一个新集合，其中包含满足指定表达式的两个集合中的元素。它与SQL的内连接相同。
        static void JoinTest()
        {
            var innerJoin = studentList.Join(// outer sequence 
                standardList, // inner sequence 
                student => student.StandardID, // outerKeySelector
                standard => standard.StandardID,// innerKeySelector
                (student, standard) => new// result selector
                {
                    StudentName = student.StudentName,
                    StandardName = standard.StandardName
                });

            //Join operator in query syntax C#
            var queryInnerJoin = from s in studentList // outer sequence
                            join st in standardList //inner sequence 
                            on s.StandardID equals st.StandardID // key selector 
                            select new
                            { // result selector 
                                StudentName = s.StudentName,
                                StandardName = st.StandardName
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"StudentName:{item.StudentName} StandardName:{item.StandardName}");
            }
        }

        #endregion
    }
}
