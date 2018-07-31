using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DMS.EntityFrameworkCore.Extension.MemberInterpreters
{
    public class FieldInfoMemberInterpreter
    {
        public static string InterpreteExpression<T>(System.Linq.Expressions.Expression expression)
           where T : class
        {

            object value = Expression.Lambda(expression).Compile().DynamicInvoke();
            return PrepareElement(value, expression.Type);

        }


        const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public static string PrepareElement(object value, Type elementType)
        {
            if (!elementType.IsGenericType)
                switch (elementType.Name)
                {
                    case "String":
                        {
                            return string.Format("'{0}'", value.ToString().Replace("'", ""));
                        }
                    case "DateTime":
                        {
                            var dt = (DateTime)value;
                            return string.Format("'{0}'", dt.ToString(DateTimeFormat));
                        }
                    case "Boolean":
                        return ((bool)value) ? "1" : "0";
                    default: return value.ToString();
                }
            if (value == null)
                return "NULL";

            if (elementType == typeof(DateTime?))
            {
                var dt = (DateTime?)value;
                return string.Format("'{0}'", dt.Value.ToString(DateTimeFormat));
            }
            else if (elementType == typeof(bool?))
            {
                return ((bool?)value).Value ? "1" : "0";
            }
            else
                return value.ToString();

        }
    }
}
