﻿using DotnetSpider.Extension;
using DotnetSpider.Extension.Downloader;
using DotnetSpider.Extension.Infrastructure;
using DotnetSpider.Extension.Model;
using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction;
using DotnetSpider.Extraction.Model;
using DotnetSpider.Extraction.Model.Attribute;
using System.Collections.Generic;

namespace DotnetSpider.Sample.docs
{
	public class WebDriverDownloaderSpider : EntitySpider
	{
		protected override void OnInit(params string[] arguments)
		{
			Downloader = new WebDriverDownloader(Browser.Chrome);
			AddRequest("https://list.jd.com/list.html?cat=1713,3263,3395", new Dictionary<string, object> { { "name", "童书" }, { "cat", "幼儿启蒙" } });
			AddPipeline(new ConsoleEntityPipeline());
			AddEntityType<Product>();
		}

		//[Target(XPaths = new[] { "//span[@class=\"p-num\"]" }, Patterns = new[] { @"&page=[0-9]+&" })]//点击分页
		[Schema("test","sku",TableNamePostfix = TableNamePostfix.Today)]
		[Entity(Expression = "//li[@class='gl-item']/div[contains(@class,'j-sku-item')]")]
		class Product : IBaseEntity
		{
			[Field(Expression = "name", Type = SelectorType.Enviroment)]
			[Index("CAT")]
			[Unique("CAT_SKU")]
			[Column(Length =20)]
			public string CategoryName { get; set; }

			[Field(Expression = "cat", Type = SelectorType.Enviroment)]
			[Column(Length = 20)]
			public string CategoryId { get; set; }

			[Field(Expression = "./div[1]/a/@href")]
			[Column(Length = 20)]
			public string Url { get; set; }

			[Field(Expression = "./div[1]/a/img/@data-lazy-img")]
			//[Field(Expression = ".//div[@class='p-img']/a/img/@data-lazy-img")]
			[Column(Length = 20)]
			public string Pic { get; set; }

			[Field(Expression = "./@data-sku")]
			[Column(Length = 20)]
			[Unique("CAT_SKU")]
			[Unique("SKU")]
			public string Sku { get; set; }

			[Field(Expression = "./div[5]/strong/a")]
			[Column()]
			public string CommentsCount { get; set; }

			[Field(Expression = ".//div[@class='p-shop']/@data-shop_name")]
			[Column(Length = 200)]
			public string ShopName { get; set; }

			[Field(Expression = ".//div[@class='p-name']/a/em")]
			[Column(Length = 20)]
			public string Name { get; set; }

			[Field(Expression = "./@venderid")]
			[Column(Length = 20)]
			public string VenderId { get; set; }

			[Field(Expression = "./@jdzy_shop_id")]
			[Column(Length = 20)]
			public string JdzyShopId { get; set; }
		}
	}
}