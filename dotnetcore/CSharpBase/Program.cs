using System;
using CSharpBase.Struct;
using CSharpBase.Delegate;
using System.Threading.Tasks;
using CSharpBase.Async;
using System.Threading;
using CSharpBase.Lock;

namespace CSharpBase.Lock
{
    class MyLock
    {
        public static bool flg;
        public static Mutex mutex = new Mutex();
        public int count = 0;
        public void Task1()
        {
            for (var i = 0; i < 100000; ++i)
            {
                mutex.WaitOne();
                ++count;
                mutex.ReleaseMutex();

            }
        }

        public void Task2()
        {
            for (var i = 0; i < 100000; ++i)
            {
                mutex.WaitOne();
                ++count;
                mutex.ReleaseMutex();

            }
        }

        public async Task TestMutex()
        {
            var t1 = Task.Run(Task1);
            var t2 = Task.Run(Task2);
            await t1;
            await t2;
            Console.WriteLine(count);
        }

        public async Task TestAtomic()
        {
            await TestMutex();
            Console.WriteLine(count);
        }
    }
}
/// <summary>
/// 异步async/wait
/// </summary>
namespace CSharpBase.Async
{
    class MyAsync
    {
        public async Task<string> Task1()
        {
            Console.WriteLine("Task 1 ready to await...");
            var t2 = Task2();
            await Task.Delay(1000);
            Console.WriteLine("Task 1 completed.");
            await t2;
            return "Task1 completed.";
        }

        public async Task<string> Task2()
        {
            Console.WriteLine("Task 2 ready to await...");
            await Task.Delay(1000);
            Console.WriteLine("Task 2 completed.");
            return "Task2 completed.";
        }

        public async Task Test()
        {
            Console.WriteLine("Test ready...");
            var t1 = Task1();
            //var t2 = Task2();
            Console.WriteLine("Test completed.");
            await Task.WhenAll(t1);
        }

        public void TestThread()
        {
            var t1 = new Thread(() => {
                for (var i = 0; i < 10; ++i)
                    Console.WriteLine($"{i}");
            });
            t1.Start();

            Task.Run(() =>
            {
                for (var i = 10; i < 20; ++i)
                    Console.WriteLine($"{i}");
            }).Wait();
            t1.Join();
        }
    }
}

/// <summary>
/// 委托
/// </summary>
namespace CSharpBase.Delegate
{
    class MyDelegate
    {
        // 定义一个有返回值带参委托 
        public delegate double MathAction(double num);

        public double Double(double input)
        {
            Console.WriteLine(input * 2);
            return input * 2;
        }

        public double Trible(double input)
        {
            Console.WriteLine(input * 3);
            return input * 3;
        }

        public void Test()
        {
            MathAction ma = Double;
            ma += Trible;
            Console.WriteLine(ma.Invoke(1.0d));
        }
    }
}

/// <summary>
/// 值类型也可以实现接口
/// </summary>
namespace CSharpBase.Struct
{
    interface BaseInterface
    {
        void Print();
    }
    struct BaseStruct : BaseInterface
    {
        public int a;
        public int b;
        public void Print()
        {
            Console.WriteLine($"{a},{b}");
        }
    }
}

namespace CSharpBase
{

    class MainClass
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var bt = new BaseStruct { a = 1, b = 2 };
            //bt.Print();

            // 可以把方法直接作为值赋给委托引用 
            //var de = new MyDelegate();
            //de.Test();

            //var myas = new MyAsync();
            //myas.TestThread();
            //var res = myas.Test();
            //try
            //{
            //    await res;
            //    throw new Exception("no error.");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"{e.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("Finally.");
            //}

            var lo = new MyLock();
            await lo.TestMutex();
        }
    }
}
