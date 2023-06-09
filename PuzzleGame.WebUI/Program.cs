using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace PuzzleGame.WebUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
  Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
          webBuilder.ConfigureKestrel(kestrelOptions =>
          {
              kestrelOptions.ConfigureHttpsDefaults(configureOptions: httpsOptions =>
              {
                  httpsOptions.SslProtocols = SslProtocols.Tls12;
              });
          });

          webBuilder.UseStartup<Startup>();
      });
    }
}
