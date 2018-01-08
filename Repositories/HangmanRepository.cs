using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using hangman_c.Models;
using Dapper;
using MySql.Data.MySqlClient;
 
namespace hangman_c.Repsoitories
{
    public class HangmanRespository
    {
        private readonly IDbConnection _db;
        public HangmanRespository( IDbConnection db )
        {
            _db = db;
        }
        public IEnumerable

    }
}