using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WPSPApi.Models;


namespace WPSPApi.DataProvider
{
    public class PatrollerDataProvider : IPatrollerDataProvider
    {
        //private readonly string connectionString = @"Server=xxxxx\WORKTEST;Database=WPSPOrig;Trusted_Connection=True;";
        private readonly string connectionString = @"Data Source=xxxxx\WORKTEST;Initial Catalog=WPSPOrig;Integrated Security=False;User Id=xxxx;Password=xxxxx;MultipleActiveResultSets=True";
       
        //private SqlConnection sqlConnection;

        public async Task AddPatroller(Patroller p)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                
                dynamicParameters.Add("@skipatrolNumber", p.SkipatrolNumber);
                dynamicParameters.Add("@lastName", p.LastName);
                dynamicParameters.Add("@firstName", p.FirstName);
                dynamicParameters.Add("@patrolKey", p.PatrolKey);
                dynamicParameters.Add("@patrolType", p.PatrolType);
                dynamicParameters.Add("@priPhId", p.PriPhId);
                dynamicParameters.Add("@eMail", p.EMail);
                dynamicParameters.Add("@streetAddress", p.StreetAddress);
                dynamicParameters.Add("@city", p.City);
                dynamicParameters.Add("@state", p.State);
                dynamicParameters.Add("@zip", p.Zip);
                dynamicParameters.Add("@partner", p.Partner);
                dynamicParameters.Add("@family", p.Family);
                dynamicParameters.Add("@joinYear", p.JoinYear);
                dynamicParameters.Add("@pictureLink", p.PictureLink);

                await sqlConnection.ExecuteAsync(
                    "spAddUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletePatroller(int skiPatrolNumber)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@skiPatrolNumber", skiPatrolNumber);
                await sqlConnection.ExecuteAsync(
                    "spDeletePatroller",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Patroller> GetPatroller(int skiPatrolNumber)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@skiPatrolNumber", skiPatrolNumber);

                return await sqlConnection.QuerySingleOrDefaultAsync<Patroller>(
                    "spGetPatroller",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Patroller>> GetPatrollers()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                return await sqlConnection.QueryAsync<Patroller>(
                        "spGetPatrollers",
                        null,
                        commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdatePatroller(Patroller p)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();


                dynamicParameters.Add("@skipatrolNumber", p.SkipatrolNumber);
                dynamicParameters.Add("@lastName", p.LastName);
                dynamicParameters.Add("@firstName", p.FirstName);
                dynamicParameters.Add("@patrolKey", p.PatrolKey);
                dynamicParameters.Add("@patrolType", p.PatrolType);
                dynamicParameters.Add("@priPhId", p.PriPhId);
                dynamicParameters.Add("@eMail", p.EMail);
                dynamicParameters.Add("@streetAddress", p.StreetAddress);
                dynamicParameters.Add("@city", p.City);
                dynamicParameters.Add("@state", p.State);
                dynamicParameters.Add("@zip", p.Zip);
                dynamicParameters.Add("@partner", p.Partner);
                dynamicParameters.Add("@family", p.Family);
                dynamicParameters.Add("@joinYear", p.JoinYear);
                dynamicParameters.Add("@pictureLink", p.PictureLink);

                await sqlConnection.ExecuteAsync(
                    "spUpdatePatroller",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
