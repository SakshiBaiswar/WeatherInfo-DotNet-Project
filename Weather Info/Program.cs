using System.Net;
using System.Text.Json;
using Weather_Info.Models;

class CurrentWeather

{
    static void Main(string[] args)

    {
        string city;

        try
        {
            city = args[0];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Enter City : ");
            city = Console.ReadLine();
        }


        string text = File.ReadAllText(@"./Local Data/location.json");
        var citieslist = JsonSerializer.Deserialize<Cities>(text);
        var cityfound = false;

        foreach (var c in citieslist.cityarray)
        {
            if (c.city == city)
            {
                cityfound = true;
                var weatherInfo = Getcurrentweather(c.lat, c.lng);
                if (weatherInfo != null)
                {
                    Console.WriteLine("Temperature:{0},Windspeed:{1},WindDirection :{2}", weatherInfo.current_weather.temperature, weatherInfo.current_weather.windspeed, weatherInfo.current_weather.winddirection);

                }
                else
                {
                    Console.WriteLine("Current weather information unavailable.");
                }
                break;
            }

        }

        if (cityfound == false)
            Console.WriteLine("City not valid.");

    }

    private static Weatherinfo? Getcurrentweather(string latitude, string longitude)
    {
        var uri = "https://api.open-meteo.com/v1/forecast?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true";

        WebRequest request = WebRequest.Create(uri);
        ((HttpWebRequest)request).UserAgent = ".NET Core Client";
        WebResponse response;

        try
        {
            response = request.GetResponse();
        }
        catch (WebException)
        {
            response = null;
            Console.WriteLine("Invalid Value");
            Environment.Exit(1);
        }

        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        var rawResponse = reader.ReadToEnd();

        reader.Close();
        dataStream.Close();

        var weatherInfo = JsonSerializer.Deserialize<Weatherinfo>(rawResponse);

        return weatherInfo;
    }
}
