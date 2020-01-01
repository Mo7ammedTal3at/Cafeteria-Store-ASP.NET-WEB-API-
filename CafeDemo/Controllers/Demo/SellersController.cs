using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CafeDemo.DTOs;
using CafeDemo.Models;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.Controllers.Demo
{
    public class SellersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Sellers
        public IEnumerable<SellerDto> GetSellers()
        {
            return db.Sellers.ToList().Select(Mapper.Map<Seller,SellerDto>);
        }

        // GET: api/Sellers/5
        [ResponseType(typeof(SellerDto))]
        public IHttpActionResult GetSeller(int id)
        {
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SellerDto>(seller));
        }

        // PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeller( SellerDto sellerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var sellerInDb = db.Sellers.SingleOrDefault(s => s.Id == sellerDto.Id);
            if (sellerInDb == null)
            {
                return NotFound();
            }
            sellerDto.Id = sellerInDb.Id; 
            Mapper.Map(sellerDto, sellerInDb);
            //db.Entry(sellerDto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(sellerDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sellers
        [ResponseType(typeof(SellerDto))]
        public IHttpActionResult PostSeller(SellerDto sellerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var seller = Mapper.Map<Seller>(sellerDto);
            db.Sellers.Add(seller);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seller.Id }, Mapper.Map<SellerDto>(seller));
        }

        // DELETE: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public IHttpActionResult DeleteSeller(int id)
        {
            Seller seller = db.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }

            db.Sellers.Remove(seller);
            db.SaveChanges();

            return Ok(Mapper.Map<SellerDto>(seller));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellerExists(int id)
        {
            return db.Sellers.Count(e => e.Id == id) > 0;
        }
    }
}