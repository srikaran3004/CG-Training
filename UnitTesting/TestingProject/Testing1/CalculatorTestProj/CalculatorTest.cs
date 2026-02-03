using System;
using System.Collections.Generic;
using System.Text;
using CalcUnitTesting.core.Feature;

namespace CalculatorTestProj
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_Giventwonum_resultint()
        {
            var calculator = new Calculator(); //Arrange ( create object of class)
            int result = calculator.Add(2, 3); //Act ( calling method and passing params)
            Assert.AreEqual(5, result); //Assert (verify expected vs actual)
        }
        [TestMethod]
        public void Subtract_Giventwonum_resultint()
        {
            var calculator = new Calculator();
            int result = calculator.Sub(5, 3);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Multiply_Giventwonum_resultint()
        {
            var calculator = new Calculator();
            int result = calculator.Mul(2, 3);
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void Divide_Giventwonum_resultint()
        {
            var calculator = new Calculator();
            int result = calculator.Div(3,0);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        [DataRow(2,1,3)]
        [DataRow(5, 3, 8)]
        public void Add_Parameterized(int a,int b,int expected) {
            var cal = new Calculator();
            int res = cal.Add(a, b);
            Assert.AreEqual(expected, res);
        }
    }
 }
