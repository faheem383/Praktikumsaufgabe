namespace Praktikumsaufgabe.ViewModels
{
	public class AddressWithCommunication
	{
		public Models.Address address { get; set; }
		public List<Models.Communication> communications { get; set; }
		public string message { get; set; }

	}
}
