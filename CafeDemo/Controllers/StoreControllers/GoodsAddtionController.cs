using AutoMapper;
using CafeDemo.Models;
using CafeDemo.Models.CafeModels;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.StoreViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CafeDemo.Controllers.StoreControllers
{
    public class GoodsAddtionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //POST: api/GoodsAddtions
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult PostGoodsAddtion(GoodsAddtionViewModel goodsAddtionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("هناك خطأ أعد المحاولة بشكل صحيح");
            }
            if (!IsGoodsAddtionViewModelValid(goodsAddtionViewModel))
            {
                return BadRequest("please fill SellerId&&TagerId&&ProductId with existing ones");
            }
            //select the Goods to get the price and the last count
            var good = db.Goods.Find(goodsAddtionViewModel.GoodsId);
            //map the objects
            var goodsAddtion = Mapper.Map<GoodsAddtion>(goodsAddtionViewModel);
            // set the proprties that not matched
            goodsAddtion.Time = DateTime.Now;
            goodsAddtion.NumberOfItems = goodsAddtionViewModel.NumberOfBoxes * good.NumberOfItemsInBox;
            goodsAddtion.PreviousProductsCount = good.TotalItemsCount;
            goodsAddtion.UpdatedProductsCount = (good.TotalItemsCount +(goodsAddtionViewModel.NumberOfBoxes * good.NumberOfItemsInBox));
            goodsAddtion.ItemsSellPrice = goodsAddtion.NumberOfItems * good.SellPrice;
            goodsAddtion.ItemsBuyPrice = goodsAddtion.NumberOfItems * good.BuyPrice;
            // add the object to the db
            db.GoodsAddtions.Add(goodsAddtion);
            //update the product count to the new value
            good.TotalItemsCount += (goodsAddtionViewModel.NumberOfBoxes * good.NumberOfItemsInBox);
            if ((good.TotalItemsCount/good.NumberOfItemsInBox) > good.AlertLimit)
            {
                good.IsLimited = false;
            }
            db.SaveChanges();
            return Ok("تم");
        }
        //GET: api/GoodsAddtion/GoodsAddtionPage
        [Route("api/GoodsAddtion/GoodsAddtionPage")]
        [HttpGet]
        [ResponseType(typeof(List<DropDownItem>))]
        public IHttpActionResult GoodsAddtionPage()
        {
            var result = db.Goods.ToList().Select(Mapper.Map<Goods, DropDownItem>);
            return Ok(result);
        }
        //GET: api/GoodsAddtions
        [HttpGet]
        [ResponseType(typeof(List<GoodsAddtionResponseViewModel>))]
        public IHttpActionResult GetGoodsAddtions()
        {
            var goodsAddtions = db.GoodsAddtions.OrderByDescending(g => g.Time).ToList();
            var result = new List<GoodsAddtionResponseViewModel>();
            foreach (var temp in goodsAddtions)
            {
                var asd = Mapper.Map<GoodsAddtion, GoodsAddtionResponseViewModel>(temp);
                asd.GoodsAddtionId = temp.Id;
                asd.GoodsName = temp.Goods.Name;
                asd.NumberOfBoxes = (int)(temp.NumberOfItems / temp.Goods.NumberOfItemsInBox);
                asd.PreviousNumberOfBoxes = temp.PreviousProductsCount/temp.Goods.NumberOfItemsInBox;
                asd.UpdatedNumberOfBoxes = temp.UpdatedProductsCount / temp.Goods.NumberOfItemsInBox;
                asd.Date = temp.Time.ToShortDateString();
                asd.Time = temp.Time.ToShortTimeString();
                asd.Proofts = temp.ItemsSellPrice - temp.ItemsBuyPrice;
                result.Add(asd);
            }
            return Ok(result);
        }
        private bool IsGoodsAddtionViewModelValid(GoodsAddtionViewModel goodsAddtionViewModel)
        {
            var seller = db.Sellers.SingleOrDefault(s => s.Id == goodsAddtionViewModel.SellerId);
            var tager = db.Tagers.SingleOrDefault(t => t.Id == goodsAddtionViewModel.TagerId);

            var Good = db.Goods.SingleOrDefault(p => p.Id == goodsAddtionViewModel.GoodsId);
            if (seller == null || tager == null || Good == null)
            {
                return false;
            }
            return true;
        }

    }
}
