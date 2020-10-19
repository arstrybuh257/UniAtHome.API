using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UniAtHome.DAL.Entities
{
    // TODO: Modify the given class according to the SRS
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string Gender { get; set; }

        public List<Course> Courses { get; set; }
    }

    //public sealed class Student : User
    //{
    //    public string Group { get; set; }
    //}

    //public sealed class Teacher : User
    //{

    //}
}
