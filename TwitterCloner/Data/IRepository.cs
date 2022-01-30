using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloner.Models;
using TwitterCloner.Models.DTO;

namespace TwitterCloner.Data
{
    public interface IRepository
    {
        Task<List<UserDTO>> GetAllUsersAsync();

        Task<UserDTO> GetUserByIdAsync(int id);

        Comment GetCommentById(int id);

        List<Comment> GetAllComments();
        void CreateComment(Comment comment);
        Task CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User user);
        Comment UpdateComment(int id, Comment comment);

    }
}
