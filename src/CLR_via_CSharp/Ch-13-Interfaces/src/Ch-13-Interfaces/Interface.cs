using System;

namespace Ch_13_Interfaces
{
    public interface Interface
    {
        void M();
        event EventHandler New;
        int MyProperty { get; set; }
        object this[int index] { get; set; }

        /*
        Interface(){}
        int MyField;
        const int MyConst = 10;  
        static void Mstatic();
        */
    }
}
