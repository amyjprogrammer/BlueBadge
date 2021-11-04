using BlueBadge.Data;
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
    public class PollChoiceController : ApiController
    {
        //Get All Poll Choice Controller
        public IHttpActionResult Get()
        {
            var pollService = new PollChoiceService();
            var pollChoices = pollService.GetPollChoice();
            return Ok(pollChoices);
        }

        //Post Poll Choice Contoller
        public IHttpActionResult Post(PollChoiceCreate pollChoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new PollChoiceService();

            if (!service.CreatePollChoice(pollChoice))
                return InternalServerError();

            return Ok();
           
        }

        //Get Poll Choice By Id Contoller 
        public IHttpActionResult Get(int id)
        {
            var pollService = new PollChoiceService();
            var pollChoice = pollService.GetPollChoiceById(id);
            return Ok(pollChoice);
        }

        //Put Poll Choice Contoller 
        public IHttpActionResult Put(PollChoiceEdit pollChoice)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var service = new PollChoiceService();

            if (!service.UpdatePollChoice(pollChoice))
                return InternalServerError();

            return Ok();
        }

        //Delete Poll Choice Controller 
        public IHttpActionResult DeletePollChoice(int id)
        {
            var service = new PollChoiceService();

            if (!service.DeletePollChoice(id))
                return InternalServerError();

            return Ok();
        }
    }
}


