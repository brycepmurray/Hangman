using System.Data;
using hangman_c.Models;
using Dapper;
using MySql.Data.MySqlClient;


namespace hangman_c.Repsoitories
{
    public class UserRepository : DbContext
    {
        public UserRepository(IDbConnection db) : base(db)
        {

        }
        public UserReturnModel Register(RegisterUserModel creds)
        {
            //Encrypt the Password
            creds.Password = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            //Some SQL
            try
            {
                int id = _db.ExecuteScalar<int>(@"
              INSERT INTO users (Username, Email, Password)
              VALUES (@Username, @Email, @Password);
              SELECT LAST_INSERT_ID();
              ", creds);

                return new UserReturnModel()
                {
                    Id = id,
                    Username = creds.Username,
                    Email = creds.Email,
                };
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine("ERROR: " + e.Message);
            }
        }
        public UserReturnModel Login(LoginUserModel creds)
        {
            //More SQL
            User user = _db.QueryFirstOrDefault<User>(@"
            SELECT * FROM users WHERE email = @email
            ", creds);
            if (user != null)
            {
                var valid = BCrypt.Net.BCrypt.Verify(creds.Password, user.Password);
                if (valid)
                {
                    return new UserReturnModel()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email
                    };
                }
            }
            return null;
        }
    }
}