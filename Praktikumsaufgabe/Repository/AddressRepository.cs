using Praktikumsaufgabe.Data;
using Praktikumsaufgabe.Models;
using Praktikumsaufgabe.ViewModels;

namespace Praktikumsaufgabe.Repository
{
	public class AddressRepository : IAddressRepository
	{
		EFContext db;
		public AddressRepository(EFContext _db)
		{
			db = _db;
		}
		/// <summary>
		/// Get 'AddressWithCommunication' view model by Reference Code
		/// </summary>
		/// <param name="code">Reference Code</param>
		/// <returns>AddressWithCommunication</returns>
		public AddressWithCommunication GetbyReferenceCode(string code)
		{
			AddressWithCommunication model = new AddressWithCommunication();
			
			if (!string.IsNullOrWhiteSpace(code))
			{
				Models.Address address = new Address();
				address = db.Addresses.FirstOrDefault(c => c.ReferenceCode == code && c.IsCurrent);
				if (address != null) {
					model.address = address;
					model.communications = db.Communications.Where(c => c.FileID == address.FileID).ToList();
				}
			}

			return model;
		}

		/// <summary>
		/// Get address by reference code
		/// </summary>
		/// <param name="code">Reference code</param>
		/// <returns>Address</returns>
		public Address GetAddressbyReferenceCode(string code)
		{
			Address model = new Address();

			if (!string.IsNullOrWhiteSpace(code))
			{
				
				model = db.Addresses.FirstOrDefault(c => c.ReferenceCode == code && c.IsCurrent);
				
			}

			return model;
		}
		/// <summary>
		/// Get List of communications by file id
		/// </summary>
		/// <param name="fileID">Address file id</param>
		/// <returns>IList<Communication></returns>
		public IList<Communication> AddressCommunications(int fileID)
		{
			List<Communication> model = new List<Communication>();

			if (fileID >0)
			{					
					model = db.Communications.Where(c => c.FileID == fileID).ToList();
				
			}

			return model;
		}

		/// <summary>
		/// Get reference code by file id
		/// </summary>
		/// <param name="fileID">Address file id</param>
		/// <returns>Reference Code</returns>
		public string GetReferenceCode(int fileID)
		{
			var address = db.Addresses.FirstOrDefault(a => a.FileID == fileID);
			if (address != null && !string.IsNullOrWhiteSpace(address.ReferenceCode)) { 
				return address.ReferenceCode;
			}
			return string.Empty;
		}

		/// <summary>
		/// Get address by file Id
		/// </summary>
		/// <param name="fileId">File Id</param>
		/// <returns>Address</returns>
		public Address GetAddressbyFileId(int fileId)
		{
			return db.Addresses.FirstOrDefault(c => c.FileID == fileId);
		}
	}
}
