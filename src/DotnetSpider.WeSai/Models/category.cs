using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DotnetSpider.WeSai.Models
{
	///<summary>
	///
	///</summary>
	[SugarTable("ws_category")]
	public partial class category
    {
           public category(){


           }
           /// <summary>
           /// Desc:分类名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:名称代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string namec {get;set;}

           /// <summary>
           /// Desc:分类全称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string fname {get;set;}

           /// <summary>
           /// Desc:全称代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string fnamec {get;set;}

           /// <summary>
           /// Desc:分类logo
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string logo {get;set;}

           /// <summary>
           /// Desc:成立日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? cdate {get;set;}

           /// <summary>
           /// Desc:分类说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string remark {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           public DateTime? ctime {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           public DateTime? utime {get;set;}

    }
}
