using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;

namespace VirtualEvent
{
	public class Repository<T> : IRepository<T> where T : IEntity
	{
		private SQLiteConnection _connection;
		public Repository(SQLiteConnection connection)
		{
			_connection = connection;
			_connection.CreateTable<T>();
		}
		public void Delete(T entity)
		{
			_connection.Delete(entity);
			_connection.Commit();
		}

		public void DeleteAll()
		{
			_connection.DeleteAll<T>();
			_connection.Commit();
		}

		public T Get(int Id)
		{
			var query = from c in _connection.Table<T>()
						where c.PkId == Id
						select c;

			return query.FirstOrDefault();
		}

		public List<T> GetAll()
		{
			var query = from c in _connection.Table<T>()
						select c;
			return query.ToList();
		}

		public void Insert(T entity)
		{
			_connection.Insert(entity);
			_connection.Commit();
		}

		public void Update(T entity)
		{
			_connection.Update(entity);
			_connection.Commit();
		}
	}
}
