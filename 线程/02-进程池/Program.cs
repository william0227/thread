using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_进程池
{
    class Program
    {
        static void Main(string[] args)
        {
            //把线程池的最大值设为1000
            ThreadPool.SetMaxThreads(1000, 1000);

            //显示主线程启动时的线程池信息
            ThreadMessage("Start");

            //启动工作者线程池
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncCallback),"Hello Wrold !");

            Console.ReadKey();


        }


        //异步线程
        static void AsyncCallback(object state)
        {
            string data = (string)state;
            Thread.Sleep(500);
            ThreadMessage("AsyncCallback");
            Console.WriteLine("Async thread do work!\n{0}",data);

        }

        //显示进程现状
        static void ThreadMessage(string data)
        {
            string message = string.Format("{0}\n  CurrentThreadId is {1}", data, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);

        }


    }
}
