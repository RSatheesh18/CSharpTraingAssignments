using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareBreakfast();
        }

        private async static void PrepareBreakfast()
        {
            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
            Coffee cup = PourCoffee();            
            Console.WriteLine("coffee is ready");

            Task<Egg> eggstask = FryEggsAsync(2);
           
            Console.WriteLine("eggs are ready");

            Task<Bacon> bacontask =  FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Task <Toast> toasttask =  Preparetoast(2);
            Task.WaitAll(eggstask, bacontask, toasttask);
            var toast = await toasttask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            _watch.Stop();
            Console.WriteLine("Breakfast is ready! Preparation time :" + _watch.ElapsedMilliseconds);
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine("Putting a slice of bread in the toaster");
                }
                Console.WriteLine("Start toasting...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Remove toast from toaster");
                return new Toast();
            
            
        }
        private static Task<Toast> Preparetoast(int numberOfSlices)
        {
            return Task<Toast>.Run(() =>
            {
                return ToastBread(numberOfSlices);
            });
        }

        private static Task<Bacon> FryBaconAsync(int numberOfSlices)
        {
            return Task<Bacon>.Run(() =>
            {
                return FryBacon(numberOfSlices);
            });
        }
        private static Task<Egg> FryEggsAsync(int numberOfeggs)
        {
            return Task<Egg>.Run(() =>
            {
                return FryEggs(numberOfeggs);
            });
        }
        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private  static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
        
    }

    internal class Toast
    {
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }

    internal class Juice
    {

    }
}

