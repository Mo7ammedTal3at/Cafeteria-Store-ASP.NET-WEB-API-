using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CafeDemo.Models;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionPaymentViewModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel;
using CafeDemo.Models.ViewModels.StoreViewModels.Tager;

namespace CafeDemo.Controllers.StoreControllers
{
    public class TagersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //completed(AbouNasser)
        // GET: api/Tagers
        [ResponseType(typeof(List<TagerViewModel>))]
        public async Task<IHttpActionResult> GetTagers()
        {
            var tagers =await db.Tagers.ToListAsync();
            var result = new List<TagerViewModel>();
            foreach (var temp in tagers)
            {
                var tagerViewModel = Mapper.Map<TagerViewModel>(temp);
                tagerViewModel.TotalPayments = temp.GoodsAddtions?.Sum(g => (g.Goods.BuyPrice * g.NumberOfItems)) ?? 0;
                tagerViewModel.PaidPayments = temp.GoodsAddtionPayments?.Sum(g => g.Value) ?? 0;
                tagerViewModel.RemainingPayments = tagerViewModel.TotalPayments - tagerViewModel.PaidPayments;
                result.Add(tagerViewModel);
            }
            return Ok(result);
        }
        //completed(AbouNasser)
        // GET: api/Tagers/GoodsAddtions/5
        [Route("api/Tagers/GoodsAddtions/{id}")]
        [ResponseType(typeof(TagerGoodsAddtionsViewModel))]
        public async Task<IHttpActionResult> GetTagerGoodsAddtions(int id)
        {
            var tager = await db.Tagers.SingleOrDefaultAsync(t => t.Id == id);
            if (tager == null)
            {
                return BadRequest("هذا التاجر غير موجود");
            }
            
            var tagerGoodsAddtions = tager.GoodsAddtions.OrderByDescending(g => g.Time).ToList();
            var tagerGoodsAddtionsViewModels=new List<GoodsAddtionResponseViewModel>();
            foreach (var temp in tagerGoodsAddtions)
            {
                var goodsAVM = Mapper.Map<GoodsAddtionResponseViewModel>(temp);
                goodsAVM.ItemsSellPrice = (temp.Goods.SellPrice * temp.NumberOfItems);
                goodsAVM.ItemsBuyPrice = (temp.Goods.BuyPrice * temp.NumberOfItems);
                goodsAVM.Proofts = goodsAVM.ItemsSellPrice - goodsAVM.ItemsBuyPrice;
                goodsAVM.GoodsName = temp.Goods.Name;
                goodsAVM.Time = temp.Time.ToShortTimeString();
                goodsAVM.Date = temp.Time.ToShortDateString();
                tagerGoodsAddtionsViewModels.Add(goodsAVM);
            }
            var result = Mapper.Map<TagerGoodsAddtionsViewModel>(tager);
            result.TotalPayments = tager.GoodsAddtions?.Sum(g => (g.Goods.BuyPrice * g.NumberOfItems)) ?? 0;
            result.PaidPayments = tager.GoodsAddtionPayments?.Sum(g => g.Value) ?? 0;
            result.RemainingPayments = result.TotalPayments - result.PaidPayments;
            result.GoodsAddtions = tagerGoodsAddtionsViewModels;
            return Ok(result);
        }
        //completed(AbouNasser)
        // GET: api/Tagers/GoodsAddtionsPayments/5
        [Route("api/Tagers/GoodsAddtionsPayments/{id}")]
        [ResponseType(typeof(TagerGoodsAddtionsPaymentsViewModel))]
        public async Task<IHttpActionResult> GetTagerGoodsAddtionsPayments(int id)
        {
            var tager = await db.Tagers.SingleOrDefaultAsync(t => t.Id == id);
            if (tager == null)
            {
                return BadRequest("هذا التاجر غير موجود");
            }

            var tagerGoodsAddtionsPayments = tager.GoodsAddtionPayments.OrderByDescending(g => g.Time).ToList();
            var tagerGoodsAddtionsPaymentsViewModels = new List<GoodsAddtionPaymentViewModel>();
            foreach (var temp in tagerGoodsAddtionsPayments)
            {
                var goodsAPVM = new GoodsAddtionPaymentViewModel();
                goodsAPVM.Value = temp.Value;
                goodsAPVM.Date = temp.Time.ToShortDateString();
                goodsAPVM.Time = temp.Time.ToShortTimeString();
                goodsAPVM.SellerName = temp.Seller.Name;
                tagerGoodsAddtionsPaymentsViewModels.Add(goodsAPVM);
            }
            var result = Mapper.Map<TagerGoodsAddtionsPaymentsViewModel>(tager);
            result.TotalPayments = tager.GoodsAddtions?.Sum(g => (g.Goods.BuyPrice * g.NumberOfItems)) ?? 0;
            result.PaidPayments = tager.GoodsAddtionPayments?.Sum(g => g.Value) ?? 0;
            result.RemainingPayments = result.TotalPayments - result.PaidPayments;
            result.GoodsAddtionsPayments = tagerGoodsAddtionsPaymentsViewModels;
            return Ok(result);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagerExists(int id)
        {
            return db.Tagers.Count(e => e.Id == id) > 0;
        }
    }
}