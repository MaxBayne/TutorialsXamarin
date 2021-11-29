﻿namespace TutorialsXamarin.Business.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public string Category { get; set; }

    }
}
