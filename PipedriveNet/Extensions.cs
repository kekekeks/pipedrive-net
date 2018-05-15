using System.Linq.Expressions;
using System.Reflection;

namespace PipedriveNet
{
    static class Extensions
    {
        public static PropertyInfo ExtractProperty(this Expression expression)
        {
            return new PropertyVisitor().Find(expression);
        }

        private class PropertyVisitor : ExpressionVisitor
        {
            private PropertyInfo _found;

            public override Expression Visit(Expression node)
            {
                var memberExpression = node as MemberExpression;
                if (memberExpression != null)
                    _found = (PropertyInfo)memberExpression.Member;
                return base.Visit(node);
            }

            public PropertyInfo Find(Expression exp)
            {
                Visit(exp);
                return _found;
            }
        }
    }
}
