using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using AutoMapper;
using CafeDemo.DTOs;
using CafeDemo.Models;
using CafeDemo.Models.CafeModels;
using CafeDemo.Models.ViewModels.Person;
using CafeDemo.Models.ViewModels.Daraga;
using CafeDemo.Models.EnumClasses;
using CafeDemo.Models.ViewModels.Far3;

namespace CafeDemo.Controllers.Demo
{
    public class PeopleController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/People
        [ResponseType(typeof(List<PersonDetailsViewModel>))]
        public IHttpActionResult GetPeople()
        {
            List<Person> people = db.People.ToList();
            List<PersonDetailsViewModel> peopleDetailsViewModel = new List<PersonDetailsViewModel>();
            foreach (var temp in people)
            {
                var personViewModel = Mapper.Map<PersonDetailsViewModel>(temp);
                personViewModel.Ta2re4aMaxValue = temp.Ta2Re4A.MaxValue;
                personViewModel.Ta2re4aCurrentValue = temp.Ta2Re4A.CurrentValue;
                personViewModel.Ta2re4aRestValue = temp.Ta2Re4A.MaxValue-temp.Ta2Re4A.CurrentValue;
                personViewModel.Daraga = temp.Daraga.Name;
                personViewModel.Far3 = temp.Far3.Name;
                peopleDetailsViewModel.Add(personViewModel);
            }
            return Ok(peopleDetailsViewModel);
        }

        // GET: api/People/5
        [ResponseType(typeof(PersonDetailsViewModel))]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return BadRequest("هذا الشخص غير موجود");
            }
            var personViewModel = Mapper.Map<PersonDetailsViewModel>(person);
            personViewModel.Ta2re4aMaxValue = person.Ta2Re4A.MaxValue;
            personViewModel.Ta2re4aCurrentValue = person.Ta2Re4A.CurrentValue;
            personViewModel.Ta2re4aRestValue = person.Ta2Re4A.MaxValue - person.Ta2Re4A.CurrentValue;
            personViewModel.Daraga = person.Daraga.Name;
            personViewModel.Far3 = person.Far3.Name;
            return Ok(personViewModel);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson( int id, PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetErrorResponseMessage(ModelState));
            }
            Person personInDb = db.People.Include(p=>p.Ta2Re4A).SingleOrDefault(p => p.Id == id);
            if (personInDb == null)
            {
                return BadRequest("هذا الشخص غير موجود");
            } 
            Mapper.Map(personViewModel, personInDb);
            personInDb.Ta2Re4A.MaxValue = personViewModel.Ta2re4aMaxValue;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("تم تعديل الشخص بنجاح");
        }

        // POST: api/People
        [ResponseType(typeof(PersonViewModel))]
        public IHttpActionResult PostPerson(PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetErrorResponseMessage(ModelState));
            }
            Person person = Mapper.Map<Person>(personViewModel);
            person.AddtionTime = DateTime.Now;
            person.Ta2Re4A = new Ta2re4a
            {
                MaxValue = personViewModel.Ta2re4aMaxValue,
                AddtionTime = DateTime.Now
            };
            
            db.People.Add(person);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, string.Format("تم إضافة {0} / {1} بنجاح", person.Daraga, person.Name));
                
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            db.People.Remove(person);
            db.SaveChanges();
            return Ok("تم مسح الشخص بنجاح");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
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

        // our actions

        //Get: api/People/AddPersonPage
        [Route("api/People/AddPersonPage")]
        [ResponseType(typeof(AddPersonVewModel))]
        [HttpGet]
        public IHttpActionResult AddPersonPage()
        {
            var daraga = db.Daraga.ToList();
            var far3 = db.Far3.ToList();
            var addPersonViewModel = new AddPersonVewModel()
            {
                Daraga = daraga.Select(Mapper.Map<Daraga,DaragaViewModel>).ToList(),
                Far3 = far3.Select(Mapper.Map<Far3, Far3ViewModel>).ToList()
            };
            return Ok(addPersonViewModel);
        }

        //Get: api/People/Soldiers
        [Route("api/People/Soldiers")]
        [ResponseType(typeof(List<PersonDetailsViewModel>))]
        [HttpGet]
        public IHttpActionResult GetSoldiers()
        {
            var soldiers = db.People.Where(p => p.DaragaId == 3).ToList().Select(Mapper.Map<Person,PersonDetailsViewModel>);
            return Ok(soldiers);
        }
    }
}