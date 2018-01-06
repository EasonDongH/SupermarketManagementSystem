using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;
using System.ComponentModel;

namespace Models
{
    public enum Operate
    {
        [System.ComponentModel.Description("登录时出现错误")]
        ErrorHappenedWhenLogining,//未登录进去
        [System.ComponentModel.Description("记录销售信息时出现错误")]
        ErrorHappenedWhenLoginSaleInfo,
        [System.ComponentModel.Description("退出时出现错误")]
        ErrorHappenedWhenExiting,
        [System.ComponentModel.Description("登录日志分页查询时出现错误")]
        ErrorHappenedWhenLoginLogPageQuery,
        [System.ComponentModel.Description("数据库查询时出现错误")]
        ErrorHappenedWhenDataBaseQuery
    }

    //ErrorId, OccurTime, ServerName, LoginId, ErrorDesc, Operate
    public class ErrorLog
    {
        //public DateTime OccurTime { get; set; } = DateTime.Now;
        //private DateTime occurTime;
        public DateTime OccurTime//默认值取计算机本地时间
        {
            get
            {
                return DateTime.Now;
            }
        }

        //private string serverName;
        public string ServerName
        {
            get
            {
                return Dns.GetHostName();
            }
        }//默认值取计算机名称

        public int LoginId { get; set; }

        //private string operateInfo;
        public string OperateInfo//实际存入数据库的是这个属性值
        {
            get
            {
                return GetEnumDescription(Operate);
            }
        }

        public Operate Operate { get; set; }//用来获取enum值

        public string ErrorMessage { get; set; }
        public string GetEnumDescription(Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs == null || objs.Length == 0)    //当描述属性没有时，直接返回名称
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
    }
}
