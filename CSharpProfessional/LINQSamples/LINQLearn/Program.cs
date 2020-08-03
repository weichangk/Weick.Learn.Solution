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
                //JoinTest();
                //Console.WriteLine("*****************************");
                //GroupJoinTest();
                //Console.WriteLine("*****************************");
                //AllAnyContainsTest();
                //Console.WriteLine("*****************************");
                //AggregationTest();
                //Console.WriteLine("*****************************");
                //ElementTest();
                //Console.WriteLine("*****************************");
                //SequenceEqualTest();
                //Console.WriteLine("*****************************");
                //ConcatTest();
                //Console.WriteLine("*****************************");
                //DefaultIfEmptyTest();
                //Console.WriteLine("*****************************");
                //GenerationTest();
                //Console.WriteLine("*****************************");
                //SetTest();
                //Console.WriteLine("*****************************");
                //PartitioningTest();
                //Console.WriteLine("*****************************");
                //ConversionTest();
                //Console.WriteLine("*****************************");
                ComplexTest();
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

        class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (x.StudentID == y.StudentID &&
                            x.StudentName.ToLower() == y.StudentName.ToLower())
                    return true;

                return false;
            }

            public int GetHashCode(Student obj)
            {
                return obj.GetHashCode();
            }
        }

        class StudentComparer1 : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (x.StudentID == y.StudentID
                        && x.StudentName.ToLower() == y.StudentName.ToLower())
                    return true;

                return false;
            }

            public int GetHashCode(Student obj)
            {
                return obj.StudentID.GetHashCode();
            }
        }

        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
            Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        }

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

        static void ToLookupTest()
        {
            //GroupBy & ToLookup返回一个集合，该集合具有一个键和一个基于键字段值的内部集合。
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

        static void JoinTest()
        {
            //Join操作符操作两个集合:内部集合和外部集合。
            //它返回一个新集合，其中包含满足指定表达式的两个集合中的元素。它与SQL的内连接相同。
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

        static void GroupJoinTest()
        {
            //GroupJoin操作符根据键连接两个序列，并返回序列组。它类似于SQL的左外连接。
            //GroupJoin操作符执行与Join操作符相同的任务，只是GroupJoin根据指定的组键在组中返回结果。
            //GroupJoin操作符根据键连接两个序列，并通过匹配键对结果进行分组，然后返回分组后的结果和键的集合。
            var groupJoin = standardList.GroupJoin(studentList,  //inner sequence
                                            std => std.StandardID, //outerKeySelector 
                                            s => s.StandardID,     //innerKeySelector
                                            (std, studentsGroup) => new // resultSelector 
                                            {
                                                Students = studentsGroup,
                                                StandarFulldName = std.StandardName
                                            });


            var groupJoin1 = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID
                            into studentGroup
                            select new
                            {
                                Students = studentGroup,
                                StandardName = std.StandardName
                            };

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);
                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }
        }

        static void AllAnyContainsTest()
        {
            //All 检查序列中的所有元素是否满足指定条件
            //Any 检查序列中的任何元素是否满足指定条件
            //Contains 检查序列是否包含特定元素
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine(areAllStudentsTeenAger);

            bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine(isAnyStudentTeenAger);

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            bool result = studentList.Contains(std, new StudentComparer()); //returns true
            Console.WriteLine(result);
        }

        static void AggregationTest()
        {
            //聚合操作符对集合中元素的数值属性执行数学操作，如平均、聚合、计数、最大值、最小值和总和。
            //Aggregate 对集合中的值执行自定义聚合操作。
            //Average 计算集合中数值项的平均值。
            //Count 对集合中的元素进行计数。
            //LongCount 对集合中的元素进行计数。
            //Max Min查找集合中的最大值，最小值。
            //Sum 计算集合中值的和。
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);
            Console.WriteLine(commaSeperatedString);

            string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
                                        "Student Names: ",  // seed value
                                        (str, s) => str += s.StudentName + ",");
            Console.WriteLine(commaSeparatedStudentNames);

            var avgAge = studentList.Average(s => s.Age);
            Console.WriteLine("Average Age of Student: {0}", avgAge);

            var totalStudents = studentList.Count();
            Console.WriteLine("Total Students: {0}", totalStudents);
            var adultStudents = studentList.Count(s => s.Age >= 18);
            Console.WriteLine("Number of Adult Students: {0}", adultStudents);

            var oldest = studentList.Max(s => s.Age);
            Console.WriteLine("Oldest Student Age: {0}", oldest);

            var sumOfAge = studentList.Sum(s => s.Age);
            Console.WriteLine("Sum of all student's age: {0}", sumOfAge);
        }

        static void ElementTest()
        {
            //元素操作符从序列(集合)中返回一个特定的元素。
            //ElementAt 返回集合中指定索引处的元素
            //ElementAtOrDefault 返回集合中指定索引处的元素，如果索引超出范围，则返回默认值。
            //First 返回集合的第一个元素，或满足条件的第一个元素。
            //FirstOrDefault 返回集合的第一个元素，或满足条件的第一个元素。如果索引超出范围，返回默认值。
            //Last 返回集合的最后一个元素，或满足条件的最后一个元素
            //LastOrDefault 返回集合的最后一个元素，或满足条件的最后一个元素。如果不存在这样的元素，则返回默认值。
            //Single 返回集合中唯一的元素，或唯一满足条件的元素。
            //SingleOrDefault 返回集合中唯一的元素，或唯一满足条件的元素。如果不存在这样的元素，或者集合不包含恰好一个元素，则返回默认值。
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };
            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intList.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strList.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value",intList.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",strList.ElementAtOrDefault(9));

            Console.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
            Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine(intList.ElementAt(9));

            IList<string> emptyList = new List<string>();
            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",intList.FirstOrDefault(i => i % 2 == 0));
            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());
            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());
            //Console.WriteLine("1st Element which is greater than 250 in intList: {0}",intList.First(i => i > 250));
            //Console.WriteLine("1st Even Element in intList: {0}",strList.FirstOrDefault(s => s.Contains("F")));

            IList<int> oneElementList = new List<int>() { 7 };
            Console.WriteLine("The only element in oneElementList: {0}", oneElementList.Single());
            Console.WriteLine("The only element in oneElementList: {0}",oneElementList.SingleOrDefault());
            Console.WriteLine("Element in emptyList: {0}", emptyList.SingleOrDefault());
            //Console.WriteLine("The only element which is less than 10 in intList: {0}",intList.Single(i => i < 10));
        }

        static void SequenceEqualTest()
        {
            //只有一个相等运算符:SequenceEqual。SequenceEqual方法检查两个集合中元素的数量、每个元素的值和元素的顺序是否相等。
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
            IList<string> strList2 = new List<string>() { "Two", "One", "Three", "Four", "Three" };
            bool isEqual = strList1.SequenceEqual(strList2); // returns false
            Console.WriteLine(isEqual);

            IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            // following returns true
            bool StudentisEqual = studentList1.SequenceEqual(studentList2, new StudentComparer());
            Console.WriteLine(StudentisEqual);
        }

        static void ConcatTest()
        {
            //Concat()方法附加相同类型的两个序列，并返回一个新的序列(集合)。
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Three", "Five", "Six" };
            var collection3 = collection1.Concat(collection2);
            foreach (string str in collection3)
                Console.WriteLine(str);
        }

        static void DefaultIfEmptyTest()
        {
            //如果调用DefaultIfEmpty()的给定集合为空，则DefaultIfEmpty()方法返回一个具有默认值的新集合。
            IList<string> emptyList = new List<string>();
            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine("Count: {0}", newList1.Count());
            Console.WriteLine("Value: {0}", newList1.ElementAt(0));

            Console.WriteLine("Count: {0}", newList2.Count());
            Console.WriteLine("Value: {0}", newList2.ElementAt(0));
        }
       
        static void GenerationTest()
        {
            ////LINQ包括生成操作符DefaultIfEmpty, Empty, Range & Repeat。Empty、Range和Repeat方法不是IEnumerable或IQueryable方法，但它们只是静态类Enumerable中定义的静态方法。
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();
            Console.WriteLine("Count: {0} ", emptyCollection1.Count());
            Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);
            Console.WriteLine("Count: {0} ", emptyCollection2.Count());
            Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);

            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());
            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));

            var intCollection1 = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection1.Count());
            for (int i = 0; i < intCollection1.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection1.ElementAt(i));
        }

        static void SetTest()
        {
            //Distinct 从集合返回不同的值。
            //Except 返回两个序列之间的差值，这意味着一个集合的元素没有出现在第二个集合中。
            //Intersect 返回两个序列的交集，即同时出现在两个集合中的元素。
            //Union 返回两个序列中的唯一元素，这意味着出现在两个序列中的唯一元素。
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };
            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };
            var distinctList1 = strList.Distinct();
            foreach (var str in distinctList1)
                Console.WriteLine(str);
            Console.WriteLine();

            var distinctList2 = intList.Distinct();
            foreach (var i in distinctList2)
                Console.WriteLine(i);
            Console.WriteLine();

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var distinctStudents = studentList.Distinct(new StudentComparer1());
            foreach (Student std in distinctStudents)
                Console.WriteLine(std.StudentName);
            Console.WriteLine();

            IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var ExceptresultedCol = studentList1.Except(studentList2, new StudentComparer1());
            foreach (Student std in ExceptresultedCol)
                Console.WriteLine(std.StudentName);
            Console.WriteLine();

            var IntersectresultedCol = studentList1.Intersect(studentList2, new StudentComparer1());
            foreach (Student std in IntersectresultedCol)
                Console.WriteLine(std.StudentName);
            Console.WriteLine();

            var UnionresultedCol = studentList1.Union(studentList2, new StudentComparer1());
            foreach (Student std in UnionresultedCol)
                Console.WriteLine(std.StudentName);
        }

        static void PartitioningTest()
        {
            //分区操作符将序列(集合)分成两个部分并返回其中一个部分。
            //Skip 从序列中的第一个元素开始跳过元素到指定位置。
            //SkipWhile 根据条件跳过元素，直到某个元素不满足该条件。如果第一个元素本身不满足条件，那么它将跳过0个元素并返回序列中的所有元素。
            //Take 获取从序列中的第一个元素开始一直到指定位置的元素。
            //TakeWhile 返回第一个元素中的元素，直到某个元素不满足条件为止。如果第一个元素本身不满足条件，则返回一个空集合。
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            var newList = strList.Skip(2);
            foreach (var str in newList)
                Console.WriteLine(str);
            Console.WriteLine();

            IList<string> SkipWhilestrList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Threeeeee",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = SkipWhilestrList.SkipWhile((s, i) => s.Length > i);
            foreach (string str in resultList)
                Console.WriteLine(str);
            Console.WriteLine();

            var TakenewList = strList.Take(2);
            foreach (var str in TakenewList)
                Console.WriteLine(str);
            Console.WriteLine();

            var TakeWhileresultList = strList.TakeWhile((s, i) => s.Length > i);
            foreach (string str in TakeWhileresultList)
                Console.WriteLine(str);

        }

        static void ConversionTest()
        {
            //LINQ中的转换运算符在转换序列(集合)中的元素类型时非常有用。有三种类型的转换操作符:As操作符(可枚举的和可查询的)、To操作符(ToArray、ToDictionary、ToList和ToLookup)和Casting操作符(Cast和OfType)。
            //AsEnumerable 以IEnumerable<t>的形式返回输入序列
            //AsQueryable  将IEnumerable转换为IQueryable，以模拟远程查询提供程序
            //Cast 将非泛型集合转换为泛型集合(IEnumerable to IEnumerable<T>)
            //OfType 根据指定的类型筛选集合
            //ToArray 将集合转换为数组
            //ToDictionary 根据键选择器函数将元素放入字典中
            //ToList 将集合转换为列表
            //ToLookup 将元素分组到Lookup<TKey,TElement> 

            Student[] studentArray = {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            };

            ReportTypeProperties(studentArray);
            ReportTypeProperties(studentArray.AsEnumerable());
            ReportTypeProperties(studentArray.AsQueryable());
            Console.WriteLine();
            ReportTypeProperties(studentArray);
            ReportTypeProperties(studentArray.Cast<Student>());

            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Three"
                                            };
            string[] strArray = strList.ToArray<string>();// converts List to Array
            foreach (var item in strArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            IList<string> list = strArray.ToList<string>(); // converts array into list
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
                };
            //following converts list into dictionary where StudentId is a key
            IDictionary<int, Student> studentDict =
                                            studentList.ToDictionary<Student, int>(s => s.StudentID);

            foreach (var key in studentDict.Keys)
                Console.WriteLine("Key: {0}, Value: {1}",
                                            key, (studentDict[key] as Student).StudentName);
        }

        static void ComplexTest()
        {
            //一些复杂的LINQ查询

            //多重Select和where操作符
            var studentNames = studentList.Where(s => s.Age > 18)
                              .Select(s => s)
                              .Where(st => st.StandardID > 0)
                              .Select(s => s.StudentName);
            foreach (var item in studentNames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var teenStudentsName = from s in studentList
                                   where s.Age > 12 && s.Age < 20
                                   select new { StudentName = s.StudentName };

            teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));
            Console.WriteLine();

            //Group By
            var studentsGroupByStandard = from s in studentList
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };


            foreach (var group in studentsGroupByStandard)
            {
                Console.WriteLine("StandardID {0}:", group.Key);
                group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
            Console.WriteLine();

            var studentsGroupByStandard1 = from s in studentList
                                          where s.StandardID > 0
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };

            //Left outer join
            var studentsGroup = from stad in standardList
                                join s in studentList
                                on stad.StandardID equals s.StandardID
                                    into sg
                                select new
                                {
                                    StandardName = stad.StandardName,
                                    Students = sg
                                };

            foreach (var group in studentsGroup)
            {
                Console.WriteLine(group.StandardName);
                group.Students.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
            Console.WriteLine();

            //Sorting
            var sortedStudents = from s in studentList
                                 orderby s.StandardID, s.Age
                                 select new
                                 {
                                     StudentName = s.StudentName,
                                     Age = s.Age,
                                     StandardID = s.StandardID
                                 };
            sortedStudents.ToList().ForEach(s => Console.WriteLine("Student Name: {0}, Age: {1}, StandardID: {2}", s.StudentName, s.Age, s.StandardID));
            Console.WriteLine();

            //Nested Query
            var nestedQueries = from s in studentList
                                where s.Age > 18 && s.StandardID ==
                                    (from std in standardList
                                     where std.StandardName == "Standard 1"
                                     select std.StandardID).FirstOrDefault()
                                select s;

            nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));
        }
        #endregion
    }
}
