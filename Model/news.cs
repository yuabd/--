using System;
namespace Song.Model
{
	/// <summary>
	/// news:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class news
	{
		public news()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private string _title;
		private string _entitle;
		private bool _isshow;
		private int? _newstype=0;
		private string _photo;
		private string _content;
		private string _encontent;
		private DateTime? _timeinfo;
		private int? _orderid=0;
		private int? _hit=0;
		private string _moreno;
		private string _links;
		private string _key1;
		private string _key2;
		private string _text1;
		private string _text2;
		private string _text3;
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
		public bool isShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? newstype
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string photo
		{
			set{ _photo=value;}
			get{return _photo;}
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
		/// <summary>
		/// 
		/// </summary>
		public DateTime? timeinfo
		{
			set{ _timeinfo=value;}
			get{return _timeinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hit
		{
			set{ _hit=value;}
			get{return _hit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string moreno
		{
			set{ _moreno=value;}
			get{return _moreno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string links
		{
			set{ _links=value;}
			get{return _links;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key1
		{
			set{ _key1=value;}
			get{return _key1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string key2
		{
			set{ _key2=value;}
			get{return _key2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text1
		{
			set{ _text1=value;}
			get{return _text1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text2
		{
			set{ _text2=value;}
			get{return _text2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text3
		{
			set{ _text3=value;}
			get{return _text3;}
		}
		#endregion Model

	}
}

