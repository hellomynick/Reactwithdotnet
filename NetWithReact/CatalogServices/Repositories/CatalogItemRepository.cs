using CatalogServices.Model;
using Dapper;
using System.Data.SqlClient;

namespace CatalogServices.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly IConfiguration configuration;
      
        public CatalogItemRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(CatalogItem entity)
        {
            var sql = "Insert into CatalogItem (Name,Price,Description) VALUES (@Name,@Price,@Description)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql,entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM CatalogItem WHERE Id = @Id";
            using(var connection = new SqlConnection(configuration.GetConnectionString("SqlConnection")))

            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<CatalogItem> GetAllAsync()
        {
            var sql = "SELECT * FROM CatalogItem";
            using (var connection = new SqlConnection(configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CatalogItem>(sql);
                return result.FirstOrDefault();
            }
        }

        public async Task<CatalogItem> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM CatalogItem WHERE Id=@Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CatalogItem>(sql,new {Id = id});
                return result;
            }
        }

        public async Task<int> UpdateAsync(CatalogItem entity)
        {
            var sql = "UPDATE CatalogItem SET Name = @Name,Price = @Price,Description = @Description WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}


