using System;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    class DecimalFilter<T>:FilterBase<T>, IFilter
    {

        public DecimalFilter(string colName)
        {
            ColName = colName;
            ValType = typeof(Decimal);
            Dflt = decimal.MinValue;
            Val = decimal.MinValue;
        }
        
        public IFilter Replicate(string val)
        {
            DecimalFilter<T> replicant = new DecimalFilter<T>(ColName);
            try { replicant.Val = Convert.ToDecimal(val); }
            catch (Exception) { replicant.Val = decimal.MinValue; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public IFilter Replicate(string val, IFormatProvider format)
        {
            DecimalFilter<T> replicant = new DecimalFilter<T>(ColName);
            try { replicant.Val = Convert.ToDecimal(val, format); }
            catch (Exception) { replicant.Val = decimal.MinValue; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

    }
}
