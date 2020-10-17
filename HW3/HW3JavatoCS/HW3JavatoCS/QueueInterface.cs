using System;
using System.Collections.Generic;
using System.Text;

namespace HW3JavatoCS
{
    interface QueueInterface<T>
    {
        T push(T element);

        T pop();

        T peek();

        bool isEmpty();

    }
}
