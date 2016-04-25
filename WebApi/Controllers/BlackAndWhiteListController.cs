using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestOmgevingFail2ban.Models;
using WebApi.Models;
using WebApi.Models.DTO;
using WebApi.Models.Repositories;

namespace WebApi.Controllers
{
    [RoutePrefix("api/bwList")]
    public class BlackAndWhiteListController : ApiController
    {
        private BlackListRepository blackRepo;
        private WhiteListRepository whiteRepo;
        private ServerRepository serverRepo;
        private DtoOrganiser organiser;
        public BlackAndWhiteListController()
        {
            var context = new DbEntitiesContext();
            blackRepo = new BlackListRepository(context);
            whiteRepo = new WhiteListRepository(context);
            serverRepo = new ServerRepository(context);
            organiser = new DtoOrganiser();
        }
        [HttpPost]
        [ResponseType(typeof(BwDto))]
        [Route("AddWhiteList")]
        public IHttpActionResult AddToWhiteList(BwPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (dto.Ip == null && dto.Duration == null)
            {
                return BadRequest();
            }
            if (dto.Duration < DateTime.Now)
            {
                return Content(HttpStatusCode.BadRequest, "The duration has to be in the future");
            }
            WhiteListElement wl = (WhiteListElement)organiser.convertToWhiteOrBlackListElement(dto, "white");
            whiteRepo.Add(wl);
            whiteRepo.SaveChangesAsync();
            return Ok(organiser.convertToBwDto(wl));
        }
        [HttpPost]
        [ResponseType(typeof(BwDto))]
        [Route("AddBlackList")]
        public IHttpActionResult AddTBlackList(BwPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (dto.Ip == null && dto.Duration == null)
            {
                return BadRequest();
            }
            if (dto.Duration < DateTime.Now)
            {
                return Content(HttpStatusCode.BadRequest, "The duration has to be in the future");
            }
            BlackListElement bl = (BlackListElement)organiser.convertToWhiteOrBlackListElement(dto, "black");
            blackRepo.Add(bl);
            blackRepo.SaveChangesAsync();
            return Ok(organiser.convertToBwDto(bl));
        }
        [HttpGet]
        [ResponseType(typeof(BwDto))]
        [Route("getBlackList/server_id={server_id}")]
        public IHttpActionResult GetBlackList(int server_id)
        {
            try
            {
                Server s = serverRepo.FindBy(server_id);
                List<BlackListElement> blackLists = s.BlackList.ToList();
                List<BwDto> banListDto = blackLists.Select(b => organiser.convertToBwDto(b)).ToList();
                return Ok(banListDto);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The server with id {0} could not be found", server_id));

            }
        }
        [HttpGet]
        [ResponseType(typeof(BwDto))]
        [Route("getWhiteList/server_id={server_id}")]
        public IHttpActionResult GetWhiteList(int server_id)
        {
            try
            {
                Server s = serverRepo.FindBy(server_id);
                List<WhiteListElement> whiteLists = s.WhiteList.ToList();
                List<BwDto> banListDto = whiteLists.Select(b => organiser.convertToBwDto(b)).ToList();
                return Ok(banListDto);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The server with id {0} could not be found", server_id));
            }

        }
        [HttpGet]
        [ResponseType(typeof(BwDto))]
        [Route("getIpsToWhiteList/server_id={server_id}")]
        public IHttpActionResult GetIpsToWhiteList(int server_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Server s = serverRepo.FindBy(server_id);
                List<WhiteListElement> whiteList = s.WhiteList.Where(w => w.Is_Activated == false && w.Duration>DateTime.Now).ToList();
                return Ok(whiteList.Select(b => organiser.convertToBwDto(b)));

            }catch(Exception e)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The server with id {0} could not be found", server_id));
            }
        }
        [HttpGet]
        [ResponseType(typeof(BwDto))]
        [Route("getExpiredWhitelistedIps/server_id={server_id}")]
        public IHttpActionResult getExpiredWhitelistedIps(int server_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Server s = serverRepo.FindBy(server_id);
                List<WhiteListElement> whiteList = s.WhiteList.Where(w => w.Is_Activated == true && w.Duration < DateTime.Now).ToList();
                return Ok(whiteList.Select(b => organiser.convertToBwDto(b)));

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The server with id {0} could not be found", server_id));
            }
        }
        [HttpGet]
        [ResponseType(typeof(BwDto))]
        [Route("getIpsToBlackList/server_id={server_id}")]
        public IHttpActionResult GetIpsToBlackList(int server_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Server s = serverRepo.FindBy(server_id);
                List<BlackListElement> whiteList = s.BlackList.Where(w => w.Is_Activated == false && w.Duration > DateTime.Now).ToList();
                return Ok(whiteList.Select(b => organiser.convertToBwDto(b)));

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The server with id {0} could not be found", server_id));
            }
        }
        [HttpGet]
        [ResponseType(typeof(BwDto))]
        [Route("getExpiredBlacklistedIps/server_id={server_id}")]
        public IHttpActionResult getExpiredBlacklistedIps(int server_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Server s = serverRepo.FindBy(server_id);
                List<BlackListElement> whiteList = s.BlackList.Where(w => w.Is_Activated == true && w.Duration < DateTime.Now).ToList();
                return Ok(whiteList.Select(b => organiser.convertToBwDto(b)));

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The server with id {0} could not be found", server_id));
            }
        }
    }
}
