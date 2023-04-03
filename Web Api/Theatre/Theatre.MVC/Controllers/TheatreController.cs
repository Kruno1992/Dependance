using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Theatre.Service.Common;
using Theatre.Common;
using Theatre.MVC.Models;
using Theatre.Model;
using System.Web.UI.WebControls;

namespace Theatre.MVC.Controllers
{
    public class PersonnelController : Controller
    {
        protected IPersonnelService PersonnelService { get; set; }

        public PersonnelController(IPersonnelService personnelService)
        {
            PersonnelService = personnelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering)
        {

            var workers = await PersonnelService.GetAllPersonnelAsync(paging, sorting, filtering);
            List<PersonnelView> listView = new List<PersonnelView>();
            if (workers != null)
            {
                foreach (var worker in workers)
                {
                    PersonnelView view = new PersonnelView();
                    view.Id = worker.Id;
                    view.PersonnelName = worker.PersonnelName;
                    view.Surname = worker.Surname;
                    view.HoursOfWork = worker.HoursOfWork;
                    listView.Add(view);
                }
                return View(listView);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetPersonnelAsync(Guid id)
        {
            var personnel = await PersonnelService.GetPersonnelAsync(id);
            PersonnelView view = new PersonnelView();
            if (personnel != null)
            {
                return View(view);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddPersonnelAsync(PersonnelView personnel)
        {
            Personnel person = new Personnel();
            person.Id = personnel.Id;
            person.PersonnelName = personnel.PersonnelName;
            person.Surname = personnel.Surname;
            person.Position = personnel.Position;
            person.HoursOfWork = personnel.HoursOfWork;

            bool newPersonnel = await PersonnelService.AddPersonnelAsync(person);
            if (newPersonnel != true)
            {
                return View(newPersonnel);
            }

            else
            {
                return View();
            }

            //        }
            //        [HttpPut]
            //        public async Task<HttpResponseMessage> EditPersonnelAsync(Guid id, PersonnelView personnel)
            //        {
            //            Personnel putPersonnel = new Personnel();
            //            putPersonnel.PersonnelName = putPersonnel.PersonnelName;
            //            putPersonnel.Surname = putPersonnel.Surname;
            //            putPersonnel.Position = putPersonnel.Position;
            //            putPersonnel.HoursOfWork = putPersonnel.HoursOfWork;

            //            bool putSucces = await PersonnelService.EditPersonnelAsync(id, putPersonnel);
            //            if (putSucces != false)

            //            {
            //                return View();
            //            }
            //            else

            //            {
            //                return View();
            //            }
            //        }
            //        [HttpDelete]
            //        public async Task<HttpResponseMessage> DeletePersonnelAsync(Guid id)
            //        {
            //            bool personnel = await PersonnelService.DeletePersonnelAsync(id);
            //            if (personnel != false)
            //            {
            //                return View();
            //            }
            //            else
            //            {
            //                return View();
            //            }
            //        }
            //}
        }
    }
}