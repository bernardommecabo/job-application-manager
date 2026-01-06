using Microsoft.Extensions.DependencyInjection;
using ProjectWinForms.Services;
using ProjectWinForms.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace ProjectWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddScoped<IApplicantServiceForms, ApplicantServiceForms>();
            services.AddScoped<IApplicationServiceForms, ApplicationServiceForms>();

            services.AddTransient<HomeForm>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var homeForm = serviceProvider.GetRequiredService<HomeForm>();

                Application.Run(homeForm);
            }
        }
    }
}