namespace DistributedWeatherApplication.Models
{
    public class WeatherData
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
    }

    public class Current
    {
        public double Temp_C { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
    }
}
