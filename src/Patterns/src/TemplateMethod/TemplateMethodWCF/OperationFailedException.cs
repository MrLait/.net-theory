using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TemplateMethod.TemplateMethodWCF
{
    [Serializable]
    internal class OperationFailedException : Exception
    {
        private CommunicationException e;

        public OperationFailedException()
        {
        }

        public OperationFailedException(CommunicationException e)
        {
            this.e = e;
        }

        public OperationFailedException(string message) : base(message)
        {
        }

        public OperationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OperationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}