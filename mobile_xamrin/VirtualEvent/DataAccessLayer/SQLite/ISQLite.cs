using System;
using SQLite.Net;

namespace VirtualEvent
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
