using AutoMapper;
using OnlineTest.App.Models;
using OnlineTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.App.Mapper.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile (){
             CreateMap<Question, QuestionDto>();
             CreateMap<QuestionDto, Question>();
            CreateMap<Question, QuestionListDto>();
            CreateMap<QuestionListDto, Question>();

        }

    }
}
