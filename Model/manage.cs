using System;
namespace Song.Model
{
    /// <summary>
    /// manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class manage
    {
        public manage()
        { }
        #region Model
        private int _id;
        private string _adminname;
        private string _adminpassword;
        private string _adminlv;
        private DateTime? _regtime;
        private string _weblanguage;
        private string _strname;
        private string _strloginip;
        private DateTime? _dtmlogintime;
        private int? _intstatus = 0;
        private int? _intloginnum = 0;
        private int? _intType;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string adminname
        {
            set { _adminname = value; }
            get { return _adminname; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string adminpassword
        {
            set { _adminpassword = value; }
            get { return _adminpassword; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        public string adminlv
        {
            set { _adminlv = value; }
            get { return _adminlv; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? regtime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 语言
        /// </summary>
        public string weblanguage
        {
            set { _weblanguage = value; }
            get { return _weblanguage; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string strName
        {
            set { _strname = value; }
            get { return _strname; }
        }
        /// <summary>
        /// 最后登录IP地址
        /// </summary>
        public string strLoginIP
        {
            set { _strloginip = value; }
            get { return _strloginip; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? dtmLoginTime
        {
            set { _dtmlogintime = value; }
            get { return _dtmlogintime; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? intStatus
        {
            set { _intstatus = value; }
            get { return _intstatus; }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? intLoginNum
        {
            set { _intloginnum = value; }
            get { return _intloginnum; }
        }
        /// <summary>
        /// 管理员类型
        /// </summary>
        public int? intType
        {
            set { _intType = value; }
            get { return _intType; }
        }
        #endregion Model

    }
}

