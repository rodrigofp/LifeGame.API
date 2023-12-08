using QuestsService.Data;
using QuestsService.Models;
using QuestsService.Utils;
using System.Linq.Expressions;

namespace QuestsService.Repositories
{
	public abstract class RepositoryBase<T> : IRepository<T>
		where T : Entity
	{
		private readonly QuestDbContext _db;

		protected RepositoryBase(QuestDbContext db)
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

		public bool Exists(int id)
		{
			return _db.Set<T>().Any(x =>  x.Id == id);
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
