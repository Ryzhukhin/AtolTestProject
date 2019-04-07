using System;

namespace Project.Bll.Core.Exceptions
{
    public class BllException:Exception
    {
        public BllException(string message):base(message)
        {

        }

        public BllException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
