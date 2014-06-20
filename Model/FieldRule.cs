using System;
namespace Song.Model
{
	/// <summary>
	/// FieldRule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FieldRule
	{
		public FieldRule()
		{}
		#region Model
		private int _id;
		private string _rulename;
		private string _rulepower;
		private string _xmlname;
		private string _ruletype;
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
		public string RuleName
		{
			set{ _rulename=value;}
			get{return _rulename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RulePower
		{
			set{ _rulepower=value;}
			get{return _rulepower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xmlname
		{
			set{ _xmlname=value;}
			get{return _xmlname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RuleType
		{
			set{ _ruletype=value;}
			get{return _ruletype;}
		}
		#endregion Model

	}
}

