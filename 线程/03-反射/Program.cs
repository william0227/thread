using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;            //使用反射需要引用的命名空间


namespace _03_反射
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type tString = typeof(string);
            //Console.WriteLine(tString);
            //Type tInt = typeof(int);
            //Console.WriteLine(tInt);

            //string str = "apple";
            //Type t = str.GetType();
            //Console.WriteLine(t);
            //Console.ReadKey();

            string n = "grayworm";
            Type t = n.GetType();
            foreach (MemberInfo mi in t.GetMembers())
            {
                Console.WriteLine("{0}\t{1}", mi.MemberType, mi.Name);      //使用MethodInfo了解方法的名称、返回类型、参数、访问修饰符（如pulic 或private）和实现详细信息（如abstract或virtual）等。
            }

        }
    }
}
