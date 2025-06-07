using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PodcastProject.Models;

namespace PodcastManager.Controllers
{
    public class PodcastController : Controller
    {
        private readonly PodcastDbContext _context = new PodcastDbContext();

        public IActionResult Index()
        {
            var list = new List<PodcastProject.Models.Podcast>();
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Podcast", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PodcastProject.Models.Podcast
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    CoverArtUrl = reader["CoverArtUrl"].ToString()
                });
            }
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(PodcastProject.Models.Podcast podcast)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO Podcast (Title, Description, CoverArtUrl) VALUES (@t, @d, @c)", conn);
            cmd.Parameters.AddWithValue("@t", podcast.Title);
            cmd.Parameters.AddWithValue("@d", podcast.Description);
            cmd.Parameters.AddWithValue("@c", podcast.CoverArtUrl);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            PodcastProject.Models.Podcast podcast = null;
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Podcast WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                podcast = new PodcastProject.Models.Podcast
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    CoverArtUrl = reader["CoverArtUrl"].ToString()
                };
            }
            return View(podcast);
        }

        [HttpPost]
        public IActionResult Edit(PodcastProject.Models.Podcast podcast)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("UPDATE Podcast SET Title=@t, Description=@d, CoverArtUrl=@c WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@t", podcast.Title);
            cmd.Parameters.AddWithValue("@d", podcast.Description);
            cmd.Parameters.AddWithValue("@c", podcast.CoverArtUrl);
            cmd.Parameters.AddWithValue("@id", podcast.Id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM Podcast WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}
