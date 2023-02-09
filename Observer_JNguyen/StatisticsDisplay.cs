using System;
namespace Observer_JNguyen
{
    public class StatisticsDisplay : Observer, Display
    {
        private double maximum = 0.0;
        private double minimum = 0.0;
        private double sum = 0.0;
        private int numberReadings;
        private WeatherData weatherData;

        public double Maximum
        {
            get { return this.maximum; }
            set { this.maximum = value; }
        }
        public double Minimum
        {
            get { return this.minimum; }
            set { this.minimum = value; }
        }
        public double Sum
        {
            get { return this.sum; }
            set { this.sum = value; }
        }

        public StatisticsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Subscribe(this);
        }

        public StatisticsDisplay() : this(0.0, 0.0, 0.0) {}

        public StatisticsDisplay(double aMaximum, double aMinimum, double aSum)
        {
            this.maximum = aMaximum;
            this.minimum = aMinimum;
            this.sum = aSum;
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            sum += temperature;
            numberReadings++;

            if (temperature > this.Maximum)
            {
                this.Maximum = temperature;
            }

            if (temperature < this.Minimum)
            {
                this.Minimum = temperature;
            }
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Average: " + (sum / numberReadings) + "\n" + "Maximum: " + maximum + "\n" + "Minimum: " + minimum);
        }

        //public override string ToString()
        //{
        //    string msg = "";
        //    msg += "Maximum: " + this.Maximum + "\n";
        //    msg += "Minimum: " + this.Minimum + "\n";
        //    msg += "Sum: " + this.Sum + "\n";
        //    return msg;
        //}
    }
}
