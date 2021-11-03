using System;

namespace TutorialsXamarin.DataAccess.DataModels
{
    public class Customer : Common.Models.Customer
    {
        public new int Id { get; set; }
        public new string FirstName { get; set; }
        public new string LastName { get; set; }
        public new DateTime DateOfBirth { get; set; }
    }
}
