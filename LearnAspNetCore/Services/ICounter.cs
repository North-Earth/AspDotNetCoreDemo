using System;

namespace LearnAspNetCore.Services
{
    public interface ICounter
    {
        int Value { get; }
    }

    public class RandomCounter : ICounter
    {
        private int _value;

        public RandomCounter()
            => _value = new Random().Next(0, 100000);

        public int Value => _value;
    }

    public class CounterService
    {
        public ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
