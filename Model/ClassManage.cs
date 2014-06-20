using System;
namespace Song.Model
{
    /// <summary>
    /// ClassManage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ClassManage
    {
        public ClassManage()
        { }
        #region Model
        private int _id;
        private string _classname;
        private string _enname;
        private string _classurl;
        private string _keywords;
        private string _description;
        private string _classinfo;
        private string _pic;
        private int? _pageid;
        private int? _fid;
        private int? _orderid;
        private int? _funid;
        private string _urlparm;
        private bool _isself;
        private bool _isshow;
        private string _LinkUrl;
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
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string EnName
        {
            set { _enname = value; }
            get { return _enname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ClassUrl
        {
            set { _classurl = value; }
            get { return _classurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassInfo
        {
            set { _classinfo = value; }
            get { return _classinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PageId
        {
            set { _pageid = value; }
            get { return _pageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Fid
        {
            set { _fid = value; }
            get { return _fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? funid
        {
            set { _funid = value; }
            get { return _funid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string urlparm
        {
            set { _urlparm = value; }
            get { return _urlparm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isSelf
        {
            set { _isself = value; }
            get { return _isself; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isShow
        {
            set { _isshow = value; }
            get { return _isshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl
        {
            set { _LinkUrl = value; }
            get { return _LinkUrl; }
        }
        #endregion Model

    }
}

