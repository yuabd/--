using System;
namespace Song.Model
{
	/// <summary>
	/// products:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class products
	{
		public products()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private string _title;
		private string _entitle;
		private string _prono;
		private string _brand;
		private int? _protype=0;
		private string _type2;
		private string _type3;
		private string _type4;
		private string _photo;
		private string _price;
		private string _saleprice;
		private bool _isshow;
		private bool _isnew;
		private bool _ishot;
		private bool _isrecom;
		private DateTime? _timeinfo;
		private string _features;
		private string _content;
		private string _encontent;
		private string _key1;
		private string _key2;
		private string _text1;
		private string _text2;
		private string _text3;
		private string _text4;
		private int? _orderid=0;
		private int? _hit=0;
		private string _moreno;
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
		public string prono
		{
			set{ _prono=value;}
			get{return _prono;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brand
		{
			set{ _brand=value;}
			get{return _brand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? protype
		{
			set{ _protype=value;}
			get{return _protype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type2
		{
			set{ _type2=value;}
			get{return _type2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type3
		{
			set{ _type3=value;}
			get{return _type3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type4
		{
			set{ _type4=value;}
			get{return _type4;}
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
		public string price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string saleprice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isshow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isnew
		{
			set{ _isnew=value;}
			get{return _isnew;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ishot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isrecom
		{
			set{ _isrecom=value;}
			get{return _isrecom;}
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
		public string features
		{
			set{ _features=value;}
			get{return _features;}
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
		/// <summary>
		/// 
		/// </summary>
		public string text4
		{
			set{ _text4=value;}
			get{return _text4;}
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
		#endregion Model

	}
}

