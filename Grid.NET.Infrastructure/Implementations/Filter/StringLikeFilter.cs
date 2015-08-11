using System;
using System.Linq.Expressions;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    class StringLikeFilter<T>:FilterBase<T>, IFilter
    {

        public StringLikeFilter(string colName)
        {
            ColName = colName;
            Val = string.Empty;
            Dflt = string.Empty;
            ValType = typeof(string);
        }

        private static readonly Type[] StringTypeArray = { typeof(string) };

        public IFilter Replicate(string val)
        {
            StringLikeFilter<T> replicant = new StringLikeFilter<T>(ColName);
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
            throw new NotImplementedException();
        }
        
        public override Expression BuildExpression()
        {
            if (HasValue)
            {
                return Expression.Call(AsProp, typeof(string).GetMethod("StartsWith", StringTypeArray), AsConst);
            }
            return null;
        }
        
        protected override bool HasValue
        {
            get { return !string.IsNullOrEmpty(Val); }
        }
    }
}
