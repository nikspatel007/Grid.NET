using System;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    public class DateFilter<T> : FilterBase<T> , IFilter
    {
        public DateFilter(string colName)
        {
            ColName = colName;
            ValType = typeof(DateTime);
            Val = DateTime.MinValue;
            Dflt = DateTime.MinValue;
        }

        public IFilter Replicate(string val)
        {
            DateFilter<T> replicant = new DateFilter<T>(ColName);
            try { replicant.Val = Convert.ToDateTime(val); }
            catch (Exception) { replicant.Val = DateTime.MinValue; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }

        public IFilter Replicate(string val, IFormatProvider format)
        {
            DateFilter<T> replicant = new DateFilter<T>(ColName);
            try { replicant.Val = Convert.ToDateTime(val, format); }
            catch (Exception) { replicant.Val = DateTime.MinValue; }
            replicant.CompareOperator = CompareOperator;
            return replicant;
        }
    }
}