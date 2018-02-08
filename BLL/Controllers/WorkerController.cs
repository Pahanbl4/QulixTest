using BLL.Models;
using DAL;
using DML;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLL.Controllers
{
    public class WorkerController : Controller
    {
        Mappers.Mapper Map = new Mappers.Mapper();
        private CompanyRepository companyRepository;
        private WorkerRepository workerRepository;

        public WorkerController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
            workerRepository = new WorkerRepository(connectionString);
            companyRepository = new CompanyRepository(connectionString);
        }

        public ActionResult GetAllWorker()
        {
           

            List<WorkerModel> workerModels = new List<WorkerModel>();

                foreach (var worker in workerRepository.GetAllWorkers())
                {
                    WorkerModel workerModel = Map.CopyDataToModel(worker);
                    workerModel.Company = Map.CopyDataToModel(companyRepository.GetCompany(workerModel.WorkerId));
                    workerModels.Add(workerModel);
                }
           
            return View(workerModels);
           
           
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            
                ViewBag.Companies = companyRepository.GetAllCompanies();
                return View();
            
            
        }

        // POST: Worker/Create
        [HttpPost]
        public ActionResult Create(WorkerModel worker)
        {
           
                if (ModelState.IsValid)
                {
                    workerRepository.AddWorker(Map.CopyDataToWorker(worker));

                    return RedirectToAction("GetAllWorker");
                }

                ViewBag.Companies = companyRepository.GetAllCompanies();
                return View();
           
        }

        // GET: Worker/Edit/5
        public ActionResult Edit(int id)
        {
           
                WorkerModel workerwModel = Map.CopyDataToModel(workerRepository.GetWorker(id));
                ViewBag.Companies = companyRepository.GetAllCompanies();
                return View(workerwModel);
           
        }


        // POST: Worker/Edit/5
        [HttpPost]
        public ActionResult Edit(WorkerModel workerModel)
        {
           
                if (ModelState.IsValid)
                {
                    Worker worker = Map.CopyDataToWorker(workerModel);
                    workerRepository.EditWorker(worker.WorkerId, worker);

                    return RedirectToAction("GetAllWorker");
                }

                ViewBag.Companies = companyRepository.GetAllCompanies();
                return View(workerModel);
           
        }

        // GET: Worker/Delete/5
        public ActionResult Delete(int id)
        {
           
                workerRepository.DeleteWorker(id);
                return RedirectToAction("GetAllWorker");

        }
           
    }
      
    
}
