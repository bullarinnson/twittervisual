using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloner.Models
{
    public class User
    {
        public User()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Post { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }

    }

    
}
