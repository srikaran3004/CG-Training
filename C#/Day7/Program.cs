using System.Collections;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        /**
        // int[] numbers;//Declaration
        int[] numbers = { 10, 20, 30, 40, 50 };
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }
        int i=0;
        while (i < numbers.Length)
        {
            Console.WriteLine(numbers[i]);
            i++;
        }
        int[,] mat =
        {
            {1, 2},
            {4, 5}
        };
        // Console.WriteLine(mat[1, 0]);
        for(int i = 0; i < mat.GetLength(0); i++)
        {
            for(int j = 0; j < mat.GetLength(1); j++)
            {
                Console.Write(mat[i,j]+" ");
            }
            Console.WriteLine();
        }
        int[][] jagged = new int[2][];
        jagged[0]=new int[] {1,2};
        jagged[1]=new int[]{3,4,5,6};
        // Console.WriteLine(jagged[1][3]);
        for(int i = 0; i < jagged.Length; i++)
        {
            for(int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j]+" ");
            }
            Console.WriteLine();
        }
        //jagged.Length returns the number of rows (inner arrays)
        //jagged[i].Length returns the number of elements (columns) within a specific row.
        int[]arr={1,2,3};
        Array.Clear(arr,0,arr.Length); //Array.Clear(arrayName,startIndex,arrLength);
        int[,] arr1=
        {
            {1,2},
            {3,4}
        };
        Array.Clear(arr1,0,arr1.Length);
        int[]data={10,20,30};
        Array.Clear(data,0,2);
        Console.WriteLine($"{data[0]}, {data[1]}, {data[2]}");
        int[]src={1,2,3};
        int[]des=new int[3];
        int[]des1=new int[4];
        Array.Copy(src,des1,3);
        Array.Copy(src,des,2);
        for(int i = 0; i < des1.Length; i++)
        {
            Console.WriteLine(des1[i]);
        }
        int[]nums={1,2};
        // Array.Resize(ref nums,4);
        // Array.Resize(nums,4);
        Array.Resize(ref nums,1);
        int[]arr={1,2,3,4,25};
        bool found=Array.Exists(arr,x=>x>25) ;
        Console.WriteLine(found);
        List<int>l=new List<int>();
        l.Add(3);
        l.Add(5);
        l.Add(6);
        ArrayList arrL=new ArrayList();
        arrL.Add(4);
        arrL.Add(5);
        arrL.Add(7);
        arrL.Add("Srikaran");
        for(int i = 0; i < arrL.Count; i++)
        {
            Console.WriteLine(arrL[i]);
        }
        Hashtable ht= new Hashtable();
        ht.Add(0,"User");
        ht.Add(1,"Admin");
        ht.Add(2,"Customer");
        for(int i = 0; i < ht.Count; i++)
        {
            Console.WriteLine(ht[i]);
        }
        Stack st = new Stack();
        st.Push(10);
        st.Push(20);
        Console.WriteLine(st.Pop());
        Queue q = new Queue();
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue("srikaran");
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());  
        Dictionary<int,string>d=new Dictionary<int, string>();
        d.Add(0,"user");
        d.Add(1,"admin");
        foreach(var i in d)
        {
            Console.WriteLine($"Value of {i} is {i.Value}");
        }
        **/
        HashSet<int>st=new HashSet<int>();
        st.Add(1);
        st.Add(1);
        st.Add(3);
        foreach(int i in st)
        {
            Console.WriteLine(i);
        }
    }
}