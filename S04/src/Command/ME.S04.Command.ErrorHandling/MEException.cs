using System;
using System.Runtime.Serialization;

namespace ME.S04.Command.ErrorHandling
{
    public class MEException : Exception
    {
        public MEException() : base()
        {
        }

        public MEException(string message) : base(message)
        {
        }

        public MEException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MEException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
