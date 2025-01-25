using BaristaCoffee.Dto.ContactDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _connection;

        public ContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            string sql = "insert into contact (Name,Email,Message) Values(@name,@email,@message)";

            DynamicParameters parameters = new();
            parameters.Add("@name", createContactDto.Name);
            parameters.Add("@email", createContactDto.Email);
            parameters.Add("@message", createContactDto.Message);

            await _connection.ExecuteAsync(sql, parameters);


        }
    }
}
