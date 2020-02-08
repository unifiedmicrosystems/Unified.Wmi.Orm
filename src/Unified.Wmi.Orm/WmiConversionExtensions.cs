using System;
using System.Management;

namespace Unified.Wmi.Orm
{
    public static class WmiConversionExtensions
    {
        public static object ConvertWmiValue(this object value, Type toType, bool allowNulls = true)
        {
            if (allowNulls == false && value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value is null)
            {
                return Activator.CreateInstance(toType);
            }

            // first check if any conversion is needed
            if (toType == value.GetType())
                return value;

            switch (Type.GetTypeCode(toType))
            {
                case TypeCode.Boolean:
                    return Convert.ToBoolean(value);
                case TypeCode.Int32:
                    return Convert.ToInt32(value);
                case TypeCode.Int64:
                    return Convert.ToInt64(value);
                case TypeCode.DateTime:
                    return ManagementDateTimeConverter.ToDateTime(value.ToString());
                case TypeCode.Double:
                    return Convert.ToDouble(value);
                case TypeCode.Single:
                    return Convert.ToSingle(value);
                case TypeCode.Byte:
                    return Convert.ToByte(value);
                case TypeCode.Char:
                    return Convert.ToChar(value);
                case TypeCode.Decimal:
                    return Convert.ToDecimal(value);
                case TypeCode.SByte:
                    return Convert.ToSByte(value);
                case TypeCode.UInt16:
                    return Convert.ToUInt16(value);
                case TypeCode.UInt32:
                    return Convert.ToUInt32(value);
                case TypeCode.UInt64:
                    return Convert.ToUInt64(value);
                case TypeCode.String:
                    return Convert.ToString(value);
                default:
                    throw new ArgumentException(
                                    $"No conversion exists for {value.GetType().Name} to {toType}",
                                    nameof(toType));
            }
        }

    }
}
