using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.API.Configurations
{
    public class MapperCongifuration : Profile
    {
        public MapperCongifuration()
        {
            CreateMap<WC.Model.User, DTO.User>().ReverseMap();
            CreateMap<WC.Model.Note, DTO.Note>().ReverseMap();
        }
    }
}
