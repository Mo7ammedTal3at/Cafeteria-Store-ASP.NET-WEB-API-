using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CafeDemo.DTOs;
using CafeDemo.Models.CafeModels;

using CafeDemo.Models.ViewModels.Payment;
using CafeDemo.Models.ViewModels.Person;
using CafeDemo.Models.ViewModels.Seller;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel;
using CafeDemo.Models.ViewModels.Category;
using CafeDemo.Models.EnumClasses;
using CafeDemo.Models.ViewModels.Far3;
using CafeDemo.Models.ViewModels.Daraga;
using CafeDemo.Models.ViewModels.ReportViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsSellViewModel;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.Tager;

namespace CafeDemo.App_Start
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            // Person
            Mapper.CreateMap<Person, PersonDto>();
            Mapper.CreateMap<PersonDto, Person>();
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<PersonViewModel,Person >();
            Mapper.CreateMap<Person, PersonDetailsViewModel>();
            Mapper.CreateMap<PersonDetailsViewModel, Person>();
            Mapper.CreateMap<Person, PersonViewModel>();   //abdochanges
            Mapper.CreateMap<PersonViewModel, Person>();  // abdochanges

            

            //Seller
            Mapper.CreateMap<Seller, SellerDto>();
            Mapper.CreateMap<SellerDto, Seller>();
            Mapper.CreateMap<Seller, RegisterSellerViewModel>();
            Mapper.CreateMap<RegisterSellerViewModel, Seller>();
            Mapper.CreateMap<Seller, SellerLoginViewModel>();
            Mapper.CreateMap<SellerLoginViewModel, Seller>();
            Mapper.CreateMap<Seller, SellerDetailsViewModel>();
            Mapper.CreateMap<SellerDetailsViewModel, Seller>();

            

            //Ta2re4a
            Mapper.CreateMap<Ta2re4a, Ta2re4aDto>();
            Mapper.CreateMap<Ta2re4aDto, Ta2re4a>();
            //Category
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();

            //Payment
            Mapper.CreateMap<Payment, PaymentViewModel>();
            Mapper.CreateMap<PaymentViewModel, Payment>();
            // category
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();
            //FAr3
            Mapper.CreateMap<Far3, Far3ViewModel>();
            Mapper.CreateMap<Far3ViewModel, Far3>();
            //Daraga
            Mapper.CreateMap<Daraga, DaragaViewModel>();
            Mapper.CreateMap<DaragaViewModel, Daraga>();
            ///////////////////////  Store Models ///////////////////////

            Mapper.CreateMap<GoodsAddtion, GoodsAddtionViewModel>();
            Mapper.CreateMap<GoodsAddtionViewModel, GoodsAddtion>();
            Mapper.CreateMap<GoodsAddtion, GoodsAddtionResponseViewModel>();
            Mapper.CreateMap<GoodsAddtionResponseViewModel, GoodsAddtion>();

            Mapper.CreateMap<GoodsSellViewModel, GoodsSell>();
            Mapper.CreateMap<GoodsSell,GoodsSellViewModel>();
            Mapper.CreateMap<GoodsSellsResponseViewModel, GoodsSell>();
            Mapper.CreateMap<GoodsSell,GoodsSellsResponseViewModel>();

            Mapper.CreateMap<Goods, GoodsViewModel>();
            Mapper.CreateMap<GoodsViewModel, Goods>();
            Mapper.CreateMap<Goods, GoodsPostViewModel>();
            Mapper.CreateMap<GoodsPostViewModel, Goods>();
            Mapper.CreateMap<GoodsEditViewModel, Goods>();
            Mapper.CreateMap<Goods, GoodsEditViewModel>();

            /////////////////////  Report Store Model ///////////////////
            Mapper.CreateMap<StoreReportViewModel, Goods>();
            Mapper.CreateMap<Goods, StoreReportViewModel>();
            /////////// DropDownItem //////////////////////////
            Mapper.CreateMap<Kafteria, DropDownItem>();
            Mapper.CreateMap<Seller, DropDownItem>();
            Mapper.CreateMap<Daraga, DropDownItem>();
            Mapper.CreateMap<Far3, DropDownItem>();
            Mapper.CreateMap<Person, DropDownItem>();
            Mapper.CreateMap<Tager, DropDownItem>();
            Mapper.CreateMap<Category, DropDownItem>();
            Mapper.CreateMap<Goods, DropDownItem>();

            /////////////// Tager ///////////////////////////
            Mapper.CreateMap<Tager, TagerViewModel>();
            Mapper.CreateMap<Tager, TagerGoodsAddtionsViewModel>();
            Mapper.CreateMap<Tager, TagerGoodsAddtionsPaymentsViewModel>();

            /////////////////////////////// GoodsAddtionPayments//////////////////
            Mapper.CreateMap<PaymentAddtionViewModel, GoodsAddtionPayment>();

            /////////////////////Abdo changes////////////////////////////
            Mapper.CreateMap<ReportResponsePageViewModel, Goods>();
            Mapper.CreateMap<Goods, ReportResponsePageViewModel>();
            Mapper.CreateMap<ReportResponsePageViewModel, GoodsAddtion>();
            Mapper.CreateMap<GoodsAddtion, ReportResponsePageViewModel>();
            Mapper.CreateMap<Person, DropDownItem>();




        }
    }
}