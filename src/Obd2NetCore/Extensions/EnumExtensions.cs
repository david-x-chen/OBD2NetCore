﻿using System;
using System.ComponentModel;
using System.Linq;

namespace Obd2NetCore.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attribute = (DescriptionAttribute) fi.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            return attribute != null ? attribute.Description : value.ToString();
        }

        public static string GetOrder(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attribute = (DescriptionAttribute)fi.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}