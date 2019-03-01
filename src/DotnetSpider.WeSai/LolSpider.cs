using DotnetSpider.Extension;
using DotnetSpider.Extension.Model;
using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction.Model;
using DotnetSpider.Extraction.Model.Attribute;
using DotnetSpider.WeSai.Dao;
using DotnetSpider.WeSai.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DotnetSpider.WeSai
{
	public class LolSpiderConsolePipeline : EntityPipeline
	{
		protected override int Process(List<IBaseEntity> items, dynamic sender = null)
		{
			foreach (var data in items)
				Console.WriteLine($"{JsonConvert.SerializeObject(data)}");
			return items.Count;
		}
	}

	public class LPLSpiderDBPipeline : EntityPipeline
	{
		protected override int Process(List<IBaseEntity> items, dynamic sender = null)
		{
			var db = DbConfig.GetDbInstance();
			var modelList = new List<game>();
			var currentData = DateTime.Now;

			foreach (var data in items)
			{
				var model = (LOLDuowan)data;

				modelList.Add(new game()
				{
					cgname = "LPL",
					season = "2019春季赛",
					ctime = currentData,
					utime = currentData,
					gtime = DateTime.Parse($"{currentData.Year}-{model.info_date} {model.info_hour}"),
					teama = model.teama,
					teamb = model.teamb,
					scorea = byte.Parse(model.scorea),
					scoreb = byte.Parse(model.scoreb),
					status = model.info_status,
					remark = ""
				});

				Console.WriteLine($"{JsonConvert.SerializeObject(data)}");
			}

			db.Ado.UseTran(() =>
			{
				db.Ado.ExecuteCommand("DELETE FROM GAME WHERE CGNAME='LPL'");
				db.Insertable(modelList.ToArray()).ExecuteCommand();
			});

			return items.Count;
		}
	}

	public class LCKSpiderDBPipeline : EntityPipeline
	{
		protected override int Process(List<IBaseEntity> items, dynamic sender = null)
		{
			var db = DbConfig.GetDbInstance();
			var modelList = new List<game>();
			var currentData = DateTime.Now;

			foreach (var data in items)
			{
				var model = (LOLDuowan)data;

				modelList.Add(new game()
				{
					cgname = "LCK",
					season = "2019春季赛",
					ctime = currentData,
					utime = currentData,
					gtime = DateTime.Parse($"{currentData.Year}-{model.info_date} {model.info_hour}"),
					teama = model.teama,
					teamb = model.teamb,
					scorea = byte.Parse(model.scorea),
					scoreb = byte.Parse(model.scoreb),
					status = model.info_status,
					remark = ""
				});

				Console.WriteLine($"{JsonConvert.SerializeObject(data)}");
			}

			db.Ado.UseTran(() =>
			{
				db.Ado.ExecuteCommand("DELETE FROM GAME WHERE CGNAME='LCK'");
				db.Insertable(modelList.ToArray()).ExecuteCommand();
			});

			return items.Count;
		}
	}

	public class LPLSpider : EntitySpider
	{
		protected override void OnInit(params string[] arguments)
		{
			AddRequests("http://lol.duowan.com/LPL");
			AddEntityType<LOLDuowan>();
			AddPipeline(new LPLSpiderDBPipeline());
		}
	}

	public class LCKSpider : EntitySpider
	{
		protected override void OnInit(params string[] arguments)
		{
			AddRequests("http://lol.duowan.com/LCK");
			AddEntityType<LOLDuowan>();
			AddPipeline(new LCKSpiderDBPipeline());
		}
	}

	[Entity(Expression = "//div[@class='match-container']")]
	public class LOLDuowan : BaseEntity
	{
		[Field(Expression = "./div[1]/.")]
		public string title { get; set; }

		[Field(Expression = "./div[2]/div[1]/.")]
		public string info_date { get; set; }

		[Field(Expression = "./div[2]/div[2]/.")]
		public string info_hour { get; set; }

		[Field(Expression = "./div[2]/div[3]/.")]
		public string info_status { get; set; }

		[Field(Expression = "./div[3]/div[1]/div[1]/.")]
		public string teama { get; set; }

		[Field(Expression = "./div[3]/div[3]/div[1]/.")]
		public string teamb { get; set; }

		[Field(Expression = "./div[3]/div[2]/div[1]/span[1]/.")]
		public string scorea { get; set; }

		[Field(Expression = "./div[3]/div[2]/div[1]/span[2]/.")]
		public string scoreb { get; set; }
	}
}
