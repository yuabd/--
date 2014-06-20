using System;
namespace Song.Model
{
	/// <summary>
	/// userorders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class userorders
	{
		public userorders()
		{}
		#region Model
		private int _id;
		private int? _orderno=0;
		private string _ordercontent;
		private string _username;
		private DateTime? _ordertime;
		private string _consignee;
		private string _email;
		private string _address;
		private string _tel;
		private string _mobile;
		private string _zipcode;
		private string _best_time;
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
		public int? orderno
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ordercontent
		{
			set{ _ordercontent=value;}
			get{return _ordercontent;}
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
		public DateTime? ordertime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
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
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
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
		public string zipcode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string best_time
		{
			set{ _best_time=value;}
			get{return _best_time;}
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

