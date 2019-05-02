using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.BLL.Infrastructure
{
    class ValidationException : Exception
    {
        public string Property { get; set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
