using System;

namespace TutorialsXamarin.Business.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime DateOfBirth { get; set; }

        public string Image { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
