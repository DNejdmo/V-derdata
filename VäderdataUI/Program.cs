using Microsoft.EntityFrameworkCore;
using Väderdata.Models;
using System.IO;
using System.Linq;
using Väderdata;



internal class Program
{


    private static void Main(string[] args)
    {

        using (var context = new WDContext())
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }


        //DataImporter.ImportCsvToDatabase("C:\\Users\\dnejd\\OneDrive\\Skrivbord\\VäderData.csv"); ////Importerar data till tabellen WeatherData. Välj din sökväg.



        Console.Write("Tryck på en tangent för att stänga fönstret");
        Console.ReadKey();


    }



 
}
