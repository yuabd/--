using System;
namespace Song.Model
{
	/// <summary>
	/// producttype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class producttype
	{
		public producttype()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private string _title;
		private string _entitle;
		private int? _fid=0;
		private string _content;
		private string _encontent;
		private string _photo;
		private int? _orderid=0;
		private string _text1;
		private string _text2;
		private string _text3;
		private string _text4;
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
		/// 父ID
		/// </summary>
		public int? fid
		{
			set{ _fid=value;}
			get{return _fid;}
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
		public string photo
		{
			set{ _photo=value;}
			get{return _photo;}
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
		/// <summary>
		/// 
		/// </summary>
		public string text4
		{
			set{ _text4=value;}
			get{return _text4;}
		}
		#endregion Model

	}
}

