using System;
using System.Runtime.Serialization;

namespace test1
{
    [Serializable]
    internal class OrderRepeatException : Exception
    {
        public OrderRepeatException()
        {
        }

        public OrderRepeatException(string message) : base(message)
        {
        }

        public OrderRepeatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderRepeatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}