using AutoMapper;
using ShoppingBasketService.Api.Models;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;

namespace ShoppingBasketService.Api.Profiles
{
    public class BasketCheckoutProfile : Profile
    {
        public BasketCheckoutProfile()
        {
            CreateMap<BasketCheckoutApplicationModel, BasketCheckoutMessage>().ReverseMap();
            CreateMap<BasketCheckoutApplicationModel, BasketCheckoutApplicationModel>().ReverseMap();
        }
    }
}
