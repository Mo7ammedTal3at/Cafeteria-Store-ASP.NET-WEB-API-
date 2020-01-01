using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMapper;
using CafeDemo.Models;
using CafeDemo.Models.CafeModels;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.ReportViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsSellViewModel;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsViewModels;

namespace CafeDemo.Controllers.ReportsControllers
{
    public class StoreReportController : ApiController
    {
        private  ApplicationDbContext db = new ApplicationDbContext();
        ////GET: api/StoreReports/ReportsPage
        //[HttpGet]
        //[Route("api/StoreReports/ReportsPage")]
        //[ResponseType(typeof(List<DropDownItem>))]
        //public IHttpActionResult ReportsPage()
        //{
        //    var goods = db.Goods.Select(Mapper.Map<Goods, DropDownItem>).ToList();
        //    return Ok(goods);
        //}

        //Get: api/StoreReports/ReportsPage
        [HttpGet]
        [Route("api/StoreReports/ReportsPage")]
        [ResponseType(typeof(List<DropDownItem>))]
        public IHttpActionResult ReportForGoodSells()
        {
            var goods = db.Goods.Select(Mapper.Map<Goods, DropDownItem>).ToList();
            return Ok(goods);
        }
        
        [HttpPost]
        [Route("api/Reports/Goods/GoodsAddtions")]
        [ResponseType(typeof(ReportResponsePageViewModel))]
        public IHttpActionResult GetGoodsGoodsAdditions(ReportPageViewModel rpvm)
        {
            var goods = db.Goods.SingleOrDefault(g => g.Id == rpvm.GoodsId);
            if (goods == null)
            {
                return BadRequest("هذا المنتج غير موجود");
            }
             var result = goods.GoodsAddtions
                .Where(g => g.Time.Date.CompareTo(rpvm.From.Date) >= 0 && g.Time.Date.CompareTo(rpvm.To.Date) <= 0)
                .OrderByDescending(g => g.Time).ToList();
            var sum = result.Sum(g => g.NumberOfItems);
            var rrpvm = new ReportResponsePageViewModel
            {
                GoodsName = goods.Name,
                From = rpvm.From.ToShortDateString(),
                To = rpvm.To.ToShortDateString(),
                NumberOfBoxes = sum/goods.NumberOfItemsInBox,
                NumberOfItems = sum
            };
            return Ok(rrpvm);
        }

        //POST: api/Reports/Goods/GoodsSells
        [HttpPost]
        [Route("api/Reports/Goods/GoodsSells")]
        [ResponseType(typeof(GoodsSellsResponseViewModel))]
        public IHttpActionResult GetGoodsGoodsSells(ReportPageViewModel rpvm)
        {
            var goods = db.Goods.SingleOrDefault(g => g.Id == rpvm.GoodsId);
            if (goods == null)
            {
                return BadRequest("هذا النتج غير موجود");
            }
            var result = goods.GoodsSells
                .Where(
                    g => g.Time.Date.CompareTo(rpvm.From.Date) >= 0
                         && g.Time.Date.CompareTo(rpvm.To.Date) <= 0
                ).OrderByDescending(g=>g.Time).ToList();

            var goodSr = new List<GoodsSellsResponseViewModel>();

            foreach (var temp in result)
            {
                var asd = Mapper.Map<GoodsSellsResponseViewModel>(temp);
                asd.ItemsSellPrice = (temp.Goods.SellPrice * temp.Goods.TotalItemsCount);
                asd.ItemsBuyPrice = (temp.Goods.BuyPrice * temp.Goods.TotalItemsCount);
                asd.Proofts = asd.ItemsSellPrice - asd.ItemsBuyPrice;
                asd.GoodsName = temp.Goods.Name;
                asd.Time = temp.Time.ToShortTimeString();
                asd.Date = temp.Time.ToShortDateString();
                asd.KafteriaName = temp.Kafteria.Name;
                asd.RecieverName = temp.Seller.Name;
                goodSr.Add(asd);
            }
            return Ok(goodSr);
        }
        //GET: api/Goods/LimitedGoods
        [HttpGet]
        [Route("api/Reports/Goods/LimitedGoods")]
        [ResponseType(typeof(List<GoodsViewModel>))]
        public IHttpActionResult GetLimitedGoods()
        {
            var goods = db.Goods.Where(g => g.IsLimited).ToList();
            var goodsViewModel = new List<GoodsViewModel>();
            foreach (var temp in goods)
            {
                var goodsVm = Mapper.Map<GoodsViewModel>(temp);
                goodsVm.AddtionDate = temp.AddtionTime.ToShortDateString();
                goodsVm.NumberOfBoxes = (int)(temp.TotalItemsCount / temp.NumberOfItemsInBox);
                goodsVm.NumberOfRestItems = (temp.TotalItemsCount % temp.NumberOfItemsInBox);
                goodsViewModel.Add(goodsVm);
            }
            return Ok(goodsViewModel);
        }
    }
}