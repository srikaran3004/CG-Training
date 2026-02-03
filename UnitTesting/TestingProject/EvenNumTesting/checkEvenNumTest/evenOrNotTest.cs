using CheckEvenNum;
using System;
using System.Collections.Generic;
using System.Text;

namespace checkEvenNumTest
{
    [TestClass]
    public class evenOrNotTest
    {
        [TestMethod]
        [DataRow(4)]
        [DataRow(0)]
        [DataRow(14)]
        [DataRow(20)]
        public void TestIsEven(int value)
        {
            // Arrange
            var evenChecker = new CheckEvenNum.evenOrNot();
            // Act
            bool result = evenChecker.IsEven(value);
            // Assert
            Assert.IsTrue(result);
        }
    }
    [TestClass]
    public class SumOfNNumbersTest
    {
        [TestMethod]
        [DataRow(10, 55)]
        [DataRow(12, 78)]
        public void TestSumOfN(int n, int expectedSum)
        {
            // Arrange
            var sumCalculator = new SumOfNNumbers();
            // Act
            int actualSum = sumCalculator.SumOfN(n);
            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
    [TestClass]
    public class ReverseStringTest
    {
        [TestMethod]
        [DataRow("Srikaran", "narakirS")]
        [DataRow("Pavan", "navaP")]
        public void TestReverseStr(string input, string expected)
        {
            // Arrange
            var reverseString = new ReverseString();
            // Act
            string actual = reverseString.ReverseStr(input);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}