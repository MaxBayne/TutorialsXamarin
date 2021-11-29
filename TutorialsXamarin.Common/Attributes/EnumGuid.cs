using System;

namespace TutorialsXamarin.Common.Attributes
{
    public class GuidAttribute : Attribute
    {
        /// <summary>
        /// Guid Attribute For Enum Member
        /// </summary>
        public Guid Guid;

        public GuidAttribute(string guid)
        {
            Guid = new Guid(guid);
        }
    }
}
