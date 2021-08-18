using AutoMapper;
using ShoppingBasketService.Api.Models;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CreateBasketRequestModel, Basket>();

            CreateMap<Basket, BasketDtoModel>().ReverseMap();
        }
    }
}
