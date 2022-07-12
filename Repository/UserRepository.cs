using Dapper;
using mysqlAPI.Model;
using MySqlConnector;

namespace mysqlAPI.Repository;

public class UserRepository : IUserRepository
{

    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<User> GetAll()
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Query<User>("SELECT * FROM tb_usuarios");
        };
    }
    public User Get(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            var user = connection.QuerySingleOrDefault<User>($"SELECT * FROM tb_usuarios WHERE id = {id}");
            return user;
        };
    }
    public int InsertUser(User newUser)
    {
        var sql = "INSERT INTO tb_usuarios VALUES (@id, @Nome, @Idade)";

        User user = new User()
        {
            id = newUser.id,
            Nome = newUser.Nome,
            Idade = newUser.Idade,
        };

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Execute(sql, user);
        };
    }
    public int UpdateUser(int id, string name)
    {
        var sql = "UPDATE tb_usuarios SET Nome = @Name WHERE id = @id";

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Execute(sql, new{ id, name});
        };
    }
    public int DeleteUser(int id)
    {
        var sql = "DELETE FROM tb_usuarios WHERE id = @id";

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Execute(sql, new {id});
        };
    }
}