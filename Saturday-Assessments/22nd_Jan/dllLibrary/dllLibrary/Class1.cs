namespace dllLibrary
{
    interface IClass1
    {
        void Method1();
        void Method2();
    }
    interface IClass2
    {
        void Method3();
    }
    interface IClass3
    {
        void Method4();
    }   
    public class Class1 : IClass1, IClass2, IClass3
    {
        public void Method1()
        {
            Console.WriteLine("MethodA implementation");
        }
        public void Method2()
        {
            Console.WriteLine("MethodB implementation");
        }
        public void Method3()
        {
            Console.WriteLine("MethodC implementation");
        }
        public void Method4()
        {
            Console.WriteLine("MethodD implementation");
        }
    }
    public class Class2:Class1
    {
        public void Method5()
        {
            Console.WriteLine("New MethodE implementation");
        }
    }
}
