using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo2.Stack
{
    class StackItem<T>
    {
        //private T valueOfElement;
        //private StackItem<T> successor;

        //Wert des Items
        public T ValueOfElement { get; set; }
        
        //Nachfolger
        public StackItem<T> Successor { get; set; } 

    }
}
