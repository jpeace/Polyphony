using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Polyphony.Domain.Construction
{
    public static class ExpressionExtensions
    {
        public static MemberInfo FindProperty(this LambdaExpression lambdaExpression)
        {
            Expression operand = lambdaExpression;
            bool flag = false;
            while(!flag)
            {
                MemberExpression expression;
                ExpressionType nodeType = operand.NodeType;

                if (nodeType != ExpressionType.Convert)
                {
                    switch(nodeType)
                    {
                        case ExpressionType.Lambda:
                            operand = ((LambdaExpression) operand).Body;
                            continue;
                        case ExpressionType.Invoke:
                            operand = ((InvocationExpression) operand).Expression;
                            continue;
                        case ExpressionType.MemberAccess:
                            expression = (MemberExpression) operand;
                            if(expression.Expression.NodeType != ExpressionType.Parameter 
                                && expression.Expression.NodeType != ExpressionType.Convert
                                && expression.Expression.NodeType != ExpressionType.Constant)
                            {
                                throw new ArgumentException(string.Format("Expression '{0}' must resolve to top-level member.", lambdaExpression), "lambdaExpression");
                            }

                            return expression.Member;
                        default:
                            flag = true;
                            break;
                    }
                }
                else
                {
                    operand = ((UnaryExpression)operand).Operand;
                    continue;
                }
            }

            return null;
        }
    }
}