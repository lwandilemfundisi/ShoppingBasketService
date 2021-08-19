﻿using AutoMapper;
using ShoppingBasketService.Api.Models;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Profiles
{
    public class BasketLineProfile : Profile
    {
        public BasketLineProfile()
        {
            CreateMap<AddBasketLineApplicationModel, AddBasketLineRequestModel>();
            CreateMap<UpdateBasketLineApplicationModel, UpdateBasketLineRequestModel>();
            CreateMap<DeleteBasketLineApplicationModel, DeleteBasketLineRequestModel>();
            CreateMap<BasketLineDtoModel, BasketLine>().ReverseMap();

        }
    }
}
