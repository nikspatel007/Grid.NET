using System;
using System.Linq.Expressions;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    class StringExactFilter<T>:FilterBase<T>, IFilter
    {
        public StringExactFilter(string colName)
        {
            ColName = colName;
            Val = string.Empty;
            Dflt = string.Empty;
            ValType = typeof(string);
        }

        public IFilter Replicate(string val)
        {
            StringExactFilter<T> replicant = new StringExactFilter<T>(ColName);
            if (string.IsNullOrWhiteSpace(val)) { Val = string.Empty; }
            else { Val = val; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public IFilter Replicate(string val, IFormatProvider format)
        {
            return Replicate(val);
        }


        public override int CompareOperator { get { return 0; } set { } }

        public void Clear()
        {
            Val = string.Empty;
        }
        
        public override Expression BuildExpression()
        {
            if (HasValue)
            {
                return Expression.Equal(AsProp, AsConst);
            }
            return null;
        }

        protected override bool HasValue
        {
            get { return !string.IsNullOrEmpty(Val); }
        }

    }
}
