﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestOmgevingFail2ban.Models;
using TestOmgevingFail2ban.Models.Repositories;
using WebApi.Models;
using WebApi.Models.DTO;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    {
        private ServiceRepository serviceRepo;
        private DtoOrganiser organiser;
        public ServiceController()
        {
            DbEntitiesContext context = new DbEntitiesContext();
            serviceRepo = new ServiceRepository(context);
            this.organiser = new DtoOrganiser();
        }
        [HttpGet]
        [ResponseType(typeof(ServiceDto))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ]
        [Route("name={name}/server_id={server_id}")]
        public IHttpActionResult getService(string name, int server_id)
        {
            var s = serviceRepo.FindByNameAndServerID(name, server_id);
            if (s == null)
            {
                return Content(HttpStatusCode.NotFound, String.Format("the service with id '{0}' and name {1} dont exist", server_id, name));
            }
            return Ok(organiser.convertToServiceDto(s));
        }
        [HttpPost]
        [ResponseType(typeof(ServiceDto))]
        public IHttpActionResult PostService(string name, int server_id)
        {
            try
            {
                Service new_service = new Service() { Name = name, Server_ID = server_id };
                serviceRepo.Add(new_service);
                serviceRepo.SaveChanges();
                return Ok(organiser.convertToServiceDto(new_service));
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}
