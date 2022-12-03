using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ITS.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        private static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {   
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            if (memInfo.Length == 0)
                return null;
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0)
                return null;
            return (T)attributes[0];
        }

        /// <summary>
        /// ارائه ی شرح یا متن فارسی لحاظ شده جهت یک مقدار عددی
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum src)
        {
            if (src == null) return null;
            var attribute = src.GetAttributeOfType<DescriptionAttribute>();
            var att = src.GetAttributeOfType<DefaultValueAttribute>();

            return attribute == null ? src.ToString() : attribute.Description;
        }

        /// <summary>
        /// ارائه ی مقدار انتخابی متناظر با یک مقدار عددی
        /// </summary>
        /// <typeparam name="TEnum">نوع مقدار انتخابی</typeparam>
        /// <param name="enumValue">مقدار</param>
        /// <returns></returns>
        public static TEnum GetEnumFromInt<TEnum>(Int32 enumValue)
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), enumValue);
        }

        /// <summary>
        /// Returns max value of enum as int.
        /// </summary>
        /// <typeparam name="T">Your enum</typeparam>
        /// <returns></returns>
        public static int GetMax<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }

        /// <summary>
        /// Returns min value of enum as int.
        /// </summary>
        /// <typeparam name="T">Your enum</typeparam>
        /// <returns></returns>
        public static int GetMin<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Min();
        }

        /// <summary>
        /// لیست ترکیبی از Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IList<TEnum> GetEnumValues<TEnum>(int value)
        {
            var result = new List<int>();
            var bitMask = Convert.ToString(value, 2);
            for (var i = 0; i < bitMask.Length; i++)
            {
                if (bitMask[i] == '1')
                    result.Add((int)Math.Pow(2, i));
            }

            return result.Cast<TEnum>().ToList();
        }

        /// <summary>
        /// دریافت تمامی آیتم های یک Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IList<TEnum> GetAllEnumValues<TEnum>()
        {
            var values = Enum.GetValues(typeof(TEnum));
            return values.Cast<TEnum>().ToList();
        }

    }
}