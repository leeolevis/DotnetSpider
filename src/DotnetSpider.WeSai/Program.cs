using DotnetSpider.WeSai.Dao;
using System;
using System.Text;

namespace DotnetSpider.WeSai
{
	public class Program
	{
		static void Main(string[] args)
		{
#if NETCOREAPP
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#else
			ThreadPool.SetMinThreads(256, 256);
#endif

			//var db = DbConfig.GetDbInstance();
			////Create all class
			//db.DbFirst.CreateClassFile("d:\\DemoOracle\\1");

			new LPLSpider().Run();

			new LCKSpider().Run();
		}
	}
}
