using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC;

namespace WC.API.Configurations
{
    public class MapperCongifuration : Profile
    {
        public MapperCongifuration()
        {
            CreateMap<Model.User, DTO.User>().ReverseMap();
            CreateMap<Model.Note, DTO.Note>().ReverseMap();
        }
    }
}
