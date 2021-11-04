using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Models.Response.Models;
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
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private int starting = 0;
        public IHttpActionResult Post(ResponseCreate responseCreate)
        {
            if (responseCreate == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ResponseService();

            if (!service.CreateResponse(responseCreate))
                return InternalServerError();
            
            return Ok($"A Selection was made.");
        }

        public IHttpActionResult Get()
        {
            var response = new ResponseService();
            var responses = response.GetResponses();
            return Ok(responses);
        }

        public IHttpActionResult Put(ResponseEdit response)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ResponseService();

            if (!service.UpdateResponse(response))
                return InternalServerError();

            return Ok("Response was edited");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new ResponseService();

            if (!service.DeleteResponse(id))
                return InternalServerError();
            return Ok("Response was deleted");
        }

        public IHttpActionResult GetId(int id)
        {
            var responseService = new ResponseService();
            var response = responseService.GetResponseById(id);
            return Ok(response);
        }
    }
}
