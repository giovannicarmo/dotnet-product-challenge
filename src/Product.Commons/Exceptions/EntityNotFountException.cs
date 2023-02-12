using System;

namespace Product.Commons.Exceptions
{
    public class EntityNotFountException : SystemException
    {
        public EntityNotFountException(string message) : base(message) { }
    }
}