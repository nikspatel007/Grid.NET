using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace Grid.NET.Infrastructure.Extensions
{
    public static class PropertyExtensions
    {
        public static string GetDisplayName<TModel, TProperty>(this TModel model,
          Expression<Func<TModel, TProperty>> expression)
        {
            return ModelMetadata.FromLambdaExpression(
                expression,
                new ViewDataDictionary<TModel>(model)
                ).DisplayName ?? "Not Available";
        }

        public static String GetDisplayName(Type type, PropertyInfo info, bool hasMetaDataAttribute)
        {
            if (!hasMetaDataAttribute)
            {
                object[] attributes = info.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if (attributes.Length > 0)
                {
                    var displayName = (DisplayNameAttribute)attributes[0];
                    return displayName.DisplayName;
                }
                return info.Name;
            }
            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(type).Find(info.Name, true);
            DisplayNameAttribute displayAttribute =
                propDesc.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            return displayAttribute != null ? displayAttribute.DisplayName : null;
        }
    }
}