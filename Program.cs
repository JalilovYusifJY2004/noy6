using System.Data.SqlClient;
using System.Data;
using noy5.Models;
using noy5.Services;

namespace noy5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicServices musicServices = new MusicServices();
            Music musics = new Music
            {
                Name = "Daglar"
            };
            musicServices.Create();

            List<Music> list = conn.GetAll();
            foreach (Music m in list)
            {
                Console.WriteLine($"Id: {musics.Id}, Name: {musics.Name}");
            }


            ArtistServices artistServices = new ArtistServices();

            Artists artists = new Artists
            {
                Name ="Kenan",
                Surname="Pashayev",
                Birthday="may",
                Gender="kisi"
            };
            artistServices.Create();

            List<Artists> artists1 = artistServices.GetAll();

            foreach (Artists item in artists1)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Surname: {item.Surname} Birthday: {item.Birthday} Gender: {item.Gender}");
            }
        }
    }
   
}