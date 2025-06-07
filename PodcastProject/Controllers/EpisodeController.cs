using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PodcastProject.Models;

namespace PodcastManager.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly PodcastDbContext _context = new PodcastDbContext();

        // GET: /Episode/
        public IActionResult Index()
        {
            var list = new List<Episode>();
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Episode", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Episode
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    PublishDate = (System.DateTime)reader["PublishDate"],
                    PodcastId = (int)reader["PodcastId"]
                });
            }
            return View(list);
        }

        // GET: /Episode/Create
        public IActionResult Create() => View();

        // POST: /Episode/Create
        [HttpPost]
        public IActionResult Create(Episode episode)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand(
                "INSERT INTO Episode (Title, PublishDate, PodcastId) VALUES (@t, @p, @pid)",
                conn
            );
            cmd.Parameters.AddWithValue("@t", episode.Title);
            cmd.Parameters.AddWithValue("@p", episode.PublishDate);
            cmd.Parameters.AddWithValue("@pid", episode.PodcastId);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        // GET: /Episode/Edit/5
        public IActionResult Edit(int id)
        {
            Episode episode = null;
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Episode WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                episode = new Episode
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    PublishDate = (System.DateTime)reader["PublishDate"],
                    PodcastId = (int)reader["PodcastId"]
                };
            }
            return View(episode);
        }

        // POST: /Episode/Edit
        [HttpPost]
        public IActionResult Edit(Episode episode)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand(
                "UPDATE Episode SET Title=@t, PublishDate=@p, PodcastId=@pid WHERE Id=@id",
                conn
            );
            cmd.Parameters.AddWithValue("@t", episode.Title);
            cmd.Parameters.AddWithValue("@p", episode.PublishDate);
            cmd.Parameters.AddWithValue("@pid", episode.PodcastId);
            cmd.Parameters.AddWithValue("@id", episode.Id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        // GET: /Episode/Delete/5
        public IActionResult Delete(int id)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM Episode WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}
