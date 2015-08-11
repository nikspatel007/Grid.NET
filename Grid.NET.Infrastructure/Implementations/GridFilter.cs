using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Grid.NET.Infrastructure.Implementations.Filter;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations
{
    public class GridFilter<T>
    {
        private readonly Dictionary<string, IFilter> _filtersDictionary;
        private static readonly Dictionary<string, IFilter> FilterConstruct;

        #region \\\\\\\\\ Construction

        static GridFilter()
        {
            FilterConstruct = new Dictionary<string, IFilter>();

            foreach (var prop in typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var A = prop.GetCustomAttribute<FiltrationAttribute>();
                if (A != null)
                {
                    var p = prop.Name.ToLower();
                    switch (prop.PropertyType.Name)
                    {
                        case "String":
                            if (A.Filter == Enums.FilterType.Exact)
                            {
                                FilterConstruct.Add(p, new StringExactFilter<T>(p));
                            }
                            else if (A.Filter == Enums.FilterType.StringLike)
                            {
                                FilterConstruct.Add(p, new StringLikeFilter<T>(p));
                            }
                            else
                            {
                                throw new ArgumentException("Error - Cannot apply range filter to type System.String");
                            }
                            break;
                        case "Int32":
                            if (A.Filter == Enums.FilterType.Range)
                            {
                                FilterConstruct.Add(string.Concat(p, "lw"), new IntFilter<T>(p) {CompareOperator = 1});
                                FilterConstruct.Add(string.Concat(p, "up"), new IntFilter<T>(p) {CompareOperator = -1});
                            }
                            else if (A.Filter == Enums.FilterType.Exact)
                            {
                                FilterConstruct.Add(p, new IntFilter<T>(p));
                            }
                            else
                            {
                                throw new ArgumentException(
                                    "Error - Cannot apply StringLike filter to type System.Int32");
                            }
                            break;
                        case "Decimal":
                            if (A.Filter == Enums.FilterType.Range)
                            {
                                FilterConstruct.Add(string.Concat(p, "lw"),
                                    new DecimalFilter<T>(p) {CompareOperator = 1});
                                FilterConstruct.Add(string.Concat(p, "up"),
                                    new DecimalFilter<T>(p) {CompareOperator = -1});
                            }
                            else if (A.Filter == Enums.FilterType.Exact)
                            {
                                FilterConstruct.Add(p, new DecimalFilter<T>(p));
                            }
                            else
                            {
                                throw new ArgumentException(
                                    "Error - Cannot apply StringLike filter to type System.Decimal");
                            }
                            break;
                        case "DateTime":
                            if (A.Filter == Enums.FilterType.Range)
                            {
                                FilterConstruct.Add(string.Concat(p, "lw"), new DateFilter<T>(p) {CompareOperator = 1});
                                FilterConstruct.Add(string.Concat(p, "up"), new DateFilter<T>(p) {CompareOperator = -1});
                            }
                            else if (A.Filter == Enums.FilterType.Exact)
                            {
                                throw new ArgumentException("Error - Cannot apply Exact filter to type System.DateTime");
                            }
                            else
                            {
                                throw new ArgumentException(
                                    "Error - Cannot apply StringLike filter to type System.DateTime");
                            }
                            break;
                        case "Guid":
                            if (A.Filter == Enums.FilterType.Range)
                            {
                                throw new ArgumentException("Error - Cannot apply Range filter to type System.Guid");
                            }
                            if (A.Filter == Enums.FilterType.Exact)
                            {
                                FilterConstruct.Add(p, new GuidExactFilter<T>(p));
                            }
                            else
                            {
                                throw new ArgumentException("Error - Cannot apply StringLike filter to type System.Guid");
                            }
                            break;
                        case "Boolean":
                            if (A.Filter == Enums.FilterType.Range)
                            {
                                throw new ArgumentException("Error - Cannot apply Range filter to type System.Boolean");
                            }
                            if (A.Filter == Enums.FilterType.Exact)
                            {
                                FilterConstruct.Add(p, new BoolFilter<T>(p));
                            }
                            else
                            {
                                throw new ArgumentException(
                                    "Error - Cannot apply StringLike filter to type System.Boolean");
                            }
                            break;
                    }
                }
            }
        }

        public GridFilter()
        {
            _filtersDictionary = new Dictionary<string, IFilter>();
            Build(null);
        }

        public GridFilter(string filters)
        {
            _filtersDictionary = new Dictionary<string, IFilter>();
            if (!string.IsNullOrWhiteSpace(filters))
            {
                var D = new Dictionary<string, string>();
                try
                {
                    var ary = filters.Replace("{", "").Replace("}", "").Split(',');

                    foreach (var S in ary)
                    {
                        var ary2 = S.Split(':');
                        D.Add(ary2[0].ToLower(), ary2[1]);
                    }
                }
                catch (Exception)
                {
                    D.Clear();
                }
                Build(D);
            }
        }

        public GridFilter(IDictionary<string, string> filters)
        {
            _filtersDictionary = new Dictionary<string, IFilter>();
            Build(filters);
        }
       
        #endregion

        #region \\\\\\\\\ expression building

        public Func<T, bool> CompileFunction()
        {
            Expression resultExpression = null;
            foreach (var f in _filtersDictionary.Values)
            {
                Combine(ref resultExpression, f.BuildExpression());
            }
            if (resultExpression == null)
            {
                return t => true;
            }
            return Expression.Lambda<Func<T, bool>>(resultExpression, FilterBase<T>.Param).Compile();
        }

        #endregion

        #region Private functions

        private void Build(IDictionary<string, string> filters)
        {
            if (filters != null && filters.Count > 0)
            {
                foreach (var k in filters)
                {
                    if (FilterConstruct.ContainsKey(k.Key))
                    {
                        _filtersDictionary.Add(k.Key, FilterConstruct[k.Key].Replicate(k.Value));
                    }
                }
            }
        }

        private void Combine(ref Expression left, Expression right)
        {
            if (right != null)
            {
                left = left != null ? Expression.AndAlso(left, right) : right;
            }
        }

        #endregion

    }
}