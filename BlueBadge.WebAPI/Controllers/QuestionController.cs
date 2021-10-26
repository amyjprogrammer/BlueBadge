using BlueBadge.Models;
using BlueBadge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadge.WebAPI.Controllers
{
    [Authorize]
    public class QuestionController : ApiController
    {
        public IHttpActionResult Get()
        {
            var questionService = CreateQuestionService();
            var questions = questionService.GetQuestions();
            return Ok(questions);
        }

        public IHttpActionResult Post(QuestionCreate question)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateQuestionService();

            if (!service.CreateQuestion(question))
                return InternalServerError();

            return Ok();
        }

        private QuestionService CreateQuestionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var questionService = new QuestionService(userId);
            return questionService;
        }

    }
}
