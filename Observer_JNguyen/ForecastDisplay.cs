using System;
namespace Observer_JNguyen
{
    public class ForecastDisplay : Observer, Display
    {
        private double currentPressure = 0.0;
        private double previousPressure = 0.0;
        private WeatherData weatherData;

        public double CurrentPressure
        {
            get { return this.currentPressure; }
            set { this.currentPressure = value; }
        }
        public double PreviousPressure
        {
            get { return this.previousPressure; }
            set { this.previousPressure = value; }
        }

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Subscribe(this);
        }

        public ForecastDisplay() : this(0.0, 0.0) { }
        public ForecastDisplay(double aCurrentPressure, double aPreviousPressure)
        {
            this.currentPressure = aCurrentPressure;
            this.previousPressure = aPreviousPressure;
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            this.previousPressure = currentPressure;
            this.currentPressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Forecast: ");
            if (currentPressure > previousPressure)
            {
                Console.WriteLine("Oh shit, Mother Nature came through.");
            }
            else if (currentPressure == previousPressure)
            {
                Console.WriteLine("Same fucking weather.");
            }
            else if (currentPressure < previousPressure)
            {
                Console.WriteLine("Sprinkles but with spice, bitch.");
            }
        }
    }
}

