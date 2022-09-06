using Microsoft.AspNetCore.Mvc;
using Praktikumsaufgabe.Data;
using Praktikumsaufgabe.Models;
using Praktikumsaufgabe.ViewModels;
using System.Diagnostics;
using System.Dynamic;

namespace Praktikumsaufgabe.Controllers
{
	public class HomeController : Controller
	{

		EFContext db;
		public HomeController(EFContext _db)
		{
			db = _db;
		}
		/// <summary>
		/// Search by Reference code id
		/// </summary>
		/// <param name="id">ReferenceCode</param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Index(string id)
		{
			Repository.AddressRepository addressRepo = new Repository.AddressRepository(db);
			ViewModels.AddressWithCommunication addressModel = addressRepo.GetbyReferenceCode(id);

			if (addressModel != null && addressModel.address != null && addressModel.communications != null)
				return View(addressModel);

			return View();
		}


		[HttpGet("Home/Index/{id}/{fid}")]
		public IActionResult Index(string id, string fid)
		{
			Repository.AddressRepository addressRepo = new Repository.AddressRepository(db);
			ViewModels.AddressWithCommunication addressModel = addressRepo.GetbyReferenceCode(id);

			if (addressModel != null && addressModel.address != null && addressModel.communications != null)
				return View(addressModel);
			return View();

		}
		public IActionResult Index()
		{
			return View();
		}


		/// <summary>
		/// Edit communication item by id
		/// </summary>
		/// <param name="id">Communication id</param>
		/// <returns></returns>
		public IActionResult Edit(int id)
		{
			CommunicationViewModel model = new CommunicationViewModel();

			if (id > 0)
			{
				Repository.CommunicationRepositry repositry = new Repository.CommunicationRepositry(db);
				model = repositry.GetCommunicationViewModel(id);
			}
			return View(model);
		}

		
		/// <summary>
		/// Communication save request method.
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Edit(CommunicationViewModel viewModel)
		{
			Repository.CommunicationRepositry repositry = new Repository.CommunicationRepositry(db);

			if (viewModel.ComType == 1 || viewModel.ComType == 2)
			{
				if (!Common.Functions.IsNumeric(viewModel.ComAddress))
				{
					ViewData["Message"] = "Phone or Fax number must be numeric";

					viewModel.ComStatusList = repositry.GetComStatuses();
					viewModel.ComTypeList = repositry.GetComTypes();
					return View(viewModel);
				}
			}

			if (viewModel != null && viewModel.CommID > 0 && viewModel.FileID > 0)
			{
				repositry.SaveCommunication(viewModel);
			}

			Repository.AddressRepository addressRepo = new Repository.AddressRepository(db);
			return RedirectToAction("Index", "Home", new { id = addressRepo.GetReferenceCode(viewModel.FileID), fid = "1" });

		}

		/// <summary>
		/// Create new communication item
		/// </summary>
		/// <param name="id">File Id</param>
		/// <returns></returns>
		public IActionResult Create(int id)
		{
			CommunicationViewModel model = new CommunicationViewModel();

			if (id > 0)
			{
				Repository.AddressRepository repositry = new Repository.AddressRepository(db);
				Repository.CommunicationRepositry comrepositry = new Repository.CommunicationRepositry(db);
				Address address = repositry.GetAddressbyFileId(id);
				if (address != null)
				{
					model.CommID = 0;
					model.FileID = id;
					model.ComStatusList = comrepositry.GetComStatuses();
					model.ComTypeList = comrepositry.GetComTypes();
					return View(model);
				}
			}

			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// Save method for Communication item
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Create(CommunicationViewModel viewModel)
		{
			Repository.CommunicationRepositry repositry = new Repository.CommunicationRepositry(db);

			if (viewModel.ComType == 1 || viewModel.ComType == 2 || viewModel.ComType == 3)
			{
				if (!Common.Functions.IsNumeric(viewModel.ComAddress))
				{
					ViewData["Message"] = "Phone or Fax number must be numeric";

					viewModel.ComStatusList = repositry.GetComStatuses();
					viewModel.ComTypeList = repositry.GetComTypes();
					return View(viewModel);
				}
			}

			if (viewModel != null && viewModel.FileID > 0)
			{
				repositry.SaveCommunication(viewModel);
			}

			Repository.AddressRepository addressRepo = new Repository.AddressRepository(db);
			return RedirectToAction("Index", "Home", new { id = addressRepo.GetReferenceCode(viewModel.FileID), fid = "1" });

		}

		/// <summary>
		/// Delete communication item by id. This function as anti forgery token
		/// </summary>
		/// <param name="id">Communication id</param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{

			CommunicationViewModel model = new CommunicationViewModel();
			int fid = 0;
			if (id > 0)
			{
				Repository.CommunicationRepositry repositry = new Repository.CommunicationRepositry(db);
				fid = repositry.DeleteCommunication(id);
			}

			Repository.AddressRepository addressRepo = new Repository.AddressRepository(db);
			return RedirectToAction("Index", "Home", new { id = addressRepo.GetReferenceCode(fid), fid = "1" });
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}