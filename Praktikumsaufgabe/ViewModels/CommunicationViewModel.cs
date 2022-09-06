using Microsoft.AspNetCore.Mvc.Rendering;

namespace Praktikumsaufgabe.ViewModels
{
    public class CommunicationViewModel
    {
		public int CommID { get; set; }
		public int FileID { get; set; }
		public int ComStatus { get; set; }

		public int ComType { get; set; }
		public string ComAddress { get; set; }
		public string? Memo { get; set; }
		public DateTime ImportDate { get; set; }

		public IEnumerable<SelectListItem> ComStatusList { get; set; }
		public IEnumerable<SelectListItem> ComTypeList { get; set; }
		public string ReferenceCode {get; set; }

	}
}
