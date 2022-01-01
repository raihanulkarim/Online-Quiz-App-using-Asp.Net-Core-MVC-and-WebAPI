using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizApi.Models;
using OnlineQuizApi.Repositories;
using System.Threading.Tasks;

namespace OnlineQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository questionsRepository;
        private readonly ICategoryRepository categoryRepository;

        public QuestionsController(IQuestionsRepository questionsRepository, ICategoryRepository categoryRepository)
        {
            this.questionsRepository = questionsRepository;
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<ActionResult<Questions>> GetAllQuestions()
        {
            try
            {
                var ques = await questionsRepository.GetQuestions();
                return Ok(ques);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data!");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Questions>> GetQuestion(int id)
        {
            try
            {
                var ques = await questionsRepository.GetQuestion(id);
                if (ques == null)
                {
                    return NotFound();
                }
                return ques;
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data!");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Questions>> AddQuestion(Questions questions)
        {
            try
            {
                if (questions == null)
                {
                    return BadRequest();
                }
                var ques = await questionsRepository.AddQuestion(questions);
                return CreatedAtAction(nameof(GetQuestion),new{id = ques.Id } ,ques);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Adding data!");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Questions>> UpdateQuestion(int id, Questions questions)
        {
            try
            {
                if (id != questions.Id)
                {
                    return BadRequest("ID does not match");
                }
                var ques = await questionsRepository.GetQuestion(id);
                if (ques == null)
                {
                    return NotFound($"Question with id{id} not found!");
                }

               return await questionsRepository.UpdateQuestion(questions);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating data!");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            try
            {
                var ques = await questionsRepository.GetQuestion(id);
                if (ques == null)
                {
                    return NotFound($"Question with id{id} not found!");
                }

               await questionsRepository.DeleteQuestion(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Deleting data!");
            }
        }
        [HttpGet("GetQuestionByCategory/{catId:int}")]
        public async Task<ActionResult<Questions>> GetQuestionByCategory(int Catid)
        {
            try
            {
                var cat = await categoryRepository.GetCategory(Catid);
                if (cat == null)
                {
                    return NotFound($"Categorty with id {Catid} not found!");
                }
                return Ok(await questionsRepository.GetQuestionsByCat(Catid));
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data!");
            }
        }
    }
}
