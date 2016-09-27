using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo2.Stack
{
    class Stack<T>
    {
        private StackItem<T> currentElement; //stores the latest entry of the stack
                

        public void Push(T item)
        {
            if (currentElement == null)
            {
                currentElement = new StackItem<T>() { ValueOfElement = item, Successor = null };
            }
            else
            {
                StackItem<T> temp = new StackItem<T>() { ValueOfElement = item, Successor = currentElement };
                currentElement = temp;
            }

        }

        public T Pop()
        {
            if (currentElement != null)
            {
                T temp = currentElement.ValueOfElement;
                currentElement = currentElement.Successor;
                return temp;
            }
            else
            {
                throw new NullReferenceException(); //throw an exception becasue stack is entry
            }
        }

        //Wert des letzten Eintrags zurückgeben
        public T Peek()
        {
            if (currentElement != null)
            {
                return currentElement.ValueOfElement;
            }
            else
            {
                return default(T);
            }
        }
    }
}
