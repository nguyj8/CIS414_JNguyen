using System;
using System.Collections.Generic;

namespace Observer_JNguyen
{
    public class WeatherData : Subject
    {
        private List<Observer> observers = new List<Observer>();
        private double temperature = 0.0;
        private double humidity = 0.0;
        private double pressure = 0.0;

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
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public WeatherData() : this(0.0, 0.0, 0.0) { }
        public WeatherData(double aTemperature, double aHumidity, double aPressure)
        {
            this.temperature = aTemperature;
            this.humidity = aHumidity;
            this.pressure = aPressure; 
        }

        public void Subscribe(Observer o)
        {
            observers.Add(o);
        }
        public void Unsubscribe(Observer o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update(temperature, humidity, pressure); 
            }
        }
        public void MeasurementChanged()
        {
            Notify(); 
        }
        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure; 
        }

        public override string ToString()
        {
            string msg = "";
            msg += "Temperature: " + this.Temperature + "\n";
            msg += "Humidity: " + this.Humidity + "\n";
            msg += "Pressure: " + this.Pressure + "\n";
            return msg; 
        }
    }
}
