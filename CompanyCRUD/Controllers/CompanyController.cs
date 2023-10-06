using CompanyCRUD.Data;
using CompanyCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyCRUD.Controllers
{
	public class CompanyController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CompanyController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Company> objCompanyList = _db.Company;
			return View(objCompanyList);
		}

		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Name,Address,CompanyEntries")]Company obj)
		{



			if (ModelState.IsValid)
			{
				_db.Company.Add(obj);
				
				_db.SaveChanges();
				TempData["success"] = "Company created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddCompanyEntry([Bind("CompanyEntries")] Company company)
		{
			company.CompanyEntries.Add(new CompanyEntry());
			return PartialView("CompanyEntries", company);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditCompanyEntry([Bind("CompanyEntries")] Company company)
		{
			
			return PartialView("CompanyEntries", company);
		}

		//GET
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var companyFromDb = _db.Company.Include(x => x.CompanyEntries).FirstOrDefault(m => m.ID == id);

			if (companyFromDb == null)
			{
				return NotFound();
			}

			return View(companyFromDb);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Company obj)
		{
			
			if (ModelState.IsValid)
			{
				_db.Company.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Company updated successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var companyFromDb = _db.Company.Include(x=>x.CompanyEntries).FirstOrDefault(m => m.ID == id);
			

			if (companyFromDb == null)
			{
				return NotFound();
			}

			return View(companyFromDb);
		}


		public IActionResult Details(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var companyFromDb = _db.Company.Include(x => x.CompanyEntries).FirstOrDefault(m => m.ID == id);


			if (companyFromDb == null)
			{
				return NotFound();
			}

			return View(companyFromDb);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Company.Include(x => x.CompanyEntries).FirstOrDefault(m => m.ID == id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Company.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Company deleted successfully";
			return RedirectToAction("Index");

		}
	}
}
