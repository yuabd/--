using System;
namespace Song.Model
{
	/// <summary>
	/// FeedBack:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FeedBack
	{
		public FeedBack()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private string _type;
		private string _companyname;
		private string _username;
		private string _jobs;
		private string _phone;
		private string _mobile;
		private string _email;
		private string _address;
		private string _content;
		private DateTime? _timeinfo;
		private int? _feedstate=0;
		private string _feedbacktype;
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
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 希望体验的产品
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 职位
		/// </summary>
		public string jobs
		{
			set{ _jobs=value;}
			get{return _jobs;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// E-mail
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 提交申请表的时间
		/// </summary>
		public DateTime? timeinfo
		{
			set{ _timeinfo=value;}
			get{return _timeinfo;}
		}
		/// <summary>
		/// 申请表的处理状态
		/// </summary>
		public int? FeedState
		{
			set{ _feedstate=value;}
			get{return _feedstate;}
		}
		/// <summary>
		/// 表单类型
		/// </summary>
		public string FeedBackType
		{
			set{ _feedbacktype=value;}
			get{return _feedbacktype;}
		}
        /// <summary>
        /// 表单类型
        /// </summary>
        public string weblanguage
        {
            set { _weblanguage = value; }
            get { return _weblanguage; }
        }
		#endregion Model

	}
}

