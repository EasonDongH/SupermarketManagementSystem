using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace SMManager
{
    /// <summary>
    /// 通用验证类
    /// </summary>
    class DataValidate
    {
        /// <summary>
        /// 匹配整数（必须是正整数）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPositiveInteger(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配正整数和零
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPositiveIntegerAndZero(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*|0$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配整数（必须是负整数）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsNegativeInteger(string txt)
        {
            Regex objReg = new Regex(@"^-[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配整数(正负均可)
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInteger(string txt)
        {
            Regex objReg = new Regex(@"^-?[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配小数（必须是正数）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPositiveDecimal(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配小数（必须是负数）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsNegativeDecimal(string txt)
        {
            Regex objReg = new Regex(@"^-([1-9]\d*\.\d*|0\.\d*[1-9]\d*)$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配小数(正负均可)
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsDecimal(string txt)
        {
            Regex objReg = new Regex(@"^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配Email
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsEmail(string txt)
        {
            Regex objReg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配身份证
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsIdentityCard(string txt)
        {
            Regex objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 匹配邮政编码
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPostalCode(string txt)
        {
            if (txt.Length != 6) return false;
            Regex objReg = new Regex(@"[1-9]\d{5}(?!\d)");
            return objReg.IsMatch(txt);
        }
    }
}
