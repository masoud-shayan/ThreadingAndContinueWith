using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();


            Console.WriteLine("Passing the result of one task as an input into another.");


            var taskCallWebServiceAndThenStoredProcedure = Task.Factory.StartNew(CallWebService)
                .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));


            Console.WriteLine($"Result: {taskCallWebServiceAndThenStoredProcedure.Result}");


            Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
        }


        
        
        
        static decimal CallWebService()
        {
            Console.WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            Console.WriteLine("Finished call to web service.");
            return 89.99M;
        }

        static string CallStoredProcedure(decimal amount)
        {
            Console.WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            Console.WriteLine("Finished call to stored procedure.");
            return $"12 products cost more than {amount:C}.";
        }
    }
}