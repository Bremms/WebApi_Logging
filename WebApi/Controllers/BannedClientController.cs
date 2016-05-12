using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestOmgevingFail2ban.Models;
using TestOmgevingFail2ban.Models.Repositories;
using WebApi.Models;
using WebApi.Models.DTO;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Ban")]
    public class BannedClientController : ApiController
    {
        private BannedClientRepository banRepo;
        private IpScoreRepository ipRepo;
        private DtoOrganiser organizer;
        public BannedClientController()
        {
            DbEntitiesContext context = new DbEntitiesContext();
            banRepo = new BannedClientRepository(context);
            ipRepo = new IpScoreRepository(context);
            organizer = new DtoOrganiser();
        }
        [Route("BannedClients")]
        [ResponseType(typeof(BannedClientDto))]
        [HttpGet]
        public IHttpActionResult getAllBannedClients()
        {
            var bc = banRepo.FindAll();

            if (bc == null)
            {
                return NotFound();
            }
            var bcDtoList = new List<BannedClientDto>();
            foreach (BannedClient b in bc)
            {
                bcDtoList.Add(organizer.convertBannedClient(b));
            }
            return Ok(bcDtoList);
        }
        [Route("GetBan")]
        [ResponseType(typeof(BannedClientDto))]
        [HttpGet]
        public IHttpActionResult GetBan(int service_id, string ip)
        {
            var b = banRepo.FindByServiceAndIp(service_id, ip);
            if (b == null)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The ban with serviceId  '{0}' and Ip '{1}' doesnt exists", service_id, ip));
            }
            return Ok(organizer.convertBannedClient(b));
        }
        [Route("PostBan")]
        [ResponseType(typeof(BannedClientDto))]
        [HttpPost]
        public async Task<IHttpActionResult> PostBan(PostBanDto bcDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var bc = organizer.convertToBannedClient(bcDto);
                banRepo.Add(bc);
                banRepo.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [Route("UpdateCount")]
        [ResponseType(typeof(BannedClientDto))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCount(int service_id, string ip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bc = banRepo.FindByServiceAndIp(service_id, ip);
            if (bc == null)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The BannedClient with serviceId {0} and Ip {1} could not be found", service_id, ip));
            }
            bc.Count += 1;
            await banRepo.SaveChangesAsync();
            return Ok(organizer.convertBannedClient(bc));
        }
        [Route("GlobalBanned")]
        [ResponseType(typeof(List<GlobalBannedClientDto>))]
        [HttpGet]
        public IHttpActionResult GetGlobalBanned(int threshold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bc = ipRepo.FindAll().Where(w => w.Total_score < threshold && w.IsCurrentlyBanned==false);
            List<GlobalBannedClientDto> ips = new List<GlobalBannedClientDto>();
            foreach(var b in bc)
            {
                ips.Add(organizer.convertToGlobalDto(b));
            }
            return Ok(ips);
        }
        [Route("GetAlreadyBannedClients")]
        [ResponseType(typeof(List<GlobalBannedClientDto>))]
        [HttpGet]
        public IHttpActionResult GetClientsBelowThreshold(int threshold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bc = ipRepo.FindAll().Where(w => w.Total_score < threshold && w.IsCurrentlyBanned==true);
            List<GlobalBannedClientDto> ips = new List<GlobalBannedClientDto>();
            foreach (var b in bc)
            {
                ips.Add(organizer.convertToGlobalDto(b));
            }
            return Ok(ips);
        }
        [Route("BanIpGlobal")]
        [HttpPost]
        public IHttpActionResult BanIpGlobal(Boolean ban,[FromUri] int[] ids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach(var id in ids)
            {
                try
                {
                    ipRepo.FindBy(id).IsCurrentlyBanned = ban;
                }catch(Exception exc)
                {

                }
            }
            ipRepo.SaveChanges();
            return Ok("Succes");
        }
        [Route("BansToUnban")]
        [ResponseType(typeof(List<GlobalBannedClientDto>))]
        [HttpGet]
        public IHttpActionResult GetBansToUnban(int threshold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ips = ipRepo.FindAll().Where(x => x.Total_score >= threshold && x.IsCurrentlyBanned == true);
            var result = new List<GlobalBannedClientDto>();
            foreach(var ip in ips)
            {
                result.Add(organizer.convertToGlobalDto(ip));
            }
            return Ok(result);
        }

    }
}
