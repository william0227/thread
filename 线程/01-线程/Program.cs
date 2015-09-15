using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _01_线程
{
    public class Person
    {
       public string Name
        {
            get;
            set;
        }

       public int Age
        {
            get;
            set;
        }
    }


    public class Message
    {
        public void ShowMessage(object person)
        {

            if (person != null)
             {
                 Person _person = (Person)person;           //将object类型的参数转换为Person类型

                 string message = string.Format("\n{0}'s age is {1}!\nAsync threadId is:{2}",
                     _person.Name,_person.Age,Thread.CurrentThread.ManagedThreadId);
                 Console.WriteLine(message);                //显示当前进程的信息
             }

             for (int n = 0; n < 10; n++)
             {
                 Thread.Sleep(100);     //线程挂起100ms
                 Console.WriteLine("Now the number is:" + n.ToString());        
            }
         }


        
    }
    class Program
    {
        
        static void Main(string[] args)
        {
           Console.WriteLine("Main threadId is:"+ Thread.CurrentThread.ManagedThreadId);  //显示主线程ID

            Person person = new Person();       //生成一个对象
            person.Name = "Jack";
            person.Age = 21;


            //ParameterizedThreadStart委托是面向带参数方法的
           Message message = new Message();
           Thread thread = new Thread(new ParameterizedThreadStart(message.ShowMessage));

           thread.IsBackground = true;              //设置为后台程序

           
           thread.Start(person);            //带参数启动线程
           Console.WriteLine("Do something .....");
           Console.WriteLine("Main thread working is complete!!");
           Console.WriteLine("Main thread sleep!");

           //主线程在异步线程运行结束后才会终止
           thread.Join(); 

           //Console.ReadKey();



        }


       

    }


}
