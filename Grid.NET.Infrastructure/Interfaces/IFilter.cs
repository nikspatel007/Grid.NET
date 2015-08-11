using System;
using System.Linq.Expressions;

namespace Grid.NET.Infrastructure.Interfaces
{
    public interface IFilter
    {
        //void SetVal(string val);
        //void SetVal(string val, IFormatProvider format);
        //void Clear();

        /// <summary>
        /// Generates the expression fragment belonging to this filter
        /// </summary>
        /// <returns>an expression if this filter has a value, otherwise null</returns>
        Expression BuildExpression();

        /// <summary>
        /// Copies this filter to a new filter object having the specified value
        /// </summary>
        /// <param name="val">the value the new filter should have</param>
        /// <returns></returns>
        IFilter Replicate(string val);

        /// <summary>
        /// Copies this filter to a new filter object having the specified value, using the specified format to parse that value
        /// </summary>
        /// <param name="val">the value the new filter should have</param>
        /// <param name="format">the format that should be used to parse the value</param>
        /// <returns></returns>
        IFilter Replicate(string val, IFormatProvider format);
 
    }
}