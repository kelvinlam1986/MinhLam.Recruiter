using System;

namespace MinhLam.Framework
{
    public class OperationException : Exception
    {
        public string Code { get; }

        public OperationException() : this(OperationExceptionCodes.InnerOperationProgram, OperationExceptionCodes.InnerOperationProgramMessage)
        {
        }

        public OperationException(string code)
        {
            Code = code;
        }

        public OperationException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public OperationException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public OperationException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public OperationException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }

    public class OperationExceptionCodes
    {
        public const string InnerOperationProgram = "inner_operation_program";
        public const string InnerOperationProgramMessage = "Có lỗi xảy ra trong chương trình xin liên hệ quản trị phần mếm";
    }
}
