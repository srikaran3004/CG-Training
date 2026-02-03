using System;
using System.Collections.Generic;
using System.Text;

namespace CalcUnitTesting.core.Feature
{
    public class Calculator
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int Mul(int a, int b)
        {
            return a * b;
        }
        public int Div(int a, int b)
        {
            //if(b==0)
            //{
            //    //throw new DivideByZeroException("Denominator cannot be zero.");
            //    return -1;
            //}
            return a / b;
        }
    }
}
