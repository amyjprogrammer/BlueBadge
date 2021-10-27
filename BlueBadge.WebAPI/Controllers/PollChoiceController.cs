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
        public IHttpActionResult Get()
        {
            var pollService = new PollChoiceService();
            var pollChoices = pollService.GetPollChoice();
            return Ok(pollChoices);
        }

        public IHttpActionResult Post(PollChoiceCreate pollChoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new PollChoiceService();

            if (!service.CreatePollChoice(pollChoice))
                return InternalServerError();

            return Ok();
           
        }
    }
}
