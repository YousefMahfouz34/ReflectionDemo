using System.Reflection;

namespace ReflectionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region obtining types 
            //Type t1 = DateTime.Now.GetType();             // Run time 
            //Type t2 = typeof(DateTime);                  //compile time
            //Console.WriteLine(t1);
            //Console.WriteLine(t2);
            //Type str = typeof(string);
            //string name = str.Name;
            //Type basetype = str.BaseType;
            //Assembly assembly = str.Assembly;
            //string fullname = str.FullName;

            //Console.WriteLine($"Name: {name}");
            //Console.WriteLine($"FullName: {fullname}");
            //Console.WriteLine($"BaseType: {basetype}");
            //Console.WriteLine($"Assembly: {assembly}"); 
            #endregion
            #region Instantiating Types
            //int i = (int)Activator.CreateInstance(typeof(int));
            //i = 20;
            //DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime),2020,1,1);
            //Console.WriteLine(i);
            //Console.WriteLine(dt.Year);
            //do
            //{
            //    var type = typeof(Program).Assembly.GetName().Name;
            //    var input= type.ToString()+"." + Console.ReadLine();
                
            //    object obj=null;
            //    try
            //    {
            //        var enemy = Activator.CreateInstance(type,input);
            //        obj= enemy.Unwrap();
            //    }
            //    catch
            //    {
            //    }
            //    switch (obj) 
            //    {
            //        case Goon goon:
            //            Console.WriteLine(goon);
            //            break;
            //        case Agar agar:
            //            Console.WriteLine(agar);
            //            break;
            //        case pixa pixa:
            //            Console.WriteLine(pixa);
            //            break;
            //        default:
            //            Console.WriteLine("UnKnown Type");
            //            break;
            //    }
            //}
            //while (true);

            #endregion
            #region Generic Types
            //Type closed = typeof(List<int>);
            //List<int> closedlist = (List<int>)Activator.CreateInstance(closed); 
            //Type bound=typeof(List<>);
            ////List<int> boundlist=(List<int>)Activator.CreateInstance(bound); // Cannot create an instance of System.Collections.Generic.List`1[T]
            //                                                                // because Type.ContainsGenericParameters is true.
            //                                                                //the correct method to do this  use method  "MakeGenericType()"
            //Type unbound = typeof(List<>);
            //Type closed2 = unbound.MakeGenericType(typeof(int));
            //Console.WriteLine(closed2.FullName);
            #endregion

            #region invoke members
            //Console.WriteLine("MemmberInfo");
            //MemberInfo[] members= typeof(Empolyee).GetMembers();
            //foreach (var member in members) 
            //{
            //    Console.WriteLine(member);
            //}
            //Console.WriteLine("properityInfo");
            //PropertyInfo[] properties= typeof(Empolyee).GetProperties();
            //foreach (var property in properties)
            //{
            //    Console.WriteLine(property);
            //}
            //Console.WriteLine("FiledInfo");
            //FieldInfo[] fields = typeof(Empolyee).GetFields();
            //foreach (var field in fields)
            //{
            //    Console.WriteLine(field);
            //}
            //Generic 
            PropertyInfo unbound = typeof(IEnumerator<>).GetProperty("Current");            Console.WriteLine(unbound);            PropertyInfo closed = typeof(IEnumerator<int>).GetProperty("Current");            Console.WriteLine(closed);


            #endregion
            #region AssemblyReflection
            var path = @"D:\testasssamply\MOE.dll";
            var asembly = Assembly.LoadFile(path);
            var typs= asembly.GetTypes();
            foreach (var t in typs)
            {
                Console.WriteLine(t.Name);
                
            }

            #endregion



        }
    }
    public class Empolyee()
    {
        private int id;
        private string name;
        private int age;
        public int Id => id;
        public string Name => name;
        public int Age => age;
        public List<Empolyee> empolyees=new List<Empolyee>();
        public override string ToString()
        {
            return $"id: {Id} , name : {Name} ,Age :{Age}";
        }
        public Empolyee GetEmpolyee(int Id)
        {
            var emp=empolyees.FirstOrDefault(e => e.Id == Id);  
            return emp == null ? null : emp;    
        }

    }
    public class Goon 
    {
        public override string ToString()
        {
            return $"Speed :20  ,Rate :15";
        }
    }
    public class Agar
    {
        public override string ToString()
        {
            return $"Speed :40  ,Rate :14";
        }
    }
    public class pixa
    {
        public override string ToString()
        {
            return $"Speed :8  ,Rate :24";
        }
    }
}
