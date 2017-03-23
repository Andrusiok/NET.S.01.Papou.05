using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class EucledianAlgorithms_Tests
    {
        [TestCase(9, 15, ExpectedResult = 3)]
        [TestCase(6, 18, ExpectedResult = 6)]
        [TestCase(20, -15, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        public int FindGCD_Positive(int a, int b)
        {
            long c = 0;
            return EuclidianAlgorithms.FindGCD(out c, a, b);
        }

        [TestCase(9, 15, ExpectedResult = 3)]
        [TestCase(6, 18, ExpectedResult = 6)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(20, -15, ExpectedResult = 5)]
        public int FindGCDBinary_Positive(int a, int b)
        {
            long c = 0;
            return EuclidianAlgorithms.FindGCDBinary(out c, a, b);
        }

        [TestCase(new int[] {9, 15, 6}, ExpectedResult = 3)]
        [TestCase(new int[] { 6, 18, 12}, ExpectedResult = 6)]
        [TestCase(new int[] { 0, 15, 3}, ExpectedResult = 3)]
        public int FindGCD_Positive(params int[] numbers)
        {
            long c = 0;
            return EuclidianAlgorithms.FindGCD(out c, numbers);
        }

        [TestCase(new int[] { 9, 15, 6 }, ExpectedResult = 3)]
        [TestCase(new int[] { 6, 18, 12 }, ExpectedResult = 6)]
        [TestCase(new int[] { 0, 15, 3 }, ExpectedResult = 3)]
        public int FindGCDBinary_Positive(params int[] numbers)
        {
            long c = 0;
            return EuclidianAlgorithms.FindGCDBinary(out c, numbers);
        }

        [TestCase(new int[] { 0, 0, 0})]
        [TestCase(new int[] { 1})]
        public void FindGCD_ArgumentException(params int[] numbers)
        {
            long c = 0;
            Assert.Throws<ArgumentException>(() => EuclidianAlgorithms.FindGCD(out c, numbers));
        }

        [TestCase(new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 1 })]
        public void FindGCDBinary_ArgumentException(params int[] numbers)
        {
            long c = 0;
            Assert.Throws<ArgumentException>(() => EuclidianAlgorithms.FindGCDBinary(out c, numbers));
        }
    }
}
