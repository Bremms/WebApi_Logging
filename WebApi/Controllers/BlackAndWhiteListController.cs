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
    [Authorize]
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
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(dto.Ip==null&&dto.Duration==null)
            {
                return BadRequest();
            }
            WhiteListElement wl =(WhiteListElement) organiser.convertToWhiteOrBlackListElement(dto, "white");
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
                return Content(HttpStatusCode.NotFound,String.Format("The server with id {0} could not be found",server_id));

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
    }
}
