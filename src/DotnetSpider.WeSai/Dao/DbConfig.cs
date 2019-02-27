using SqlSugar;
using System;
using System.Linq;

namespace DotnetSpider.WeSai.Dao
{
	public class DbConfig
	{
		public static string ConnectionString = "server=localhost;Database=wesai;Uid=root;Pwd=qwer1234;SslMode=none;Allow User Variables=True;Charset=utf8";
		public static SqlSugarClient GetDbInstance()
		{
			try
			{
				var db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = ConnectionString, DbType = DbType.MySql, IsAutoCloseConnection = true });
				db.Ado.IsEnableLogEvent = true;
				db.Ado.LogEventStarting = (sql, pars) =>
				{
					Console.WriteLine();
					Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(s => s.ParameterName, s => s.Value)));
					Console.WriteLine();
				};
				return db;
			}
			catch (Exception ex)
			{
				throw new Exception($"连接数据库出错，请检查您的连接字符串，和网络。 ex:{ex.Message}");
			}
		}
	}
}
