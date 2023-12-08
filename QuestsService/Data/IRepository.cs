using QuestsService.Models;
using System.Linq.Expressions;

namespace QuestsService.Data
{
	public interface IRepository<T> where T : Entity
	{
		#region READ

		IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
		T GetById(int id, params Expression<Func<T, object>>[] includes);
		bool Exists(int id);

		#endregion

		#region WRITE

		void Create(T entity);
		void Delete(int id);
		void Dispose();
		bool SaveChanges();
		void Update(int id, T entity);

		#endregion
	}
}
