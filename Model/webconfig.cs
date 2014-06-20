using System;
namespace Song.Model
{
	/// <summary>
	/// webconfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class webconfig
	{
		public webconfig()
		{}
		#region Model
		private int _id;
		private string _webname;
		private string _webkey1;
		private string _webkey2;
		private string _webkey3;
		private string _webemail;
		private string _webadd;
		private string _webcode;
		private string _webtel;
		private string _webfax;
		private string _webcopyright;
		private string _webicp;
		private string _qq1;
		private string _qq2;
		private string _weblanguage;
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
		public string webname
		{
			set{ _webname=value;}
			get{return _webname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webkey1
		{
			set{ _webkey1=value;}
			get{return _webkey1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webkey2
		{
			set{ _webkey2=value;}
			get{return _webkey2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webkey3
		{
			set{ _webkey3=value;}
			get{return _webkey3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webemail
		{
			set{ _webemail=value;}
			get{return _webemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webadd
		{
			set{ _webadd=value;}
			get{return _webadd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webcode
		{
			set{ _webcode=value;}
			get{return _webcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webtel
		{
			set{ _webtel=value;}
			get{return _webtel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webfax
		{
			set{ _webfax=value;}
			get{return _webfax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webcopyright
		{
			set{ _webcopyright=value;}
			get{return _webcopyright;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webicp
		{
			set{ _webicp=value;}
			get{return _webicp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq1
		{
			set{ _qq1=value;}
			get{return _qq1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq2
		{
			set{ _qq2=value;}
			get{return _qq2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weblanguage
		{
			set{ _weblanguage=value;}
			get{return _weblanguage;}
		}
		#endregion Model

	}
}

