using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostDTO, Post>();
        } 
    }
}
