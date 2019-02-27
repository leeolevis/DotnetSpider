using System;
using System.Collections.Generic;
using System.Text;
using DotnetSpider.Core.Pipeline;
using DotnetSpider.Downloader;
using DotnetSpider.Extension;
using DotnetSpider.Extension.Model;
using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction;
using DotnetSpider.Extraction.Model;
using DotnetSpider.Extraction.Model.Attribute;
using Newtonsoft.Json;

namespace DotnetSpider.Sample.docs
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

	public class LolSpiderDBPipeline : EntityPipeline
	{
		protected override int Process(List<IBaseEntity> items, dynamic sender = null)
		{
			foreach (var data in items)
				Console.WriteLine($"{JsonConvert.SerializeObject(data)}");
			return items.Count;
		}
	}


	public class LolSpider : EntitySpider
	{
		protected override void OnInit(params string[] arguments)
		{
			AddRequests("http://lol.duowan.com/LPL");
			AddEntityType<LOLDuowan>();
			AddPipeline(new LolSpiderConsolePipeline());
		}

		[Schema("wesai", "duowan")]
		[Entity(Expression = "//div[@class='match-container']")]
		class LOLDuowan : BaseEntity
		{
			[Column]
			[Field(Expression = "./div[1]/.")]
			public string title { get; set; }

			[Column]
			[Field(Expression = "./div[2]/div[1]/.")]
			public string info_date { get; set; }

			[Column]
			[Field(Expression = "./div[2]/div[2]/.")]
			public string info_hour { get; set; }


			[Column]
			[Field(Expression = "./div[2]/div[3]/.")]
			public string info_status { get; set; }
		}
	}
}
