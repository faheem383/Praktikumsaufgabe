using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Praktikumsaufgabe.Models
{
	public class Communication
	{
		[Key]
		public int CommID { get; set; }
		public int FileID { get; set; }
		public int ComStatus { get; set; }
	
		public int ComType { get; set; }
		public string ComAddress { get; set; }
		public string? Memo { get; set; }
		public DateTime ImportDate { get; set; }


	}

}
