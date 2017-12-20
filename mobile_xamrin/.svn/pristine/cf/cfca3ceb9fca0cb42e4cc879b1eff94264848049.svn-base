using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace VirtualEvent
{
	public interface IRepository<T> where T : IEntity
	{
		void Insert(T entity);
		void Delete(T entity);
		void DeleteAll();
		void Update(T entity);
		T Get(int Id);
		List<T> GetAll();
	}
	public class IEntity
	{
		[PrimaryKey, AutoIncrement]
		public int PkId { get; set; }
	}
}

