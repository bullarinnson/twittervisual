using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloner.Models
{
    public class CommentDTO
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
