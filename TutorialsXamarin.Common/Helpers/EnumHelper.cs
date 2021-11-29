using System;
using System.Linq;
using System.Reflection;
using GuidAttribute = TutorialsXamarin.Common.Attributes.GuidAttribute;

namespace TutorialsXamarin.Common.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Find Enum Member by Guid that supported by GuidAttribute over member
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Find<T>(Guid guid) where T : IConvertible //enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");


            // gets the Type that contains all the info required to manipulate this type    
            Type enumType = typeof(T);

            // I will get all values and iterate through them    
            var enumValues = enumType.GetEnumValues();

            //Loop Enum Members
            foreach (T value in enumValues)
            {
                // with our Type object we can get the information about    
                // the members of it    
                MemberInfo memberInfo = enumType.GetMember(value.ToString()).First();

                // we can then attempt to retrieve the    
                // description attribute from the member info    
                var guidAttribute = memberInfo.GetCustomAttribute<GuidAttribute>();

                // if we find the attribute we can access its values    
                if (guidAttribute != null)
                {
                    if (guidAttribute.Guid == guid)
                    {
                        return value;
                    }
                }
            }

            throw new ArgumentException("Enum " + enumType + " has no GuidAttribute defined!");
        }

        /// <summary>
        /// Find Enum Member by Guid that supported by GuidAttribute over member
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Find<T>(Guid? guid) where T : IConvertible //enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");


            // gets the Type that contains all the info required to manipulate this type    
            Type enumType = typeof(T);

            // I will get all values and iterate through them    
            var enumValues = enumType.GetEnumValues();

            //Loop Enum Members
            foreach (T value in enumValues)
            {
                // with our Type object we can get the information about    
                // the members of it    
                MemberInfo memberInfo = enumType.GetMember(value.ToString()).First();

                // we can then attempt to retrieve the    
                // description attribute from the member info    
                var guidAttribute = memberInfo.GetCustomAttribute<GuidAttribute>();

                // if we find the attribute we can access its values    
                if (guidAttribute != null)
                {
                    if (guidAttribute.Guid == guid)
                    {
                        return value;
                    }
                }
            }

            throw new ArgumentException("Enum " + enumType + " has no GuidAttribute defined!");
        }

        /// <summary>
        /// Find Enum Member by Guid that supported by GuidAttribute over member
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Find<T>(string guid) where T : IConvertible //enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");


            // gets the Type that contains all the info required to manipulate this type    
            Type enumType = typeof(T);

            // I will get all values and iterate through them    
            var enumValues = enumType.GetEnumValues();

            //Loop Enum Members
            foreach (T value in enumValues)
            {
                // with our Type object we can get the information about    
                // the members of it    
                MemberInfo memberInfo = enumType.GetMember(value.ToString()).First();

                // we can then attempt to retrieve the    
                // description attribute from the member info    
                var guidAttribute = memberInfo.GetCustomAttribute<GuidAttribute>();

                // if we find the attribute we can access its values    
                if (guidAttribute != null)
                {
                    if (guidAttribute.Guid == new Guid(guid))
                    {
                        return value;
                    }
                }
            }

            throw new ArgumentException("Enum " + enumType + " has no GuidAttribute defined!");
        }
    }
}
