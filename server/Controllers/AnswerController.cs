using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stackoverflowclone.Models;

namespace stackoverflowclone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {

        private StackOverflowContext db { get; set; }

        public AnswerController(StackOverflowContext _db)
        { 
            this.db = _db;
        }


        [HttpGet]
        public IOrderedQueryable<AnswerModel> Get()
        {
            var answer = this.db.AnswersTable.OrderBy(a => a.Answer)
            .ThenBy(t => t.CreatedDate);
            return answer;

        }//END

        [HttpPost]
        public AnswerModel Post([FromBody] AnswerModel answer)
        {
            this.db.AnswersTable.Add(answer);
            this.db.SaveChanges();
            return answer;


        }//END 

        // [HttpPatch("{id}")]
        // public AnswerModel Patch(int id)
        // {
        //     //Find the location inside the database with the Id
        //     var answer = this.db.AnswersTable.FirstOrDefault(f => f.Id == id);
            
        //     //Update Time to createDate Now
        //     answer.CreatedDate = DateTime.Now;
        //     //Save it to Database
        //     this.db.SaveChanges();
        //     //Return new information   
        //     return answer;
        // }//END

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var answer = this.db.AnswersTable.FirstOrDefault(f => f.Id == id);
            this.db.AnswersTable.Remove(answer);
            this.db.SaveChanges();
            return Ok(new { success = true });
        }

         // Return all Answers in an Array
        [HttpGet]
        public IEnumerable<AnswerModel> GetAll()
        {
            var answer = this.db.AnswersTable;
            return answer;

        }//END HttpGet



        //Returns data in an Array based on QuestionID
        [HttpGet("{id}")]
        public IEnumerable<AnswerModel> Get(int id)
        {
            var answer = this.db.AnswersTable.Where(ans => ans.QuestionModelId == id).OrderBy(o => o.CreatedDate);
            return answer;

        }//END HttpGet

        [HttpPatch("{id}/Answer")]
        public AnswerModel Patch([FromBody] AnswerModel _answer, int id){
            var answer = db.AnswersTable.FirstOrDefault(an => an.Id == id);
            
            answer.Answer = _answer.Answer;
            answer.CreatedDate = DateTime.Now;
            this.db.SaveChanges();


            return answer;
        }


    } //END public class LocationsController : ControllerBase
} //END namespace PlacesTravelled.Controllers