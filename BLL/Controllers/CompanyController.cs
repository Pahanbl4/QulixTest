using BLL.Models;
using DAL;
using DML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BLL.Controllers
{
    public class CompanyController : Controller
    {
        Mappers.Mapper Map = new Mappers.Mapper();

        private CompanyRepository companyRepository;

        public CompanyController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
            companyRepository = new CompanyRepository(connectionString);
        }

        public ActionResult GetAllCompany(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
        
            List<CompanyModel> companyModels = new List<CompanyModel>();

                foreach (var company in companyRepository.GetAllCompanies())
                {
                    companyModels.Add(Map.CopyDataToModel(company));
                }
            var employees = companyModels.AsQueryable();

            employees = employees.Where(x=>x.Name==search || search==null);

            if(sortBy == "Name desc")
            {
                employees = employees.OrderBy(x => x.Name);
            }
            else
            { employees = employees.OrderBy(x => x.CompanySize); }
            return View(employees.ToPagedList(page ?? 1, 3));
        }


        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CompanyModel comp)
        {
            if (ModelState.IsValid)
            {
               
                    companyRepository.AddCompany(Map.CopyDataToCompany(comp));

                    return RedirectToAction("GetAllCompany");
               
            }

            return View();
        }

      
        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {        
                CompanyModel companyModel = Map.CopyDataToModel(companyRepository.GetCompany(id));

                return View(companyModel);
        }


        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
               
                    Company company = Map.CopyDataToCompany(companyModel);
                    companyRepository.EditCompany(company.CompanyId, company);

                    return RedirectToAction("GetAllCompany");
                
               
            }

            return View(companyModel);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {

                companyRepository.DeleteCompany(id);
                return RedirectToAction("GetAllCompany");

        }
        
    }
}
