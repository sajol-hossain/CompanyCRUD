using CompanyCRUD.Data;
using CompanyCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCRUD.Controllers
{
	public class CompanyEntryController : Controller
	{ 
	private readonly ApplicationDbContext _db;

	public CompanyEntryController(ApplicationDbContext db)
	{
		_db = db;
	}

	public IActionResult Index()
	{
		IEnumerable<CompanyEntry> objCompanyList = _db.CompanyEntries;
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
	public IActionResult Create(Company obj)
	{

		if (ModelState.IsValid)
		{
			_db.Company.Add(obj);

			_db.SaveChanges();
			TempData["success"] = "Company Entry created successfully";
			return RedirectToAction("Index");
		}
		return View(obj);
	}

	//GET
	public IActionResult Edit(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var companyFromDb = _db.CompanyEntries.FirstOrDefault(m => m.Id == id);

		if (companyFromDb == null)
		{
			return NotFound();
		}

		return View(companyFromDb);
	}

	//POST
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(CompanyEntry obj)
	{

		if (ModelState.IsValid)
		{
			_db.CompanyEntries.Update(obj);
			_db.SaveChanges();
			TempData["success"] = "Company Entry updated successfully";
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
		var companyFromDb = _db.CompanyEntries.FirstOrDefault(m => m.Id == id);


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
		var obj = _db.CompanyEntries.FirstOrDefault(m => m.Id == id);
		if (obj == null)
		{
			return NotFound();
		}

		_db.CompanyEntries.Remove(obj);
		_db.SaveChanges();
		TempData["success"] = "Company Entry deleted successfully";
		return RedirectToAction("Index");

	}
}
}
