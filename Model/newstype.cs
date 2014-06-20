using System;
namespace Song.Model
{
	/// <summary>
	/// newstype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class newstype
	{
		public newstype()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private int? _fid=0;
		private string _title;
		private string _entitle;
		private string _content;
		private string _encontent;
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
		public int? fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entitle
		{
			set{ _entitle=value;}
			get{return _entitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string encontent
		{
			set{ _encontent=value;}
			get{return _encontent;}
		}
		#endregion Model

	}
}

