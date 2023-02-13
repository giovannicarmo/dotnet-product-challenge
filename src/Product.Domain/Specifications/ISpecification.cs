using System;
using System.Linq.Expressions;

namespace Product.Domain.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}