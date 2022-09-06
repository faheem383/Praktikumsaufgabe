using Microsoft.AspNetCore.Mvc.Rendering;
using Praktikumsaufgabe.Models;
using Praktikumsaufgabe.ViewModels;

namespace Praktikumsaufgabe.Repository
{
	public interface ICommunicationRepositry
	{
		/// <summary>
		/// Get list of commmunication statuses
		/// </summary>
		/// <returns></returns>
		public IEnumerable<SelectListItem> GetComStatuses();


		/// <summary>
		/// Get list of communication Types
		/// </summary>
		/// <returns></returns>
		public IEnumerable<SelectListItem> GetComTypes();

		/// <summary>
		/// Get communication object by id 
		/// </summary>
		/// <param name="id">commid</param>
		/// <returns>Communication</returns>
		public Communication GetCommunication(int id);

		/// <summary>
		/// Get communication view model by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>CommunicationViewModel</returns>
		public CommunicationViewModel GetCommunicationViewModel(int id);

		/// <summary>
		/// Save communication
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		public bool SaveCommunication(CommunicationViewModel viewModel);

		/// <summary>
		/// Delete a communication object by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int DeleteCommunication(int id);
	}
}
