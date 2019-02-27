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

namespace DotnetSpider.Sample.docs
{
	public class LolSpider : EntitySpider
	{
		protected override void OnInit(params string[] arguments)
		{
			AddRequests("http://lol.duowan.com/LPL");

			//Downloader = new HttpClientDownloader();
			//Downloader.AddAfterDownloadCompleteHandler(new ReplaceHandler());

			AddEntityType<LOLDuowan>();
			AddPipeline(new ConsoleEntityPipeline());
			//AddPipeline(new CollectionEntityPipeline());	
		}


		class ReplaceHandler : AfterDownloadCompleteHandler
		{
			public override void Handle(ref Response page, IDownloader downloader)
			{

			}
		}

		[Schema("wesai", "duowan")]
		[Entity(Expression = "//div[@class='match-container']")]
		class LOLDuowan : BaseEntity
		{
			//[Column]
			//[Field(Expression = "categoryname", Type = SelectorType.Enviroment)]
			//public string CategoryName { get; set; }

			//[Column]
			//[Field(Expression = ".")]
			//public string content { get; set; }

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

			//[Column]
			//[Unique("CITYID_RUNID")]
			//[Field(Expression = "Today", Type = SelectorType.Enviroment)]
			//public DateTime run_id { get; set; }
		}
	}
}
