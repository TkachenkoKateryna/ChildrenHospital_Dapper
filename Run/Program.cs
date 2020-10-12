using ChildrenHospinal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Run
{
    class Program
    {

        private static IConfigurationRoot config;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void Initialize()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config = builder.Build();
        }

        private static IDiseaseRepository CreateRepository()
        {
            return new DiseaseRepository(config);
            //return new ContactRepositoryContrib(config.GetConnectionString("DefaultConnection"));
        }
    }
}
