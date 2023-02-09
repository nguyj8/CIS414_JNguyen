using System;
using System.Collections.Generic;

namespace Observer_JNguyen
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay staticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData); // Create the 3 objects (displays) and pass WeatherData object 
            weatherData.SetMeasurements(80, 65, 30.4);
            weatherData.SetMeasurements(54, 23, 90.2);
            weatherData.SetMeasurements(69, 21, 87.5);

            currentDisplay.Display();
            Console.WriteLine();
            staticsDisplay.Display();
            Console.WriteLine();
            forecastDisplay.Display();
            Console.WriteLine();
        }
    }
}
