using Microsoft.AspNetCore.Mvc.Rendering;
using Praktikumsaufgabe.Data;
using Praktikumsaufgabe.Models;
using Praktikumsaufgabe.ViewModels;

namespace Praktikumsaufgabe.Repository
{
	public class CommunicationRepositry : ICommunicationRepositry
	{
		EFContext db;
		public CommunicationRepositry(EFContext _db)
		{
			db = _db;
		}

		public Communication GetCommunication(int id)
		{
			return db.Communications.FirstOrDefault(c => c.CommID == id);
		}

		public CommunicationViewModel GetCommunicationViewModel(int id)
		{
			CommunicationViewModel viewModel = new CommunicationViewModel();
			Communication model = db.Communications.FirstOrDefault(c => c.CommID == id);
			if (model != null)
			{


				viewModel.CommID = model.CommID;
				viewModel.FileID = model.FileID;
				viewModel.ComStatus = model.ComStatus; ;
				viewModel.ComType = model.ComType;
				viewModel.ComAddress = model.ComAddress;
				viewModel.Memo = model.Memo;
				viewModel.ImportDate = model.ImportDate;

			}

			viewModel.ComStatusList = GetComStatuses();
			viewModel.ComTypeList = GetComTypes();
			return viewModel;
		}

		public IEnumerable<SelectListItem> GetComStatuses()
		{

			var status = db.ComStatus
			   .Select(x =>
					   new SelectListItem
					   {
						   Value = x.Id.ToString(),
						   Text = x.Name
					   });

			return new SelectList(status, "Value", "Text");
		}

		public IEnumerable<SelectListItem> GetComTypes()
		{
			var status = db.ComType
			   .Select(x =>
					   new SelectListItem
					   {
						   Value = x.Id.ToString(),
						   Text = x.Name
					   });

			return new SelectList(status, "Value", "Text");
		}

		
		
		public int DeleteCommunication(int id)
		{
			int fid = 0; 
			if (id > 0)
			{

				Communication model = db.Communications.FirstOrDefault(c => c.CommID == id);
				if (model != null)
				{

					fid = model.FileID;
					db.Remove(model);
					db.SaveChanges();
				}
			}

			return fid;
		}

		public bool SaveCommunication(CommunicationViewModel viewModel)
		{
			if (viewModel != null)
			{

				Communication model = new Communication();
				if (viewModel.CommID > 0)
				{
					model = db.Communications.FirstOrDefault(c => c.CommID == viewModel.CommID);
				}
				model.FileID = viewModel.FileID;
				model.ComStatus = viewModel.ComStatus; ;
				model.ComType = viewModel.ComType;
				model.ComAddress = viewModel.ComAddress;
				model.Memo = viewModel.Memo;

				if (viewModel.CommID == 0)
				{
					model.ImportDate = DateTime.Now;
					db.Communications.Add(model);
				}
				db.SaveChanges();
				return true;
			}

			return false;
		}

		
	}
}
