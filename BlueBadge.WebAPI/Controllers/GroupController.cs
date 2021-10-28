using BlueBadge.Models.Group.Models;
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
    public class GroupController : ApiController
    {
        public IHttpActionResult Get()
        {
            var groupService = CreateGroupService();
            var groups = groupService.GetGroups();
            return Ok(groups);
        }

        public IHttpActionResult Post(GroupCreate group)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGroupService();

            if (!service.CreateGroup(group))
                return InternalServerError();

            return Ok();
        }

        private GroupService CreateGroupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var groupService = new GroupService(userId);
            return groupService;
        }

    }
}
