using System;
using System.Collections.Generic;

namespace Observer_JNguyen
{
    public class WeatherStation
    {
        private double temperature = 0.0;
        private double pressure = 0.0;
        private double humidity = 0.0;

        public double Temperature
        {
            get { return this.temperature; }
            set
            {
                this.temperature = value;
                this.Notify(this.Temperature, this.Pressure, this.Humidity);
            }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set
            {
                this.pressure = value;
                this.Notify(this.Temperature, this.Pressure, this.Humidity);
            }
        }
        public double Humidity
        {
            get { return this.humidity; }
            set
            {
                this.humidity = value;
                this.Notify(this.Temperature, this.Pressure, this.Humidity);
            }
        }

        // List of Observers
        List<Observer> listOfObservers = new List<Observer>();


        // Methods

        // Assume these 3 methods are triggered by sensors (change based on what is being modeled) 
        public void SetTemperature(double aTemperature)
        {
            this.Temperature = aTemperature;
        }
        public void SetPressure(double aPressure)
        {
            this.Pressure = aPressure;
        }
        public void SetHumidity(double aHumidity)
        {
            this.Humidity = aHumidity;
        }

        public void Subscribe(Observer anObserver)
        {
            listOfObservers.Add(anObserver);
        }
        public void Unsubscribe(Observer anObserver)
        {
            listOfObservers.Remove(anObserver);
        }

        // Constructor
        public WeatherStation() : this(0.0, 0.0, 0.0) { }
        public WeatherStation(double aTemperature, double aPressure, double aHumidity)
        {
            this.Temperature = aTemperature;
            this.Pressure = aPressure;
            this.Humidity = aHumidity;
        }

        public void Notify(double aTemperature, double aPressure, double aHumidity)
        {
            foreach (var s in listOfObservers)
            {
                s.Update(aTemperature, aPressure, aHumidity);
            }
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
