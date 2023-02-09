using System;
namespace Observer_JNguyen
{
    public interface Observer
    {
        public void Update(double temperature, double humidity, double pressure);
    }
}
