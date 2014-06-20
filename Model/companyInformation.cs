using System;
namespace Song.Model
{
	/// <summary>
	/// companyInformation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class companyInformation
	{
		public companyInformation()
		{}
		#region Model
		private int _id;
		private int? _pid=0;
		private string _menuname;
		private string _information;
		private string _infocn;
		private DateTime? _updatetime;
		private string _weblanguage;
        private string _pic;
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
		public string menuname
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string information
		{
			set{ _information=value;}
			get{return _information;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string infocn
		{
			set{ _infocn=value;}
			get{return _infocn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weblanguage
		{
			set{ _weblanguage=value;}
			get{return _weblanguage;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
		#endregion Model

	}
}

