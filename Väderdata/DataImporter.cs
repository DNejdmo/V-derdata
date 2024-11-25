using System.Globalization;
using Väderdata.Models;


//Importerar data till tabellen WeatherData. Välj din sökväg i metodanropet.

public class DataImporter 
    {
    public static void ImportCsvToDatabase(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var weatherDataList = new List<WeatherData>();

        foreach (var line in lines.Skip(1)) // Hoppa över rubrikerna
        {
            var columns = line.Split(';');

            var weatherData = new WeatherData
            {
                Datum = DateTime.ParseExact(columns[0], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Plats = columns[1],
                Temp = double.TryParse(columns[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var temp) ? temp : (double?)null,
                Luftfuktighet = double.TryParse(columns[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var humidity) ? humidity : (double?)null,
            };

            weatherDataList.Add(weatherData);
        }
        using (var context = new WDContext())
        {
            context.AddRange(weatherDataList);
            context.SaveChanges();
        }

    }
  

}