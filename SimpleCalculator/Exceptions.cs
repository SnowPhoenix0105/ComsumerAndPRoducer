using System;


namespace SimpleCalculator
{
    [System.Serializable]
    public class SyntaxException : System.Exception
    {
        public SyntaxException() { }

        public SyntaxException(int index, char ch) : base($"syntax-error at [{index}]{ch}") { }
        public SyntaxException(string message) : base(message) { }
        public SyntaxException(string message, System.Exception inner) : base(message, inner) { }
        protected SyntaxException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [System.Serializable]
    public class ExpressionTooShortException : System.Exception
    {
        public ExpressionTooShortException() { }
        public ExpressionTooShortException(string message) : base(message) { }
        public ExpressionTooShortException(string message, System.Exception inner) : base(message, inner) { }
        protected ExpressionTooShortException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

