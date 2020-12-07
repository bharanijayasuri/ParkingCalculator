using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ParkingTicketCalculator
{
    class Program
    {
        public static IConfiguration configuration;

        static void Main(string[] args)
        {
            Console.WriteLine(" ___________________________");
            Console.WriteLine("| Parking ticket calculator |");
            Console.WriteLine(" ___________________________");
            Console.WriteLine();

            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var factory = (ParkingChargeFactory)serviceProvider.GetRequiredService(typeof(ParkingChargeFactory));

            var shortStayCalculator = factory.GetParkingChargeCalculator(StayType.ShortStay);
            var longStayCalculator = factory.GetParkingChargeCalculator(StayType.LongStay);

            Console.WriteLine(" Short stay charge calculations");
            Console.WriteLine("________________________________\n");
            shortStayCalculator.CalculateAndDisplayParkingCharge(Convert.ToDateTime("2017-09-07 16:50:00"), Convert.ToDateTime("2017-09-07 18:00:00"));
            shortStayCalculator.CalculateAndDisplayParkingCharge(Convert.ToDateTime("2017-09-07 16:50:00"),Convert.ToDateTime("2017-09-09 19:15:00"));
            shortStayCalculator.CalculateAndDisplayParkingCharge(Convert.ToDateTime("2019-11-03 07:00:00"), Convert.ToDateTime("2019-11-05 11:15:00"));

            Console.WriteLine(" Long stay charge calculations");
            Console.WriteLine("________________________________\n");
            longStayCalculator.CalculateAndDisplayParkingCharge(Convert.ToDateTime("2017-09-07 19:50:00"), Convert.ToDateTime("2017-09-09 05:20:00"));
            longStayCalculator.CalculateAndDisplayParkingCharge(Convert.ToDateTime("2020-05-17 12:50:00"), Convert.ToDateTime("2020-05-17 12:51:00"));
            longStayCalculator.CalculateAndDisplayParkingCharge(Convert.ToDateTime("2020-10-07 19:25:00"), Convert.ToDateTime("2020-10-17 12:51:00"));

            Console.ReadKey();

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            configuration = new ConfigurationBuilder()
           .SetBasePath(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"../../../")))
           .AddJsonFile("appsettings.json", false)
           .AddEnvironmentVariables()
           .Build();

            services.Configure<CarParkCharges>(configuration.GetSection("CarParkCharges"));
            services.AddScoped(typeof(ParkingChargeFactory));
            services.AddScoped<ShortStayParkingChargeCalculator>().AddScoped<IParkingChargeCalculator, ShortStayParkingChargeCalculator>(s => s.GetService<ShortStayParkingChargeCalculator>());
            services.AddScoped<LongStayParkingChargeCalculator>().AddScoped<IParkingChargeCalculator, LongStayParkingChargeCalculator>(s => s.GetService<LongStayParkingChargeCalculator>());
        }
    }
}
