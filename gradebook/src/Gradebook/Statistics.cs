using System;

namespace Gradebook
{
    public class Statistics
    {
        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double value)
        {
            Sum += value;
            Count++;
            High = Math.Max(value, High);
            Low = Math.Min(value, Low);
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }


        public double Sum;
        public double Count;
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }

    }
}