using System;
namespace Song.Model
{
    /// <summary>
    /// link:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class link
    {
        public link()
        { }
        #region Model
        private int _id;
        private int _Pid;
        private string _typename;
        private string _url;
        private string _PicUrl;
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
        public int Pid
        {
            set { _Pid = value; }
            get { return _Pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typename
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicUrl
        {
            set { _PicUrl = value; }
            get { return _PicUrl; }
        }
        #endregion Model

    }
}

