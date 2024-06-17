using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public static class CustomFiqlParser
{
    public static Expression<Func<T, bool>> Parse<T>(string fiqlQuery, Dictionary<string, string> propertyMappings)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var expression = ParseExpression<T>(fiqlQuery, parameter, propertyMappings);
        return Expression.Lambda<Func<T, bool>>(expression, parameter);
    }

    private static Expression ParseExpression<T>(string query, ParameterExpression parameter, Dictionary<string, string> propertyMappings)
    {
        var andConditions = SplitConditions(query, ';');
        var predicate = PredicateBuilder.New<T>(true); // Start with a predicate that is always true

        foreach (var andCondition in andConditions)
        {
            var orConditions = SplitConditions(andCondition, ',');
            var orPredicate = PredicateBuilder.New<T>(false); // Start with a predicate that is always false

            foreach (var orCondition in orConditions)
            {
                var conditionExpression = ParseCondition<T>(orCondition, parameter, propertyMappings);
                var parseExpression = Expression.Lambda<Func<T, bool>>(conditionExpression, parameter);
                orPredicate = orPredicate.Or(parseExpression);
            }

            predicate = predicate.And(orPredicate);
        }

        return predicate.Expand();

    }

    private static IEnumerable<string> SplitConditions(string query, char separator)
    {
        int depth = 0;
        List<int> splitIndexes = new List<int>();

        for (int i = 0; i < query.Length; i++)
        {
            if (query[i] == '(') depth++;
            if (query[i] == ')') depth--;
            if (depth == 0 && query[i] == separator)
            {
                splitIndexes.Add(i);
            }
        }

        splitIndexes.Add(query.Length);

        int start = 0;
        foreach (int index in splitIndexes)
        {
            yield return query.Substring(start, index - start);
            start = index + 1;
        }
    }

    private static Expression ParseCondition<T>(string condition, ParameterExpression parameter, Dictionary<string, string> propertyMappings)
    {
        var (operatorType, property, values) = GetComparisonOperator(condition);

        if (!propertyMappings.TryGetValue(property, out var mappedProperty))
        {
            throw new NotSupportedException($"Property '{property}' is not supported.");
        }

        var propertyExpression = mappedProperty.Split('.').Aggregate((Expression)parameter, Expression.Property);
        return BuildComparisonExpression(propertyExpression, operatorType, values);
    }

    private static (string operatorType, string property, string[] values) GetComparisonOperator(string condition)
    {
        string[] operators = { "==", "!=", "=gt=", "=ge=", "=lt=", "=le=", "=in=", "=out=", "=like=" };
        foreach (var op in operators)
        {
            var parts = condition.Split(new[] { op }, StringSplitOptions.None);
            if (parts.Length == 2)
            {
                var values = parts[1];
                if (values.StartsWith("(") && values.EndsWith(")"))
                {
                    values = values.Substring(1, values.Length - 2); // Remove parentheses
                }
                return (op, parts[0], values.Split(','));
            }
        }

        throw new ArgumentException("Invalid FIQL condition: " + condition);
    }

    private static Expression BuildComparisonExpression(Expression propertyExpression, string comparison, string[] values)
    {
        var propertyType = propertyExpression.Type;
        var constantValues = values.Select(value => Expression.Constant(Convert.ChangeType(value, propertyType))).ToArray();

        return comparison switch
        {
            "==" => Expression.Equal(propertyExpression, constantValues.First()),
            "!=" => Expression.NotEqual(propertyExpression, constantValues[0]),
            "=gt=" => Expression.GreaterThan(propertyExpression, constantValues[0]),
            "=ge=" => Expression.GreaterThanOrEqual(propertyExpression, constantValues[0]),
            "=lt=" => Expression.LessThan(propertyExpression, constantValues[0]),
            "=le=" => Expression.LessThanOrEqual(propertyExpression, constantValues[0]),
            "=in=" => BuildInExpression(propertyExpression, constantValues),
            "=out=" => Expression.Not(Expression.Call(
                typeof(Enumerable),
                "Contains",
                new[] { propertyType },
                Expression.Constant(constantValues.Select(v => v.Value).ToArray()),
                propertyExpression)),
            "=like=" => Expression.Call(
                propertyExpression,
                typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                constantValues[0]),
            _ => throw new NotSupportedException($"Comparison operator '{comparison}' is not supported.")
        };
    }

    private static Expression BuildInExpression(Expression propertyExpression, Expression[] values)
    {
        var propertyType = propertyExpression.Type;
        var arrayType = propertyType.MakeArrayType();
        var arrayExpression = Expression.NewArrayInit(propertyType, values);
        var containsMethod = typeof(Enumerable).GetMethods()
            .First(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2)
            .MakeGenericMethod(propertyType);

        return Expression.Call(containsMethod, arrayExpression, propertyExpression);
    }
}