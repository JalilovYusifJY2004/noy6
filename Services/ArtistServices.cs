using noy5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noy5.Services
{
    internal class ArtistServices
    {
        private Sql _database = new Sql();

        public void Create(Artists artist)
        {
            string cmd = $"INSERT INTO Artists VALUES('{artist.Name}','{artist.Surname}','{artist.Birthday}','{artist.Gender}')";

            int result = _database.ExecuteCommand(cmd);

            if (result > 0)
            {
                Console.WriteLine("Command successfully complated");
            }
            else
            {
                Console.WriteLine("Error occured");
            }
        }
        public List<Artists> GetAll()
        {
            string query = "SELECT * FROM Artists";

            DataTable table = _database.ExecuteQuery(query);

            List<Artists> artists = new List<Artists>();

            foreach (DataRow row in table.Rows)
            {
                Artists artist = new Artists
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString(),
                    Surname = row["surname"].ToString(),
                    Gender = row["gender"].ToString(),
                    Birthday = row["birthday"].ToString()

                };
                artists.Add(artist);
            }
            return artists;
        }
    }
}
