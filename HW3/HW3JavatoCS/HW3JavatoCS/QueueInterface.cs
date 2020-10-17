using System;
using System.Collections.Generic;
using System.Text;

namespace HW3JavatoCS
{
    interface IQueue<T>
    {
        T Push(T element);

        T Pop();

        T Peek();

        bool IsEmpty();

    }
}
