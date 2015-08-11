using System;
using System.Linq.Expressions;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    class GuidExactFilter<T> : FilterBase<T>, IFilter
    {
        public GuidExactFilter(string colName)
        {
            ColName = colName;
            Val = Guid.Empty;
            Dflt = Guid.Empty;
            ValType = typeof(Guid);
        }
        public IFilter Replicate(string val)
        {
            GuidExactFilter<T> replicant = new GuidExactFilter<T>(ColName);
            try { replicant.Val = new Guid(val); }
            catch (Exception) { replicant.Val = DateTime.MinValue; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public IFilter Replicate(string val, IFormatProvider format)
        {
            return Replicate(val);
        }

        public override int CompareOperator { get { return 0; } set { } }

        public override Expression BuildExpression()
        {
            if (Val != Guid.Empty)
            {
                return Expression.Equal(AsProp, AsConst);
            }
            return null;
        }
    }
}
