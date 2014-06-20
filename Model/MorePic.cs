using System;
namespace Song.Model
{
	/// <summary>
	/// MorePic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MorePic
	{
		public MorePic()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private string _photono;
		private string _title;
		private string _detail;
		private string _pic;
		private DateTime? _timeinfo;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string photono
		{
			set{ _photono=value;}
			get{return _photono;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? timeinfo
		{
			set{ _timeinfo=value;}
			get{return _timeinfo;}
		}
		#endregion Model

	}
}

