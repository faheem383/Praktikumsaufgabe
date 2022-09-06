using System.ComponentModel.DataAnnotations;

namespace Praktikumsaufgabe.Models
{
	public class Address
	{
		[Key]
		public int AdressID { get; set; }
		public int FileID { get; set; }
		public string ReferenceCode { get; set; }
		public string? LegalEntityForm { get; set; }
		public string Salutation { get; set; }
		public string? Title { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public string? Street { get; set; }
		public string? Housenumber { get; set; }
		public string? ZIP { get; set; }
		public string? City { get; set; }
		public Boolean IsCurrent { get; set; }
		public DateTime ImportDate { get; set; }
		//public IList<Models.Communication> Communications { get; set; }

		
	}
}
