using Microsoft.AspNetCore.Components;
using SKSchool_Blazor.DataClass;
using System.Data.SqlClient;
using Dapper;

namespace SKSchool_Blazor.Data
{
	public class BranchesInfoService
	{
		public List<BranchesInfo> branchesList = new();

		public async Task<List<BranchesInfo>> GetBranchesListAsync(IDatabaseConnection databaseConnection)
		{
			try
			{
				if (databaseConnection != null)
				{
					using SqlConnection connection = databaseConnection.GetConnection();
					string sql = @"SELECT code, name, update_on AS updatedOn FROM Branches WHERE active_bit = 1";
					branchesList = new(await connection.QueryAsync<BranchesInfo>(sql));
				}
				else
					Console.WriteLine("Connection Failed!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception : " + ex.ToString());
			}
			return branchesList;
		}
	}
}
