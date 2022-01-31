using System.Collections.Generic;

namespace TwitterCloner.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Comments = new List<CommentDTO>();
        }


        public int Id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Post { get; set; }
        public string Image { get; set; }
        public List<CommentDTO> Comments { get; set; }
        



    }
}
