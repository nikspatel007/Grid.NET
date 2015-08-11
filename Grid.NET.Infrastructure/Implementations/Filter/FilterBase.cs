using System;
using System.Linq.Expressions;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    /// <summary>
    /// Servers as the base class for the primitive filters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FilterBase<T>
    {
        protected FilterBase()
        {
            Compare = 0;
        }

        public static readonly ParameterExpression Param = Expression.Parameter(typeof(T), "x");

        protected string ColName;
        protected dynamic Val;
        protected dynamic Dflt;
        protected Type ValType;

        protected int Compare;

        protected MemberExpression AsProp
        {
            get { return Expression.Property(Param, ColName); }
        }

        protected ConstantExpression AsConst
        {
            get { return Expression.Constant(Val, ValType); }
        }

        protected virtual bool HasValue { get { return Val != Dflt; } }

        /// <summary>
        /// if applicable, used to determind whether the expression outypue uses >=, <=, or ==.
        /// </summary>
        public virtual int CompareOperator { get { return Compare; } set { Compare = value; } }

        public virtual void Clear() { Val = Dflt; }

        public virtual Expression BuildExpression()
        {
            if (HasValue)
            {
                if (Compare < 0)
                {
                    return Expression.LessThanOrEqual(AsProp, AsConst);
                }
                else if (Compare > 0)
                {
                    return Expression.GreaterThanOrEqual(AsProp, AsConst);
                }
                else
                {
                    return Expression.Equal(AsProp, AsConst);
                }
            }
            return null;
        }
    }
}