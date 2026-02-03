using System;
using System.Collections.Generic;
using System.Text;

namespace CheckEvenNum
{
    public class SumOfNNumbers
    {
        public int SumOfN(int num)
        {
            int s = 0;
            for (int i = 1; i <= num; i++)
            {
                s = s + i;
            }
            return s;
        }
    }
    public class ReverseString
    {
        public string ReverseStr(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
