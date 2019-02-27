using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DotnetSpider.WeSai.Models
{
	///<summary>
	///
	///</summary>
	public partial class game
	{
		public game()
		{


		}
		/// <summary>
		/// Desc:
		/// Default:
		/// Nullable:False
		/// </summary>           
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true, IsIgnore = true)]
		public int id { get; set; }

		/// <summary>
		/// Desc:比赛时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? gtime { get; set; }

		/// <summary>
		/// Desc:队伍A
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string teama { get; set; }

		/// <summary>
		/// Desc:队伍B
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string teamb { get; set; }

		/// <summary>
		/// Desc:队伍A得分
		/// Default:0
		/// Nullable:True
		/// </summary>           
		public byte? scorea { get; set; }

		/// <summary>
		/// Desc:队伍B得分
		/// Default:0
		/// Nullable:True
		/// </summary>           
		public byte? scoreb { get; set; }

		/// <summary>
		/// Desc:创建时间
		/// Default:CURRENT_TIMESTAMP
		/// Nullable:True
		/// </summary>           
		public DateTime? ctime { get; set; }

		/// <summary>
		/// Desc:更新时间
		/// Default:CURRENT_TIMESTAMP
		/// Nullable:True
		/// </summary>           
		public DateTime? utime { get; set; }

		/// <summary>
		/// Desc:比赛状态
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string status { get; set; }


		/// <summary>
		/// Desc:比赛说明
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string remark { get; set; }
	}
}
