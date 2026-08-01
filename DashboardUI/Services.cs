using System;
using System.Data;
using Microsoft.Data.SqlClient; // NuGet: Microsoft.Data.SqlClient
using System.Threading.Tasks;

namespace DashboardUI
{
    public class CreateAccountModel
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Phone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public double Weight { get; set; } = 70;
        public double Height { get; set; } = 170;
    }

    public class CreateNewUser
    {
        private readonly string _connectionString;

        public CreateNewUser(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateAccountAsync(CreateAccountModel model)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.sp_Users", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@FullName", model.FullName);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Phone", (object?)model.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", (object?)model.Gender ?? DBNull.Value);
            command.Parameters.AddWithValue("@Weight", model.Weight);
            command.Parameters.AddWithValue("@Height", model.Height);

            var outputIdParam = new SqlParameter("@NewAccountId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputIdParam);

            await connection.OpenAsync().ConfigureAwait(false);

            try
            {
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }

            return outputIdParam.Value is int id ? id : throw new InvalidOperationException("Account creation failed.");
        }
    }
}
