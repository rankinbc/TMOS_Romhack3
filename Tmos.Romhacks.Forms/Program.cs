using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Editor;
using Tmos.Romhacks.Editor.Interfaces;
using Tmos.Romhacks.Forms.Drawers;
using Tmos.Romhacks.Library;
using TMOS_Romhack.Romhacks.Editor.WorldScreenGrid;

namespace Tmos.Romhacks.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			ApplicationConfiguration.Initialize();

			var services = new ServiceCollection();
			ConfigureServices(services);

			using (ServiceProvider serviceProvider = services.BuildServiceProvider())
			{
				var form1 = serviceProvider.GetRequiredService<Form1>();
				Application.Run(form1);
			}

        }


		private static void ConfigureServices(IServiceCollection services)
		{
		   services.AddSingleton<TmosModRom>();
    		services.AddSingleton<IWorldScreenGridGenerator, WSGridGenerator_RecursiveCrawler>();
    		services.AddSingleton<ITmosDrawer, TmosDrawer>();
    		services.AddTransient<Form1>();
		}

	}
}
