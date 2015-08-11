using System;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    class IntFilter<T>:FilterBase<T>, IFilter
    {
        public IntFilter(string colName)
        {
            ColName = colName;
            Val = -1;
            Dflt = -1;
            ValType = typeof(Int32);
        }

        public IFilter Replicate(string val)
        {
            IntFilter<T> replicant = new IntFilter<T>(ColName);
            try { replicant.Val = Convert.ToInt32(val); }
            catch (Exception) { replicant.Val = -1; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public IFilter Replicate(string val, IFormatProvider format)
        {
            IntFilter<T> replicant = new IntFilter<T>(ColName);
            try { replicant.Val = Convert.ToInt32(val, format); }
            catch (Exception) { replicant.Val = -1; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

    }
}
