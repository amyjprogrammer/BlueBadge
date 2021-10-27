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
    public class ResponseController : ApiController
    {
        /*public IHttpActionResult Post(ResponseCreate response)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateResponseService();

            if (!service.CreateResponse(response))
                return InternalServerError();
        }*/

        private ResponseService CreateResponseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var responeService = new ResponseService(userId);
            return responeService;
        }
    }
}
