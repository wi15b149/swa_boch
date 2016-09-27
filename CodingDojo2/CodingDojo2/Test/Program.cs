using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingDojo2.Stack;

namespace CodingDojo2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWithInt();
            TestWithString();
            TestWithObject();
            Console.ReadLine();
        }
        static void TestWithInt()
        {
            Stack<int> test = new Stack<int>();
            Console.WriteLine("Test mit Int");
            test.Push(5);
            Console.WriteLine("push: {0}", test.Peek());
            test.Push(7);
            Console.WriteLine("push: {0}", test.Peek());
            test.Push(4);
            Console.WriteLine("push: {0}", test.Peek());
            Console.WriteLine("pop: {0}", test.Pop());
            Console.WriteLine("pop: {0}", test.Pop());
            Console.WriteLine("last: {0}", test.Peek());
            Console.WriteLine("pop: {0}", test.Pop());
            Console.WriteLine("last: {0}", test.Peek());
            
        }

        static void TestWithString()
        {
            Stack<string> test = new Stack<string>();

            Console.WriteLine("Test mit String");
            test.Push("s5");
            Console.WriteLine("push: {0}", test.Peek());
            test.Push("s7");
            Console.WriteLine("push: {0}", test.Peek());
            Console.WriteLine("pop: {0}", test.Pop());
            test.Push("s4");
            Console.WriteLine("push: {0}", test.Peek());
                        Console.WriteLine("pop: {0}", test.Pop());
            Console.WriteLine("last: {0}", test.Peek());
            Console.WriteLine("pop: {0}", test.Pop());
            Console.WriteLine("last: {0}", test.Peek());

        }

        static void TestWithObject()
        {
            Stack<TestObject> test = new Stack<TestObject>();
            Console.WriteLine("Test mit Objekt");

            test.Push(new TestObject(41, "Sampleperson1"));
            Console.WriteLine("read: {0}", test.Peek());
            test.Push(new TestObject(80, "Sampleperson2"));
            Console.WriteLine("read: {0}", test.Peek());
            test.Push(new TestObject(15, "Sampleperson3"));
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());

        }
    }


}
