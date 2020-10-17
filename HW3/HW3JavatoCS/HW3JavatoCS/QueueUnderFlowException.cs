using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;


namespace HW3JavatoCS
{
    class QueueUnderFlowException : Exception
    {
        QueueUnderFlowException() : base() { }

        QueueUnderFlowException(string message) : base(message) { }

    }
}
