using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestOmgevingFail2ban.Models;
using WebApi.Models;
using WebApi.Models.DTO;
namespace WebApi.Controllers
{
    [RoutePrefix("api/Server")]
    public class ServerController : ApiController
    {
        private ServerRepository serverRepo;
        private DtoOrganiser organiser;
        public ServerController()
        {
            DbEntitiesContext context = new DbEntitiesContext();
            serverRepo = new ServerRepository(context);
            organiser = new DtoOrganiser();
        }
        [Route("exists={name}")]
        [HttpGet]
        [ResponseType(typeof(int))]
        public IHttpActionResult ServerExist(string name)
        {
            var s = serverRepo.FindByName(name);
            if (s == null)
            {
                return Content(HttpStatusCode.NotFound, "0");
            }
            return Ok("1");
        }
        [Route("name={name}")]
        [HttpPost]
        [ResponseType(typeof(ServerDto))]
        public async Task<IHttpActionResult> PostServer(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Server s = new Server() { Name = name };
            serverRepo.Add(s);
            await serverRepo.SaveChangesAsync(); // looking if the server has a new id..
            return Ok(s);
        }
    }
}
