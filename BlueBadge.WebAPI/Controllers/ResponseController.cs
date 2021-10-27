﻿using BlueBadge.Services;
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
        private ResponseService CreateResponseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var responeService = new ResponseService(userId);
            return responeService;
        }
    }
}