using System;

namespace TutorialsXamarin.Common.Models
{
    public class Customer
    {

        public Guid Code { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Image { get; set; }
    }
}
