using System;
using System.Collections.Generic;

namespace TestTask
{
    internal class DataGenerator 
    {
        public int MaxValue { get; private set; } = 101;
        public int MinValue { get; private set; } = -100;        
        public int MaxCount { get; private set; } = 101;
        public int MinCount { get; private set; } = 20;

        private readonly Random _valueRandomizer;
        private readonly Random _countRandomizer;

        public DataGenerator()
        {
            _valueRandomizer = new Random();
            _countRandomizer = new Random();
        }

        public IEnumerable<int> GetDataSet()
        {
            int count = _countRandomizer.Next(MinCount, MaxCount);
            int[] values = new int[count];

            for (int i = 0; i < count; i++)
                values[i] = _valueRandomizer.Next(MinValue, MaxValue);

            return values;
        }
    }
}
