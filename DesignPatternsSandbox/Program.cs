using System;
using Microsoft.Extensions.DependencyInjection;
using DesignPatternsSandbox.Helpers;
using DesignPatternsSandbox.ModelFilter;
using DesignPatternsSandbox.ModelFilter.Interfaces;

namespace DesignPatternsSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // setup our DI for flamboyance
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFlightFilter, FlightFilter>()
                .BuildServiceProvider();

            // Instantiate helper and grab some test data
            var flights = new FlightAPIHelper().GetFlights();

            // Lets get our flight filter and give it some data
            var filter = serviceProvider.GetService<IFlightFilter>();
            filter.SetModelCollection(flights);

            // execute our fluent filter
            var filteredFlights = filter
                .DepartAfter(System.DateTime.Now)
                .RemoveErroneusFlights() // removes weird back to front segments
                .RemoveLongLayover(5400) // remove flights with more than 1.5 hours of layover (in seconds)
                .Evaluate();

            var non737MaxFilter = new SafeFlightFilter();
            non737MaxFilter.SetModelCollection(flights);

            // safe filter, extend base filter but remove 737MAX's by default
            var safeFilteredFlights = non737MaxFilter
                .Evaluate();

            //print and format valid results
            for (int i = 0; i < filteredFlights.Count; i++)
            {
                // give flight a name
                Console.WriteLine("Flight " + (i + 1).ToString());
                // call overridden toString() on flight
                Console.WriteLine(filteredFlights[i].ToString());
                // add some space to tidy
                Console.WriteLine();
            }
        }
    }
}
