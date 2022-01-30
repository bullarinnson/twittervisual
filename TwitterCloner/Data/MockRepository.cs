using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloner.Models;
using TwitterCloner.Models.DTO;

namespace TwitterCloner.Data
{
    public class MockRepository : IRepository
    {
         List<UserDTO> Users = new List<UserDTO>()
            {
                new UserDTO() { Id = 1, Name = "Arnar Imsland-mock", UserName = "@arnarimsland", Post = "well hello there" },
                new UserDTO() { Id = 2, Name = "Alexandra Dís Unudóttir-mock", UserName = "@alla", Post = "hvar setti ég aftur heyrnatólin mín, veit aldrei" },
                new UserDTO() { Id = 3, Name = "Aron Valur Jóhannsson-mock", UserName = "@valurinn", Post = "Ég er bestur í öllu" },
                new UserDTO() { Id = 4, Name = "Einar Þór Gunnlaugsson-mock", UserName = "@pungsi", Post = "hvar er djammið eiginlega" },
            };
        List<Comment> Comments = new List<Comment>()
            {
                new Comment() {Id = 1,Name="Mock-Forritun-mock",},
                new Comment() {Id = 2, Name="Mock-Hönnun-mock"},
                new Comment() {Id = 3, Name="Mock-Gagnagrunnun-mock "}
            };
       public MockRepository()
        {

        }
        public Task<List<UserDTO>> GetAllUsersAsync()
        {
            return null;
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }
        public List<Comment> GetAllComments()
        {
            return Comments;
        }
        public Comment GetCommentById(int id)
        {
            return Comments.FirstOrDefault(x => x.Id == id);
        }

        public void CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(int id, User user)
        {
            throw new NotImplementedException();
        }

        public Comment UpdateComment(int id, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
