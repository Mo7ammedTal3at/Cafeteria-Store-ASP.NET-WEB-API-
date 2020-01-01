using AutoMapper;
using CafeDemo.Models;
using CafeDemo.Models.CafeModels;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.StoreViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsSellViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CafeDemo.Controllers.StoreControllers
{
    public class GoodsSellsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //POST: api/GoodsSells
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult PostGoodsSell(GoodsSellViewModel goodsSellViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("هناك خطأ أعد المحاولة بشكل صحيح");
            }
            if (!IsGoodsAddtionViewModelValid(goodsSellViewModel))
            {
                return BadRequest("please fill RecievierId&&ProductId&&KafteriaId with existing ones");
            }
            //select the product to get the price and the last count
            var good = db.Goods.Find(goodsSellViewModel.GoodsId);
            //check if the requested amount is available
            if (good.TotalItemsCount < (goodsSellViewModel.NumberOfBoxes * good.NumberOfItemsInBox))
            {
                return BadRequest("لا يمكن بيع الكمية المطلوبة لأن الكمية الحالية " +(good.TotalItemsCount / good.NumberOfItemsInBox) + " كراتين");
            }
            //map the objects
            var goodsSell = Mapper.Map<GoodsSell>(goodsSellViewModel);
            // set the proprties that not matched
            goodsSell.NumberOfItems = (goodsSellViewModel.NumberOfBoxes * good.NumberOfItemsInBox);
            goodsSell.ItemsBuyPrice = goodsSell.NumberOfItems * good.BuyPrice;
            goodsSell.ItemsSellPrice = goodsSell.NumberOfItems * good.SellPrice;
            goodsSell.Time = DateTime.Now;
            goodsSell.PreviousProductsCount = good.TotalItemsCount;
            goodsSell.UpdatedProductsCount = (good.TotalItemsCount -(goodsSellViewModel.NumberOfBoxes * good.NumberOfItemsInBox));
            // add the object to the db
            db.GoodsSells.Add(goodsSell);
            //update the product count to the new value
            good.TotalItemsCount -= (goodsSellViewModel.NumberOfBoxes*good.NumberOfItemsInBox);
            //set is limited to true if the remining items less than alert limit amount
            if ((good.TotalItemsCount/good.NumberOfItemsInBox) <= good.AlertLimit)
            {
                good.IsLimited = true;
            }
            db.SaveChanges();
            return Ok("تم");
        }
        //GET: api/GoodsSells/GoodsSellsPage
        [Route("api/GoodsSells/GoodsSellsPage")]
        [HttpGet]
        [ResponseType(typeof(GoodsSellesPageViewModel))]
        public IHttpActionResult GoodsSellsPage()
        {
            var goods = db.Goods.ToList().Select(Mapper.Map<Goods, DropDownItem>).ToList();
            var recievers = db.Sellers.ToList().Select(Mapper.Map<Seller, DropDownItem>).ToList();
            var kafterias = db.Kafterias.ToList().Select(Mapper.Map<Kafteria, DropDownItem>).ToList();
            var result = new GoodsSellesPageViewModel
            {
                Products=goods,
                Recievers=recievers,
                Kafterias=kafterias
            };
            return Ok(result);
        }
        //GET: api/GoodsSells
        [HttpGet]
        [ResponseType(typeof(List<GoodsSellsResponseViewModel>))]
        public IHttpActionResult GetGoodsSells()
        {
            var goodsSells = db.GoodsSells.OrderByDescending(g => g.Time).ToList();
            var result = new List<GoodsSellsResponseViewModel>();
            foreach (var temp in goodsSells)
            {
                var asd = Mapper.Map<GoodsSell, GoodsSellsResponseViewModel>(temp);
                asd.GoodsSellId = temp.Id;
                asd.GoodsName = temp.Goods.Name;
                asd.NumberOfBoxes = temp.NumberOfItems / temp.Goods.NumberOfItemsInBox;
                asd.Date = temp.Time.ToShortDateString();
                asd.Time = temp.Time.ToShortTimeString();
                asd.KafteriaName = temp.Kafteria.Name;
                asd.RecieverName = temp.Seller.Name;
                asd.PreviousNumberOfBoxes = temp.PreviousProductsCount/temp.Goods.NumberOfItemsInBox;
                asd.UpdatedNumberOfBoxes = temp.UpdatedProductsCount / temp.Goods.NumberOfItemsInBox;
                asd.Proofts = temp.ItemsSellPrice - temp.ItemsBuyPrice;
                result.Add(asd);
            }
            return Ok(result);
        }
        private bool IsGoodsAddtionViewModelValid(GoodsSellViewModel goodsSellViewModel)
        {
            var reciever = db.Sellers.SingleOrDefault(t => t.Id == goodsSellViewModel.SellerId);
            var good = db.Goods.SingleOrDefault(p => p.Id == goodsSellViewModel.GoodsId);
            var kafteria = db.Kafterias.SingleOrDefault(p => p.Id == goodsSellViewModel.KafteriaId);
            if ( reciever == null || good == null|| kafteria==null)
            {
                return false;
            }
            return true;
        }
    }
}
