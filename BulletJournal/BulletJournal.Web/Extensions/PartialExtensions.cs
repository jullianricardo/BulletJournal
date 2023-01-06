using Microsoft.AspNetCore.Html;
using System.Linq.Expressions;

namespace BulletJournal.Web.Extensions
{
    public static class PartialExtensions
    {
        public static IHtmlContent Display<T>
            (this T model, Expression<Func<T, Func<object, IHtmlContent>>> content)
        {
            var compiled = content.Compile();
            return compiled.Invoke(model).Invoke(null);
        }
    }
}
