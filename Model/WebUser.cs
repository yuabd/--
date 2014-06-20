using System;
namespace Song.Model
{
	/// <summary>
	/// WebUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WebUser
	{
		public WebUser()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
		private string _companyname;
		private string _email;
		private string _mobile;
		private string _qq;
		private string _address;
		private int? _userlv=0;
		private bool _userstate;
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
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyname
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userlv
		{
			set{ _userlv=value;}
			get{return _userlv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool userstate
		{
			set{ _userstate=value;}
			get{return _userstate;}
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

