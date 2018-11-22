using System;

namespace Refactoring
{
    public class ResponseMsg
    {
        private string message;
        private ErrorCode errorCode;
        private int id;

        public ErrorCode ErrorCode
        {
            get
            {
                return errorCode;
            }
            set
            {
                errorCode = value;
            }
        }

        public string Message
        {
            get 
            {
                return message;
            }
            set 
            {
                message = value;
            }
        }

        public int Id
        {
            get {
                return id;
            }
            set {
                id = value;
            }
        }
    }
}
