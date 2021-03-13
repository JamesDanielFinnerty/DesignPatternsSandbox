using System;
using Microsoft.Extensions.DependencyInjection;
using DesignPatternsSandbox.Helpers;
using DesignPatternsSandbox.ModelFilter;
using DesignPatternsSandbox.ModelFilter.Interfaces;
using DesignPatternsSandbox.Factories.Interfaces;
using DesignPatternsSandbox.Factories;

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

            // Get a filter from our factory, specifying safety
            var filter = new FlightFilterFactory(true).GetFilter();
            filter.SetModelCollection(flights);

            // execute our fluent filter
            var filteredFlights = filter
                .DepartAfter(System.DateTime.Now)
                .RemoveErroneusFlights()
                .RemoveLongLayover(5400)
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
