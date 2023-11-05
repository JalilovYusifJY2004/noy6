using noy5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noy5.Services
{
    internal class MusicServices
    {
        private Sql _database = new Sql();

        public void Create(Music music)
        {
            string cmd = $"INSERT INTO Musics VALUES('{music.Name}')";

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
        public List<Music> GetAll()
        {
            string query = "SELECT * FROM Musics";

            DataTable table = _database.ExecuteQuery(query);

            List<Music> musics = new List<Music>();

            foreach (DataRow row in table.Rows)
            {
                Music music = new Music
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString()
                };
                musics.Add(music);
            }
            return musics;
        }
    }
}
