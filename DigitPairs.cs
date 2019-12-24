using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab9
{
    class DigitPairs<T>
    {
        public int FirstDigit { get; set; }
        public T SecondDigit { get; set; }
        public DigitPairs()
        {
            FirstDigit = -1;
            SecondDigit = default(T);
        }
        public DigitPairs(int first, T second)
        {
            FirstDigit = first;
            SecondDigit = second;
        }
        public DigitPairs(int first)
        {
            FirstDigit = first;
            SecondDigit = default(T);
        }
        public DigitPairs(T second)
        {
            FirstDigit = -1;
            SecondDigit = second;
        }
    }
}
