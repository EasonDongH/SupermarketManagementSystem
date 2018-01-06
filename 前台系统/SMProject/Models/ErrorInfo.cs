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
    public enum OperateInfo
    {
        [System.ComponentModel.Description("登录时出现错误")]
        ErrorHappenedWhenLogining,//未登录进去
        [System.ComponentModel.Description("记录销售信息时出现错误")]
        ErrorHappenedWhenLoginSaleInfo
    }
    public class Error
    {
        public int ErrorId { get; set; }
        public DateTime OccurTime { get; set; }
        private string serverName= Dns.GetHostName();
        public string ServerName
        {
            get
            {
                return serverName;
            }           
        }

        private int loginId = 0;
        public int LoginId
        {
            get
            {
                return loginId;
            }
            set
            {
                if (value == 0)
                    loginId = -1;
                else
                    loginId = value;
            }
        }
        private string errorDesc = string.Empty;
        public string ErrorDesc
        {
            get
            {
                return errorDesc;
            }
            set
            {
                errorDesc = value;
            }
        }
        public string Opearte { get; set; }

        //public string GetEnumDescription(Enum enumValue)
        //{
        //    string value = enumValue.ToString();
        //    FieldInfo field = enumValue.GetType().GetField(value);
        //    object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
        //    if (objs == null || objs.Length == 0)    //当描述属性没有时，直接返回名称
        //        return value;
        //    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
        //    return descriptionAttribute.Description;
        //}
    }

   
}
