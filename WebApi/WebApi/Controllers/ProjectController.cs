using BL.Handlers;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    public class ProjectController : ApiController
    {
    // GET: api/Project
        [JwtAuthAttribute]
        public List<Project> Get(int userId)
        {
          return new ProjectsHandler().GetProjects(userId);
        }


    }
}
