namespace Praktikumsaufgabe.Common
{
	

	public static class Functions
	{
		public static bool IsNumeric(this string text)
		{
			double test;
			return double.TryParse(text, out test);
		}

		public static string GetComStatusIcons(int id)
		{
			switch (id)
			{
				case 1:
					return "Orange.ico";
				case 2:
					return "Green.ico";
				case 99:
					return "Red.ico";
				default: return "";
			}
		}
		public static string GetComTypeIcons(int id)
		{
			switch (id)
			{
				case 1:
					return "Telephone.ico";
				case 2:
					return "Fax.ico";
				case 3:
					return "MobilePhone.ico";
				case 4:
				case 6:
					return "Internet.ico";
				default: return "";
			}
		}
	}
}
