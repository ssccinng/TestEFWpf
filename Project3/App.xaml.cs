
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project3.Data;
using Project3.ViewModel;

using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Project3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IHost Host
        {
            get;
        }

        public static T GetService<T>()
            where T : class
        {

            System.Diagnostics.Debug.WriteLine("----------------------------");
            System.Diagnostics.Debug.WriteLine(typeof(T).ToString());
            //var a = typeof(T);
            if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            return service;
        }

        public App()
        {
            string MName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
            string PName = System.IO.Path.GetFileNameWithoutExtension(MName);
            System.Diagnostics.Process[] myProcess = System.Diagnostics.Process.GetProcessesByName(PName);

            if (myProcess.Length > 20)
            {
                MessageBox.Show("本程序一次只能运行一个实例！", "提示");
                Application.Current.Shutdown();
                return;
            }

            Host = Microsoft.Extensions.Hosting.Host.
                     CreateDefaultBuilder().
                     UseContentRoot(AppContext.BaseDirectory).
                     ConfigureServices((context, services) =>
                     {






                         services.AddSingleton<MainViewModel>();
                         services.AddTransient<MainWindow>();





                         services.AddDbContext<TestContext>(option =>
                         {
                             option.UseSqlServer(context.Configuration.GetConnectionString("TestContextConnection"));
                         });


                     })
                     .Build();



            var logger = Host.Services.GetRequiredService<ILogger<App>>();
            logger.LogInformation("Host created.");

            Host.Start();
        }

     
    }

}
