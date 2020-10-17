using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;


namespace HW3JavatoCS
{
    public class QueueUnderFlowException : Exception
    {
        public QueueUnderFlowException() : base() { }

        public QueueUnderFlowException(string message) : base(message) { }

    }
}
