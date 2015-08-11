using System;
using System.Linq.Expressions;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    public class BoolFilter<T> : FilterBase<T>, IFilter
    {

        public BoolFilter(string colName)
        {
            ColName = colName;
            Val = null;
            Dflt = null;
            ValType = typeof(bool?);
        }

        public IFilter Replicate(string val)
        {
            BoolFilter<T> replicant = new BoolFilter<T>(ColName);
            try { replicant.Val = Convert.ToBoolean(val); }
            catch (Exception) { replicant.Val = null; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public IFilter Replicate(string val, IFormatProvider format)
        {
            BoolFilter<T> replicant = new BoolFilter<T>(ColName);
            try { replicant.Val = Convert.ToBoolean(val, format); }
            catch (Exception) { replicant.Val = null; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public override int CompareOperator { get { return 0; } set { } }

        public override Expression BuildExpression()
        {
            return HasValue ? Expression.Equal(AsProp, AsConst) : null;
        }

        protected override bool HasValue
        {
            get { return ((bool?)Val).HasValue; }
        }
    }
}