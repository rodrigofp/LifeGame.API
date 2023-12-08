using SkillService.Data;
using SkillService.Models;
using SkillService.Utils;
using System.Linq.Expressions;

namespace SkillService.Repositories
{
	public abstract class RepositoryBase<T> : IRepository<T>
		where T : Entity
	{
		private readonly SkillDbContext _db;

		protected RepositoryBase(SkillDbContext db)
		{
			_db = db;
		}

		#region READ

		public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
		{
			return _db.Set<T>().Where(filter).IncludeAll(includes).ToList();
		}

		public T GetById(int id, params Expression<Func<T, object>>[] includes)
		{
			return _db.Set<T>().IncludeAll(includes).FirstOrDefault(x => x.Id == id)
				?? throw new KeyNotFoundException($"{nameof(T)} not found");
		}

		#endregion

		#region WRITE

		public void Create(T entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			_db.Set<T>().Add(entity);
		}

		public void Delete(int id)
		{
			var entity = _db.Set<T>().Find(id);

			if (entity == null) throw new KeyNotFoundException($"{nameof(T)} not found");

			_db.Set<T>().Remove(entity);
		}

		public void Dispose()
		{
			_db.Dispose();
		}

		public bool SaveChanges()
		{
			return _db.SaveChanges() > 0;
		}

		public void Update(int id, T entity)
		{
			var oldEntity = _db.Set<T>().Find(id);

			if (oldEntity == null) throw new KeyNotFoundException($"{nameof(T)} not found");

			_db.Set<T>().Update(entity);
		}

		#endregion
	}
}
