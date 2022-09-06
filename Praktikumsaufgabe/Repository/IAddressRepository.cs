using Praktikumsaufgabe.Models;

namespace Praktikumsaufgabe.Repository
{
	public interface IAddressRepository
	{
		/// <summary>
		/// Get 'AddressWithCommunication' view model by Reference Code
		/// </summary>
		/// <param name="code">Reference Code</param>
		/// <returns>AddressWithCommunication</returns>
		public ViewModels.AddressWithCommunication GetbyReferenceCode(string code);

		/// <summary>
		/// Get address by reference code
		/// </summary>
		/// <param name="code">Reference code</param>
		/// <returns>Address</returns>
		public Address GetAddressbyReferenceCode(string code);

		/// <summary>
		/// Get address by file Id
		/// </summary>
		/// <param name="fileId">File Id</param>
		/// <returns>Address</returns>
		/// 
		public Address GetAddressbyFileId(int fileId);



		/// <summary>
		/// Get List of communications by file id
		/// </summary>
		/// <param name="fileID">Address file id</param>
		/// <returns>IList<Communication></returns>
		public IList<Communication> AddressCommunications(int fileID);

		/// <summary>
		/// Get reference code by file id
		/// </summary>
		/// <param name="fileID">Address file id</param>
		/// <returns>Reference Code</returns>
		public string GetReferenceCode(int fileID);
	}
}
