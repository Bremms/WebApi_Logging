﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models;
using WebApi.Models.DTO;

namespace WebApi.Models
{
    public class DtoOrganiser
    {
        public GeoDto convertGeoToDto(Geo geo)
        {
            GeoDto dto = new GeoDto()
            {
                Country = geo.CountryCode,
                Geo = geo.GeoCityCountry,
                Ip = geo.Ip,
                Latitude = geo.Latitude,
                Longitude = geo.Longitude
            };
            return dto;
        }
        public BannedClientDto convertBannedClient(BannedClient bc)
        {
            return new BannedClientDto() { ID = bc.ID, Ip = bc.Ip, Count = bc.Count, Longitude = bc.Longitude, Latitude = bc.Latitude, Country = bc.Country, Geo = bc.Geo, Created = bc.Lastban, Service_Id = bc.Service_ID, IpScore_Id = bc.IpScore_ID };
        }
        public ServerDto convertServer(Server s)
        {
            return new ServerDto() { Name = s.Name, User_id = s.User_ID, Server_id = s.ID };
        }
        public BannedClient convertToBannedClient(PostBanDto bcDto)
        {
            return new BannedClient() { Ip = bcDto.Ip, Count = 1, Longitude = bcDto.Longitude, Latitude = bcDto.Latitude, Country = bcDto.CountryCode, Geo = bcDto.Geo, Lastban = DateTime.Now, Service_ID = bcDto.Service_Id };
        }
        public ServiceDto convertToServiceDto(Service s)
        {
            return new ServiceDto() { Name = s.Name, Port = s.Port, Server_ID = s.Server_ID, Sub_ID = s.Subscription_ID, ID = s.ID };
        }
        public IBlackAndWhiteElement convertToWhiteOrBlackListElement(BwPostDto element, string delimiter)
        {
            if (delimiter.Equals("black"))
            {
                return new BlackListElement() { Ip = element.Ip, Server_id = element.Server_id, Duration = element.Duration };
            }
            else
            {
                return new WhiteListElement() { Ip = element.Ip, Server_id = element.Server_id, Duration = element.Duration };
            }
        }
        public BwDto convertToBwDto(IBlackAndWhiteElement bwElement)
        {
            return new BwDto() { ID = bwElement.ID, Ip = bwElement.Ip, Duration = bwElement.Duration, Server_Id = bwElement.Server_id, Is_Activated = bwElement.Is_Activated };
        }
        public GlobalBannedClientDto convertToGlobalDto(IpScore bc)
        {
            return new GlobalBannedClientDto() { Id = bc.ID ,Ip = bc.Ip,IsGlobalBanned = bc.IsCurrentlyBanned };
        }
    }
}