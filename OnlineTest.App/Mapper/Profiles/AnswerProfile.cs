using AutoMapper;
using OnlineTest.App.Models;
using OnlineTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.App.Mapper.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile(){
             CreateMap<Answer, AnswerDto>();
             CreateMap<AnswerDto, Answer>();
            CreateMap<Answer, AnswerListAdminDto>();
            CreateMap<AnswerListAdminDto, Answer>();
            CreateMap<Answer, AnswerListUserDto>();
            CreateMap<AnswerListUserDto, Answer>();

        }

    }
}
