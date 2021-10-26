using BlueBadge.Data;
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
/*        private PollChoice CreatePollChoiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var pollChoiceService = new PollChoiceService(userId);
            return pollChoiceService;
        }*/
    }
}
