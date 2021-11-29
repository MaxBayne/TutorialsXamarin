using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace TutorialsXamarin.Common.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert Object To Another by Reflection , Not Recommended because its slow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Cast<T>(this Object source)
        {
            Type sourceType = source.GetType();
            Type targetType = typeof(T);
            var target = Activator.CreateInstance(targetType, false);
            var sourceMembers = sourceType.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();
            var targetMembers = targetType.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();
            var members = targetMembers
                .Where(x => sourceMembers
                    .Select(y => y.Name)
                    .Contains(x.Name));
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = source.GetType().GetProperty(memberInfo.Name)?.GetValue(source, null);
                try
                {
                    propertyInfo?.SetValue(target, value, null);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return (T)target;
        }

        /// <summary>
        /// Convert Object To Another by Json Serialization its Faster than Reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Convert<T>(this Object source)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }
}