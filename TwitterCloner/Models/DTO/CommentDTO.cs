using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloner.Models
{
    public class CommentDTO
    {

        public CommentDTO()
        {
            Users = new List<UserDTO>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Image { get; set; }
        public int UserID { get; set; }
      
        public List<UserDTO> Users { get; set; }


    }
}
