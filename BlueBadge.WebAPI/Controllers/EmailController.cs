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
    public class EmailController : ApiController
    {
        public IHttpActionResult Get()
        {
            var emailService = CreateEmailService();
            var emails = emailService.GetEmails();
            return Ok(emails);
        }

        //Create or Put
        public IHttpActionResult Post(EmailCreate email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmailService();

            if (!service.CreateEmail(email))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var emailService = CreateEmailService();
            var email = emailService.GetEmailById(id);
            return Ok(email);
        }

        public IHttpActionResult Put(EmailEdit email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmailService();

            if (!service.UpdateEmail(email))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEmailService();

            if (!service.DeleteEmail(id))
                return InternalServerError();

            return Ok();
        }

        private EmailService CreateEmailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var emailService = new EmailService(userId);
            return emailService;
        }
    }
}
