using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using AutoMapper;
using CafeDemo.Models;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CafeDemo.Controllers.StoreControllers
{
    public class GoodsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //Get all product 
        // GET: api/Goods
        [Route ("api/Goods")]
        [HttpGet]
        [ResponseType(typeof(List<GoodsViewModel>))]
        public IHttpActionResult GetAllGoods()
        {
            var goods = db.Goods.OrderByDescending(g=>g.AddtionTime).ToList();                                                //Get All Goods From DataBase , in List
            var goodsViewModel = new List<GoodsViewModel>();                              //Create New List from GoodsViewModel
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
        //Get product with Id
        // GET: api/Goods/5
        [Route ("api/Goods/{id}")]
        [HttpGet]
        [ResponseType(typeof(GoodsViewModel))]
        public IHttpActionResult GetGood(int id)
        {
            var good = db.Goods.Find(id);
            if (good == null)
            {
                return NotFound();
            }
            var goodsViewModel = Mapper.Map<GoodsViewModel>(good);
            goodsViewModel.AddtionDate = good.AddtionTime.ToShortDateString();
            goodsViewModel.NumberOfBoxes = (int) (good.TotalItemsCount / good.NumberOfItemsInBox);
            goodsViewModel.NumberOfRestItems = (good.TotalItemsCount % good.NumberOfItemsInBox);
            return Ok(goodsViewModel);
        }
        [HttpGet]
        [ResponseType(typeof(GoodsEditViewModel))]
        public IHttpActionResult GetEditPage(int id)
        {
            var goodInDb = db.Goods.FirstOrDefault(g => g.Id == id);
            if (goodInDb == null)
            {
                return BadRequest("هذا المنتج غير موجود");
            }
            var goodsEVm = Mapper.Map<GoodsEditViewModel>(goodInDb);
            return Ok(goodsEVm);
        }
        //PUT: api/Goods/5
        [ResponseType(typeof(string))]
        [HttpPut]
        [Route("api/Goods/{id}")]
        public IHttpActionResult PutGoods([FromUri]int id, [FromBody]GoodsEditViewModel goodsEVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetErrorResponseMessage(ModelState));
            }
            var goodInDb = db.Goods.FirstOrDefault(g => g.Id == id);
            if(goodInDb==null)
            {
                return BadRequest("هذا المنتج غير موجود");
            }
            Mapper.Map(goodsEVm, goodInDb);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("هذا الاسم موجود من قبل");
            }
            return Ok("تم تعديل المنتج بنجاح");
        }

        // POST: api/Goods
        [Route("api/Goods")]
        [HttpPost]
        [ResponseType(typeof(string))]

        public IHttpActionResult PostGoods(GoodsPostViewModel goodsPostViewModel)
        {
            if (goodsPostViewModel == null)
            {
                return BadRequest("لابد من ادخال بيانات المنتج");
            }
            goodsPostViewModel.Name = goodsPostViewModel.Name.Trim();
            var good = Mapper.Map<Goods>(goodsPostViewModel);
            good.TotalItemsCount = goodsPostViewModel.NumberOfBoxes * goodsPostViewModel.NumberOfItemsInBox;
            good.AddtionTime=DateTime.Now;
            if (goodsPostViewModel.NumberOfBoxes <= goodsPostViewModel.AlertLimit)
            {
                good.IsLimited = true;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(GetErrorResponseMessage(ModelState));
            }
            db.Goods.Add(good);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException dbUpdateException)
            {
                return BadRequest("هذا المنتج موجود بالفعل");
            }
            var goodsAddtion = new GoodsAddtion
            {
                SellerId = goodsPostViewModel.SellerId,
                GoodsId = good.Id,
                ItemsBuyPrice = good.BuyPrice*good.TotalItemsCount,
                ItemsSellPrice = good.SellPrice*good.TotalItemsCount,
                NumberOfItems = good.TotalItemsCount,
                PreviousProductsCount = 0,
                TagerId = 1,
                Time = DateTime.Now,
                UpdatedProductsCount = good.TotalItemsCount
            };
            db.GoodsAddtions.Add(goodsAddtion);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { controller= "Goods", id = good.Id }, "تم إضافة \"" + good.Name + "\" بنجاح");
        }


        //DELETE: api/Goods/5
        //[ResponseType(typeof(string))]
        //public IHttpActionResult DeleteGoods(int id)
        //{
        //    Goods goods = db.Goods.Find(id);
        //    if (goods == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Goods.Remove(goods);
        //    db.SaveChanges();

        //    return Ok("تم حذف المنتج بنجاح");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GoodsExists(int id)
        {
            return db.Goods.Count(e => e.Id == id) > 0;
        }
        private string GetErrorResponseMessage(ModelStateDictionary modelState)
        {
            string responseMessage = "";
            foreach (var temp in modelState)
            {
                foreach (var error in temp.Value.Errors)
                {
                    responseMessage += error.ErrorMessage + "\n\r";
                }
            }
            return responseMessage;
        }
    }
}