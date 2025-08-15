﻿using EXAMINATION.Models.Entities;

namespace EXAMINATION.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Fee { get; set; }

       // public ICollection<Semester> Semesters { get; set; } = new List<Semester>();
        public ICollection<StudentProfile> Students { get; set; } = new List<StudentProfile>();

    }


}
