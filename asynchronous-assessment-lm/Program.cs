using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 * INSTRUCTIONS:
 *  1. Modify the codes below and make it asynchronous
 *  2. After your modification, explain what makes it asynchronous
**/


namespace asynchronous_assessment_lm
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            while (breakfastTasks.Any())
            {
                var completedTask = await Task.WhenAny(breakfastTasks);

                if (completedTask == eggsTask)
                {
                    Console.WriteLine("Eggs are ready");
                }
                else if (completedTask == baconTask)
                {
                    Console.WriteLine("Bacon is ready");
                }
                else if (completedTask == toastTask)
                {
                    Console.WriteLine("Toast is ready");
                }
                breakfastTasks.Remove(completedTask);
            }

            var orange = PourOJ();
            Console.WriteLine("Orange juice is ready");

            Console.WriteLine("Breakfast is ready!");

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

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);


            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int count)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {count} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
