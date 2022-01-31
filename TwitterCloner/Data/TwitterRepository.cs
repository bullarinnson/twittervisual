using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloner.Models;
using TwitterCloner.Models.DTO;

namespace TwitterCloner.Data
{
    public class TwitterRepository : IRepository
    {
        private readonly TwitterDbContext _dbContext;

        public TwitterRepository()
        {
            _dbContext = new TwitterDbContext();
        }

        public void CreateComment(Comment comment)
        {
            using (var db = _dbContext)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
        }

        public async Task CreateUserAsync(User user)
        {
            using (var db = _dbContext)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        public List<Comment> GetAllComments()
        {
            using (var db = _dbContext)
            {
                return db.Comments.ToList();
            }
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            List<User> users;
            using (var db = _dbContext)
            {
                users = await db.Users.Include(c => c.Comments).ToListAsync();
            }
            List<UserDTO> listToReturn = new List<UserDTO>();


            foreach (User use in users)
            {
                UserDTO useToAdd = new UserDTO();

                useToAdd.Id = use.Id;
                useToAdd.Name = use.Name;
                useToAdd.UserName = use.UserName;
                useToAdd.Post = use.Post;
                useToAdd.Image = use.Image;
                useToAdd.ProfilePicture = use.ProfilePicture;

                listToReturn.Add(useToAdd);

            }

            return listToReturn;
        }

        public Comment GetCommentById(int id)
        {
            using (var db = _dbContext)
            {
                return db.Comments.FirstOrDefault(x => x.Id == id);
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            User s;

            using (var db = _dbContext)
            
            {

                s = await db.Users.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
               
            }

            UserDTO useToReturn = new UserDTO();
            List<CommentDTO> CommentsDTO = new List<CommentDTO>();
            foreach (Comment c in s.Comments)
            {
                CommentDTO dto = new CommentDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProfilePicture = c.ProfilePicture,
                    UserName = c.UserName,
                    Content = c.Content
                };
                dto.ProfilePicture = c.ProfilePicture;
                dto.UserId = c.UserId;

                CommentsDTO.Add(dto);
                

            }

            useToReturn.Id = s.Id;
            useToReturn.Name = s.Name;
            useToReturn.UserName = s.UserName;
            useToReturn.ProfilePicture = s.ProfilePicture;
            useToReturn.Post = s.Post;
            useToReturn.Image = s.Image;

            return useToReturn;
        }
        public Comment UpdateComment(int id, Comment comment)
        {
            Comment commentToUpdate;

            using (var db = _dbContext)
            {
                commentToUpdate = db.Comments.FirstOrDefault(x => x.Id == id);
                if (commentToUpdate == null)
                {
                    return null;
                }

                commentToUpdate.Name = comment.Name;


                db.SaveChanges();

                return commentToUpdate;
            }
        }
        public async Task<User> UpdateUserAsync(int id, User user)
        {
            User userToUpdate;

            using (var db = _dbContext)
            {
                userToUpdate = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (userToUpdate == null)
                {
                    return null;
                }

                userToUpdate.Name = user.Name;
                userToUpdate.UserName = user.UserName;
                userToUpdate.Image = user.Image;
                userToUpdate.Post = user.Post;



                await db.SaveChangesAsync();

                return userToUpdate;
            }
        }
    }
}
