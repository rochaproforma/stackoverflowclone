
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stackoverflowclone.Models;
using stackoverflowclone.ViewModel;

namespace stackoverflowclone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private StackOverflowContext db {get;set;}

        public SearchController(StackOverflowContext _db)
        { 
            this.db = _db;
        }

        [HttpGet]
        public IEnumerable<SearchResults> Get([FromQuery]string q)
        {
            // query the database
            var answerResults = this.db
                .QuestionsTable
                .OrderBy(o => o.CreatedDate)
                .Select( s => new SearchResults {
                    Answer= s.Question, 
                    Id= s.Id, 
                    
                });
            // returns the results

            var questionResults = this.db
                .AnswersTable
                .Where(w => w.Answer.Contains(q))
                .Select( s => new SearchResults {
                    Question = s.Answer, 
                    Id= s.Id, 
                     
                });;

            var results = new List<SearchResults>();
            results.AddRange(answerResults);
            results.AddRange(questionResults);


            return results.OrderBy(o => o.Id);

        }
    }
}