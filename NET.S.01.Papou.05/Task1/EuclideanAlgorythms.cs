using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{
    public static class EuclidianAlgorithms
    {
        #region public methods
        /// <summary>
        /// Computes GCD by standart Euclidean algorithm
        /// </summary>
        /// <param name="elapsedTime">elapsed time of executed method</param>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD</returns>
        public static int FindGCD(out long elapsedTime, int a, int b)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = BinaryGCD(a, b);
            timer.Stop();
            elapsedTime = timer.ElapsedMilliseconds / 1000;
            return result;
        }

        /// <summary>
        /// Computes GCD by standart Euclidean algorithm
        /// </summary>
        /// <param name="elapsedTime">elapsed time of executed method</param>
        /// <param name="numbers">numbers for GCD</param>
        /// <returns>GCD</returns>
        public static int FindGCD(out long elapsedTime, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = BinaryGCD(numbers);
            timer.Stop();
            elapsedTime = timer.ElapsedMilliseconds / 1000;
            return result;
        }

        /// <summary>
        /// Computes GCD by binary Euclidean algorithm
        /// </summary>
        /// <param name="elapsedTime">elapsed time of executed method</param>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD</returns>
        public static int FindGCDBinary(out long elapsedTime, int a, int b)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = BinaryGCD(a, b);
            timer.Stop();
            elapsedTime = timer.ElapsedMilliseconds / 1000;
            return result;
        }

        /// <summary>
        /// Computes GCD by binary Euclidean algorithm
        /// </summary>
        /// <param name="elapsedTime">elapsed time of executed method</param>
        /// <param name="numbers">numbers for GCD</param>
        /// <returns>GCD</returns>
        public static int FindGCDBinary(out long elapsedTime, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = BinaryGCD(numbers);
            timer.Stop();
            elapsedTime = timer.ElapsedMilliseconds / 1000;
            return result;
        }

        /// <summary>
        /// Converts double to string that represents IEEE754 standart
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>string that represents IEEE754 standart</returns>
        public static string ToIEEE754(this double number)
        {
            string sign = "";
            string exponent = "";
            string fraction = "";

            if (number < 0) sign += "0";
            else sign += "1";


            return sign+exponent+fraction;
        }
        #endregion
        #region private methods

        private static int GCD(int a, int b)
        {
            if (a == 0) return Math.Abs(b);
            if (b == 0) return Math.Abs(a);
            return AlgorythmGCD(Math.Abs(a), Math.Abs(b));
        }

        private static int GCD(params int[] numbers)
        {
            if (numbers.Length < 2) throw new ArgumentException();
            if (Array.TrueForAll(numbers, x => x == 0)) throw new ArgumentException();
            return AlgorythmGCD(numbers);
        }

        private static int BinaryGCD(int a, int b)
        {
            if (a == 0) return Math.Abs(b);
            if (b == 0) return Math.Abs(a);
            return AlgorythmBinaryGCD(Math.Abs(a), Math.Abs(b));
        }

        private static int BinaryGCD(params int[] numbers)
        {
            if (numbers.Length < 2) throw new ArgumentException();
            if (Array.TrueForAll(numbers, x => x == 0)) throw new ArgumentException();
            return AlgorythmBinaryGCD(numbers);
        }

        private static int AlgorythmGCD(int a, int b)
        {
            while (a != b)
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            return a;
        }
        
        private static int AlgorythmGCD(params int[] numbers)
        {
            int tempGCD = GCD(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
                tempGCD = GCD(tempGCD, numbers[i]);

            return tempGCD;
        }

        private static int AlgorythmBinaryGCD(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if ((~a & 1) != 0)
                if ((b & 1) != 0)
                    return AlgorythmBinaryGCD(a >> 1, b);
                else
                    return AlgorythmBinaryGCD(a >> 1, b >> 1) << 1;
            if ((~b & 1) != 0)
                return AlgorythmBinaryGCD(a, b >> 1);
            if (a > b)
                return AlgorythmBinaryGCD((a - b) >> 1, b);
            return AlgorythmBinaryGCD((b - a) >> 1, a);
        }

        private static int AlgorythmBinaryGCD(params int[] numbers)
        {
            int tempGCD = BinaryGCD(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
                tempGCD = BinaryGCD(tempGCD, numbers[i]);

            return tempGCD;
        }
        #endregion
    }
}
