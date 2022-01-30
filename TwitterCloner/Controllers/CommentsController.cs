using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloner.Models;
using TwitterCloner.Data;

namespace TwitterCloner.Controllers
{
    [Route("api/comments")]
    [Controller]
    public class CommentsController : ControllerBase 
    {
        private readonly IRepository _repository;

        public CommentsController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public List<Comment> GetAllComments()
        {
            return _repository.GetAllComments();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            try
            {
              return Ok(_repository.GetCommentById(id));
            }
               /* try
            {

                Comment stud = _repository.GetCommentById(id);
                if (stud == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_repository.GetUserById(id));
                }*/



            
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    _repository.CreateComment(comment);
                    //return Created();
                    return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            try
            {

                Comment updatedComment = _repository.UpdateComment(id, comment);
                if (updatedComment == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetCommentById), new { id = updatedComment.Id }, updatedComment);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }
    }
}
