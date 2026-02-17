using System;

interface IParser
{
    float[] Parse(string input);
}
interface IRounder
{
    float Round(float value);
}
class SensorNormalizer : IParser, IRounder
{
    public float Round(float value)
    {
        return (float)Math.Round(value, 2);
    }
    public float[] Parse(string input)
    {
        if (input == null || input.Trim() == "") return null;
        string[] arr = input.Split(',');
        float[] temp = new float[arr.Length];
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            string str = arr[i].Trim();

            if (str == "" || str.ToLower() == "null") continue;
            float value;
            if (float.TryParse(str, out value))
            {
                temp[count] = Round(value);
                count++;
            }
        }
        if (count == 0)
            return null;

        float[] res = new float[count];
        for (int i = 0; i < count; i++)
        {
            res[i] = temp[i];
        }

        return res;
    }
}
class Program
{
    static void Main()
    {
        string s = " 24.5678, 18.9, null, , 31.0049, error, 29, 17.999, NaN ";
        SensorNormalizer sn = new SensorNormalizer();
        float[] data = sn.Parse(s);
        if (data != null)
        {
            foreach (float f in data)
            {
                Console.Write(f + " ");
            }
        }
    }
}
