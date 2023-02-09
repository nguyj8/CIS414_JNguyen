using System;
namespace Observer_JNguyen
{
    public interface Subject
    {
        public void Subscribe(Observer observer);
        public void Unsubscribe(Observer observer);
        public void Notify(); 
    }
}
