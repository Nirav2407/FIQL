using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Shopping.API.Helper
{
    public static class FiqlParser
    {
        public static Expression<Func<T, bool>> Parse<T>(string fiqlQuery, Dictionary<string, string> propertyMappings)
        {

            var parameter = Expression.Parameter(typeof(T), "x");
            var conditions = fiqlQuery.Split(',');
            Expression finalExpression = null;

            foreach (var condition in conditions)
            {
                var comparison = GetComparisonOperator(condition, out string property, out string value);

                if (!propertyMappings.TryGetValue(property, out var mappedProperty))
                {
                    throw new NotSupportedException($"Property '{property}' is not supported.");
                }

                var propertyExpression = mappedProperty.Split('.').Aggregate((Expression)parameter, Expression.Property);
                var constantExpression = Expression.Constant(Convert.ChangeType(value, propertyExpression.Type));
                Expression comparisonExpression = comparison switch
                {
                    "==" => Expression.Equal(propertyExpression, constantExpression),
                    ">" => Expression.GreaterThan(propertyExpression, constantExpression),
                    "<" => Expression.LessThan(propertyExpression, constantExpression),
                    ">=" => Expression.GreaterThanOrEqual(propertyExpression, constantExpression),
                    "<=" => Expression.LessThanOrEqual(propertyExpression, constantExpression),
                    _ => throw new NotSupportedException($"Comparison '{comparison}' is not supported.")
                };

                finalExpression = finalExpression == null ? comparisonExpression : Expression.OrElse(finalExpression, comparisonExpression);
            }

            return Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
        }

        private static string GetComparisonOperator(string condition, out string property, out string value)
        {
            string[] operators = { "==", "=gt=", "=lt=", "=ge=", "=le=" };
            foreach (var op in operators)
            {
                var parts = condition.Split(new[] { op }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    property = parts[0];
                    value = parts[1];
                    return op switch
                    {
                        "==" => "==",
                        "=gt=" => ">",
                        "=lt=" => "<",
                        "=ge=" => ">=",
                        "=le=" => "<=",
                        _ => throw new NotSupportedException($"Comparison '{op}' is not supported.")
                    };
                }
            }

            throw new ArgumentException("Invalid FIQL condition: " + condition);
        }
    }
}
