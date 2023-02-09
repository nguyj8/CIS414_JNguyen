using System;
namespace Observer_JNguyen
{
    public class CurrentConditionsDisplay : Observer, Display
    {
        private double temperature = 0.0;
        private double humidity = 0.0;
        private WeatherData weatherData;

        public double Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; }
        }
        public double Humidity
        {
            get { return this.humidity; }
            set { this.humidity = value; }
        }
        public CurrentConditionsDisplay(WeatherData data)
        {
            this.weatherData = data;
            weatherData.Subscribe(this);
        }

        public CurrentConditionsDisplay() : this(0.0, 0.0) { }
        public CurrentConditionsDisplay(double aTemperature, double aHumidity)

        {
            this.temperature = aTemperature;
            this.humidity = aHumidity;
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            this.temperature = weatherData.Temperature;
            this.humidity = weatherData.Humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + " % humidity");
        }

        //public override string ToString()
        //{
        //    string msg = "";
        //    msg += "Temperature: " + this.Temperature + "\n";
        //    msg += "Humidity: " + this.Humidity + "\n";
        //    return msg;
        //}
    }
}

