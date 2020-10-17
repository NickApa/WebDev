using System;
using System.Collections.Generic;
using System.Text;
//using "QueueInterface.cs";

namespace HW3JavatoCS
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        public T Push(T element)
        {
            if(element == null)
            {
                throw new NullReferenceException();
            }
            if(IsEmpty())
            {
                Node<T> temp = new Node<T>(element, null);
                rear = front = temp; 
            }
            else
            {
                Node<T> temp = new Node<T>(element, null);
                rear.next = temp;
                rear = temp;
            }

            return element;
        }

        public T Pop()
        {
            T temp;
            if(IsEmpty())
            {
                throw new QueueUnderFlowException("The Queue was empty when pop was involved");
            }
            else if(front == rear)
            {
                temp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                temp = front.data;
                front = front.next;
            }
            return temp;
        }

        public T Peek()
        {
            if(IsEmpty())
            {
                throw new QueueUnderFlowException("The Queue was empty when peek was involved");
            }
            return front.data;
        }


         public bool IsEmpty()
        {
            if(front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
