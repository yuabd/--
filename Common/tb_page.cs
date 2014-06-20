using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using DataPageTools;
using Maticsoft.DBUtility;

namespace Maticsoft.Common
{
    /// <summary>
    ///tb_page 的摘要说明
    /// </summary>
    public class tb_page
    {
        public tb_page()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static string connectionString = PubConstant.ConnectionString;
        #region 分页绑定数据
        /// <summary>
        /// 分页绑定数据
        /// </summary>
        /// <param name="repeater">显示的空件名</param>
        /// <param name="InPageIndex">当前页数</param>
        /// <param name="InPageSize">一页显示条数</param>
        /// <param name="tatlename">表名</param>
        /// <param name="sqlwhere">查询条件,where 后面的</param>
        /// <param name="sqlwhere1">分页查询语句</param>
        /// <param name="orderby">排序</param>
        /// <param name="datapag">分页控件名,例如：DataPage8</param>
        public void Bindpage(Repeater repeater, int InPageIndex, int InPageSize, String tatlename, String sqlwhere, String sqlwhere1, String orderby, DataPage datapag)
        {
            string sql1 = "";
            string sql2 = "";
            string str = "order by sort desc ,id desc";
            //查询条件
            sql1 = sqlwhere + " and";
            sql2 = "where " + sqlwhere;
            //排序
            if (orderby != "")
                str = orderby;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                DataSet ds1 = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();
                try
                {
                    OleDbCommand comm = new OleDbCommand();
                    comm.Connection = conn;
                    conn.Open();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = InPageIndex > 1 ? String.Format("select top {0} * from [" + tatlename + "] where  " + sql1 + "  ID not in (select top {1} [ID] from [" + tatlename + "] " + sql2 + " " + str + ") " + str + " ", InPageSize, InPageSize * (InPageIndex - 1)) : String.Format("select top {0} * from [" + tatlename + "] " + sql2 + " " + str + "", InPageSize);
                    da.SelectCommand = comm;
                    da.Fill(ds1);
                    repeater.DataSource = ds1.Tables[0];
                    repeater.DataBind();
                    OleDbCommand comm1 = new OleDbCommand("select count(ID) from [" + tatlename + "] " + sql2 + "", conn);
                    int InCount = (int)comm1.ExecuteScalar();
                    datapag.TotalRecordCount = InCount;//获取记录总数
                    datapag.ShowPageNumberCount = 7;//每页显示的页码数
                    datapag.ShowRecordCount = InPageSize;//分页后每页显示的条数
                    datapag.QueryString = sqlwhere1 + "&page";
                    datapag.QueryStringKeyWord = "page";



                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
        public void Bangpage(Repeater repeater, int InPageIndex, int InPageSize, String tatlename, String sqlwhere, String orderby)
        {
            string sql1 = "";
            string sql2 = "";
            string str = "order by sort desc ,id desc";
            //查询条件
            sql1 = sqlwhere + " and";
            sql2 = "where " + sqlwhere;
            //排序
            if (orderby != "")
                str = orderby;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                DataSet ds1 = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();
                try
                {
                    OleDbCommand comm = new OleDbCommand();
                    comm.Connection = conn;
                    conn.Open();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = InPageIndex > 1 ? String.Format("select top {0} * from [" + tatlename + "] where  " + sql1 + "  ID not in (select top {1} [ID] from [" + tatlename + "] " + sql2 + " " + str + ") " + str + " ", InPageSize, InPageSize * (InPageIndex - 1)) : String.Format("select top {0} * from [" + tatlename + "] " + sql2 + " " + str + "", InPageSize);
                    da.SelectCommand = comm;
                    da.Fill(ds1);
                    repeater.DataSource = ds1.Tables[0];
                    repeater.DataBind();
                    //int InCount = (int)comm1.ExecuteScalar();//获取记录总数

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
        #endregion
        #region 计算总数
        /// <summary>
        /// 计算总数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>

        //public static int conunt(String sql)
        //{
        //    //int tmp = 0;
        //    //webcommand str = new webcommand();
        //    //DataSet ds = str.executedataset(sql);
        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //    tmp = ds.Tables[0].Rows.Count;
        //    //return tmp;
        //}

        #endregion
        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static String sub(String tname, int i)
        {
            String tmp = "";

            if (Maticsoft.Common.FormatHtml.nohtm(tname).Length > i)
                tmp = Maticsoft.Common.FormatHtml.nohtm(tname).Substring(0, i);
            else
                tmp = Maticsoft.Common.FormatHtml.nohtm(tname);
            return tmp;
        }

        #endregion
        #region 格式化时间
        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>

        public static String MartTime(String time)
        {
            String tmp = "";
            if (time != "")
            {
                tmp = Convert.ToString(Convert.ToDateTime(time).ToString("yyyy-MM-dd"));
            }
            return tmp;
        }

        #endregion
    }
}