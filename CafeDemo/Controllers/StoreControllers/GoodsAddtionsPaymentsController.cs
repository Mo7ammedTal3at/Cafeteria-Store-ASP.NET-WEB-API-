using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CafeDemo.Models;
using CafeDemo.Models.StoreModels;
using CafeDemo.Models.ViewModels.Payment;
using CafeDemo.Models.ViewModels.StoreViewModels;

namespace CafeDemo.Controllers.StoreControllers
{
    public class GoodsAddtionsPaymentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //GET: api/GoodsAddtionsPayments/PaymentPage
        [HttpGet]
        [Route("api/GoodsAddtionsPayments/PaymentPage")]
        [ResponseType(typeof(List<DropDownItem>))]
        public IHttpActionResult GetPaymentPage()
        {
            var result = db.Tagers.Select(Mapper.Map<Tager, DropDownItem>).ToList();
            return Ok(result);
        }
        //POST: api/GoodsAddtionsPayments
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult PostGoodsAddtionPayment(PaymentAddtionViewModel pavm)
        {
            var gap = Mapper.Map<GoodsAddtionPayment>(pavm);
            gap.Time=DateTime.Now;
            db.GoodsAddtionPayments.Add(gap);
            db.SaveChanges();
            return Ok("تم");
        }
    }
}
