using System;
namespace Song.Model
{
    /// <summary>
    /// Jobs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Jobs
    {
        public Jobs()
        { }
        #region Model
        private int _id;
        private int? _pid = 0;
        private string _title;
        private string _num;
        private string _sex;
        private string _workadd;
        private DateTime? _timeinfo;
        private string _jobunit;
        private string _money;
        private string _content;
        private bool _isshow;
        private string _companyname;
        private string _jobdescription;
        private string _jobduration;
        private string _contact;
        private string _contacttel;
        private string _education;
        private string _workexperience;
        private string _SPic;
        private string _BPic;
        private bool _isRecommend;
        private string _ContactUs;
        private string _CompanyProfile;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 招聘人数
        /// </summary>
        public string Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 工作地点
        /// </summary>
        public string WorkAdd
        {
            set { _workadd = value; }
            get { return _workadd; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? TimeInfo
        {
            set { _timeinfo = value; }
            get { return _timeinfo; }
        }
        /// <summary>
        /// 招聘部门
        /// </summary>
        public string JobUnit
        {
            set { _jobunit = value; }
            get { return _jobunit; }
        }
        /// <summary>
        /// 参考月薪
        /// </summary>
        public string Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 详情
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool isShow
        {
            set { _isshow = value; }
            get { return _isshow; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 职位描述
        /// </summary>
        public string JobDescription
        {
            set { _jobdescription = value; }
            get { return _jobdescription; }
        }
        /// <summary>
        /// 展品期限
        /// </summary>
        public string JobDuration
        {
            set { _jobduration = value; }
            get { return _jobduration; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            set { _contact = value; }
            get { return _contact; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel
        {
            set { _contacttel = value; }
            get { return _contacttel; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 工作年限
        /// </summary>
        public string WorkExperience
        {
            set { _workexperience = value; }
            get { return _workexperience; }
        }
        /// <summary>
        /// 小图
        /// </summary>
        public string SPic
        {
            set { _SPic = value; }
            get { return _SPic; }
        }
        /// <summary>
        /// 大图
        /// </summary>
        public string BPic
        {
            set { _BPic = value; }
            get { return _BPic; }
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool isRecommend
        {
            set { _isRecommend = value; }
            get { return _isRecommend; }
        }
        /// <summary>
        /// 联系我们
        /// </summary>
        public string ContactUs
        {
            set { _ContactUs = value; }
            get { return _ContactUs; }
        }
        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyProfile
        {
            set { _CompanyProfile = value; }
            get { return _CompanyProfile; }
        }
        #endregion Model

    }
}

