﻿using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Student
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
    }
}
