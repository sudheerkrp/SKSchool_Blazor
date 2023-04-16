using Microsoft.AspNetCore.Components;
using SKSchool_Blazor.Data;
using System.Runtime.CompilerServices;

namespace SKSchool_Blazor.Pages
{
	public partial class Counter
	{
		[Inject]
		private IDatabaseConnection? DatabaseConnection { get; set; }

		public int currentCount = 0;

		public void IncrementCount()
		{
			currentCount++;
		}

		public string GetConnectionString()
		{
			if (DatabaseConnection != null)
				return DatabaseConnection.GetConnection().ToString();
			else
				return "Error!";
		}
	}
}
