using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInWoods.Models;
 
namespace LostInWoods.Factory
{
    public class TrailFactory
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        //USERFACTORY CLASS DEFINITION
        public void Add(Trail trail)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (name, description, elevation, length, longitude, latitude) VALUES (@Name, @Description, @Elevation, @Length, @Longitude, @Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

    }

}