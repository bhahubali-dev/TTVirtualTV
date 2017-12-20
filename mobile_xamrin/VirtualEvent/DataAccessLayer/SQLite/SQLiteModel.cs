using System;
using SQLite.Net.Attributes;

namespace VirtualEvent
{
	public class SQLiteModel
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public DateTime CreatedOn { get; set; }
		public SQLiteModel()
		{
		}
	}
}
