using Fasterflect;
using System;
using System.Management;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Unified.Wmi.Orm
{
    public static class WmiInfoMapper
    {
        private static PropertyData[] ToPropertyDataArray(this ManagementObject managementObject)
        {
            var array = new PropertyData[managementObject.Properties.Count];
            managementObject.Properties.CopyTo(array, 0);
            return array;
        }

        public static IEnumerable<T> GetWmiInfo<T>() where T : class
        {
            var list = new List<T>();

            var query = BuildWmiQueryString<T>();

            var managementObjectList
                    = new ManagementObjectSearcher(query).Get().OfType<ManagementObject>();

            foreach (var managementObject in managementObjectList)
            {
                list.Add(managementObject.MapToDto<T>());
            }

            return list;
        }

        private static string BuildWmiQueryString<T>() where T : class
        { 
            var type = typeof(T);
            var attribute = type.GetCustomAttributes<WmiNamespaceAttribute>(true);

            if (attribute.Count() == 0)
                throw new ArgumentException("Supplied type does not contain attribute of " + typeof(WmiNamespaceAttribute).Name);

            var query = new WmiQueryBuilder(attribute.First().Name);

            foreach (var dtoProperty in type.Properties())
            {
                query.AddParameter(dtoProperty.Name);
            }

            return query.ToString();
        }

        private static T MapToDto<T>(this ManagementObject managementObject) where T : class
        {
            var type = typeof(T);
            var dto = type.CreateInstance() as T;

            var wmiProperties = managementObject.ToPropertyDataArray();

            foreach (var dtoProperty in type.Properties())
            {
                var found = wmiProperties.Where(x => x.Name == dtoProperty.Name).FirstOrDefault();

                // check if the property is an array (both sides)
                if (found.IsArray != dtoProperty.PropertyType.IsArray)
                {
                    throw new InvalidCastException("Source and destination must be same");
                }
                else if (found.IsArray && dtoProperty.PropertyType.IsArray)
                {
                    var dtoArrayElementType = dtoProperty.PropertyType.GetElementType();
                    var foundArray = (Array)found.Value;

                    dto.SetPropertyValue(
                            dtoProperty.Name,
                            CloneAndConvertArray(foundArray, dtoArrayElementType));
                }
                else
                {
                    dto.SetPropertyValue(
                            dtoProperty.Name,
                            found.Value.ConvertWmiValue(dtoProperty.PropertyType));
                }
            }

            return dto;
        }

        private static Array CloneAndConvertArray(Array source, Type destinationType)
        {
            var dtoArray = Array.CreateInstance(destinationType, source.Length);

            for (var i = 0; i < dtoArray.Length; i++)
            {
                var converted = source.GetElement(i).ConvertWmiValue(destinationType);
                dtoArray.SetElement(i, converted);
            }

            return dtoArray;
        }
    }
}
