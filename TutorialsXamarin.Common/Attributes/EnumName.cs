using System;

namespace TutorialsXamarin.Common.Attributes
{
    public class NameAttribute : Attribute
    {
        /// <summary>
        /// Name Attribute For Enum Member
        /// </summary>
        public string Name;

        public NameAttribute(string name)
        {
            Name = name;
        }
    }
}
