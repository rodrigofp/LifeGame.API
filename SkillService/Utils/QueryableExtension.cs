using Microsoft.EntityFrameworkCore;
using SkillService.Models;
using System.Linq.Expressions;

namespace SkillService.Utils
{
	public static class QueryableExtensions
	{
		public static IQueryable<TEntity> IncludeAll<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
			where TEntity : Entity
		{
			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return query;
		}
	}
}
