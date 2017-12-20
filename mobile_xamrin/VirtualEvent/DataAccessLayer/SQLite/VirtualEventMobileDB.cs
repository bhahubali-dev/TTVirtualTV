using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;

namespace VirtualEvent
{
	public class VirtualEventMobileDB
	{
		private SQLiteConnection _connection;
		public interface IRepository<T> where T : IEntity
		{

			IEnumerable<T> List { get; }
			void Add(T entity);
			void Delete(T entity);
			void Update(T entity);
			T FindById(int Id);
		}
		public VirtualEventMobileDB()
		{
			_connection.CreateTable<SQLiteModel>();
		}
		public IEnumerable<SQLiteModel> GetAll()
		{
			return (from t in _connection.Table<SQLiteModel>()
					select t).ToList();
		}

		public SQLiteModel GetData(int id)
		{
			return _connection.Table<SQLiteModel>().FirstOrDefault(t => t.ID == id);
		}

		public void DeleteData(int id)
		{
			_connection.Delete<SQLiteModel>(id);
		}

		public void AddData(string value)
		{
			var newData = new SQLiteModel
			{
				CreatedOn = DateTime.Now
			};

			_connection.Insert(newData);
		}
	}
}
