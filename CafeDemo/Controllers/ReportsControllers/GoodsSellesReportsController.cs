using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using System.Web.Http.Validation.Validators;
using AutoMapper;
using CafeDemo.Migrations;
using CafeDemo.Models;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.ReportsViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.Kafteria;
using Microsoft.Ajax.Utilities;

namespace CafeDemo.Controllers.ReportsControllers
{
    [RoutePrefix("api/Reports/GoodsSelles")]
    public class GoodsSellesReportsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Get: api/Report/Goods/
        [HttpGet]
        [Route("KafteriaReportsPage")]
        [ResponseType(typeof(List<DropDownItem>))]
        public IHttpActionResult KafteriaDropDown()
        {
            var kafteria = db.Kafterias.Select(Mapper.Map<Kafteria, DropDownItem>);
            return Ok(kafteria);
        }

        //Post: api/Reports/GoodsSelles/Kafterias
        [HttpPost]
        [ResponseType(typeof(GoodsSellsResponseViewModel))]
        [Route("Kafterias")]

        public IHttpActionResult GetKafteriaGoodsAddition(KafteriaGoodsSellsViewModel kafteriaGoodsSellsViewModel)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var kafteria = db.Kafterias.SingleOrDefault(k => k.Id == kafteriaGoodsSellsViewModel.KafteriaId);
            if (kafteria == null)
            {
                return Content(HttpStatusCode.NotFound, "هذه الكافتيريا غير موجوده");
            }
            var result = kafteria.GoodsSells
                .Where(g=>g.Time.Date.CompareTo(kafteriaGoodsSellsViewModel.From.Date)>=0&& g.Time.Date.CompareTo(kafteriaGoodsSellsViewModel.To.Date) <=0)
                .GroupBy(g => g.GoodsId)
                .Select(r =>
                    new GoodsSellsViewModel
                    {
                        Name = db.Goods.Find(r.Key).Name,
                        BoxesCount = r.Sum(rr => rr.NumberOfItems / rr.Goods.NumberOfItemsInBox),
                        ItemsSellPrice = r.Sum(rr => rr.ItemsSellPrice),
                        ItemsBuyPrice = r.Sum(rr => rr.ItemsBuyPrice)
                    });
            var finalResult = new GoodsSellsResponseViewModel();
            finalResult.TotalItemsBuyPrice = result.Sum(r => r.ItemsBuyPrice);
            finalResult.TotalItemsSellPrice = result.Sum(r => r.ItemsSellPrice);
            finalResult.TotalProofts = finalResult.TotalItemsSellPrice - finalResult.TotalItemsBuyPrice;
            finalResult.GoodsSells = result.OrderBy(r=>r.Name).ToList();
            return Ok(finalResult);
        }
        //Post: api/Reports/GoodsSelles/Sellers
        [HttpPost]
        [ResponseType(typeof(GoodsSellsResponseViewModel))]
        [Route("Sellers")]
        public IHttpActionResult GetSellerGoodsSells(
            SellerGoodsSellsViewModel sellerGoodsSellsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var seller = db.Sellers.SingleOrDefault(s => s.Id == sellerGoodsSellsViewModel.SellerId);
            if (seller == null)
            {
                return Content(HttpStatusCode.NotFound, "هذا البائع غير موجود");
            }
            var result = seller.GoodsSells
                .Where(g => g.Time.Date.CompareTo(sellerGoodsSellsViewModel.From.Date) >= 0 && g.Time.Date.CompareTo(sellerGoodsSellsViewModel.To.Date) <= 0)
                .GroupBy(g => g.GoodsId)
                .Select(r =>
                    new GoodsSellsViewModel
                    {
                        Name = db.Goods.Find(r.Key).Name,
                        BoxesCount = r.Sum(rr => rr.NumberOfItems / rr.Goods.NumberOfItemsInBox),
                        ItemsSellPrice = r.Sum(rr => rr.ItemsSellPrice),
                        ItemsBuyPrice = r.Sum(rr => rr.ItemsBuyPrice)
                    });
            var finalResult = new GoodsSellsResponseViewModel();
            finalResult.TotalItemsBuyPrice = result.Sum(r => r.ItemsBuyPrice);
            finalResult.TotalItemsSellPrice = result.Sum(r => r.ItemsSellPrice);
            finalResult.TotalProofts = finalResult.TotalItemsSellPrice - finalResult.TotalItemsBuyPrice;
            finalResult.GoodsSells = result.OrderBy(r => r.Name).ToList();
            return Ok(finalResult);
        }

    }
}
