using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var weateher = new WeatherForecast();
            weateher.GetCurrThreadId("Main thrad");
            weateher.TestAsync("test");
            Application.Run(new Form1());


        }
    }


    public class WeatherForecast
    {
        public async Task TestAsync(string test)
        {
            
            for (int i = 0; i < 20; i++)
            {
                test = "a";
                GetCurrThreadId($"Method {i} thread");
                await SomeAsyncJob().ConfigureAwait(true);
                test = "b";
                GetCurrThreadId($"Method {i} thread");
                await SomeAsyncJob().ConfigureAwait(true); 
                test = "c";

                GetCurrThreadId($"Method {i} thread");
                await SomeAsyncJob().ConfigureAwait(true); 
                test = "b";

                GetCurrThreadId($"Method {i} thread");
                await SomeAsyncJob().ConfigureAwait(true); 
                test = "d";

                GetCurrThreadId($"Method {i} thread");
                await SomeAsyncJob().ConfigureAwait(true); 
                test = "k";
                GetCurrThreadId($"Method {i} thread");
                await SomeAsyncJob().ConfigureAwait(true);
                System.Diagnostics.Debug.WriteLine(test);
            }
        }

        public void GetCurrThreadId(string source) =>
            System.Diagnostics.Debug.WriteLine($"{source}:{Thread.CurrentThread.ManagedThreadId}");

        private async Task SomeAsyncJob()
        {
            var random = new Random(1).Next(1, 100);
            await Task.Delay(random).ConfigureAwait(true);
            GetCurrThreadId($"SomeAsyncJob");
            var secondRandom = new Random(1).Next(1, 100);
            await Task.Delay(secondRandom).ConfigureAwait(true);
            GetCurrThreadId($"SomeAsyncJob");

        }
    }

}
