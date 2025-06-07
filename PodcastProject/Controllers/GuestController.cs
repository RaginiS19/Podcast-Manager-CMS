using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PodcastProject.Models;

namespace PodcastManager.Controllers
{
    public class GuestController : Controller
    {
        private readonly PodcastDbContext _context = new PodcastDbContext();

        // GET: /Guest/
        public IActionResult Index()
        {
            var list = new List<Guest>();
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Guest", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Guest
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Bio = reader["Bio"].ToString()
                });
            }
            return View(list);
        }

        // GET: /Guest/Create
        public IActionResult Create() => View();

        // POST: /Guest/Create
        [HttpPost]
        public IActionResult Create(Guest guest)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO Guest (Name, Bio) VALUES (@n, @b)", conn);
            cmd.Parameters.AddWithValue("@n", guest.Name);
            cmd.Parameters.AddWithValue("@b", guest.Bio);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        // GET: /Guest/Edit/5
        public IActionResult Edit(int id)
        {
            Guest guest = null;
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Guest WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                guest = new Guest
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Bio = reader["Bio"].ToString()
                };
            }
            return View(guest);
        }

        // POST: /Guest/Edit
        [HttpPost]
        public IActionResult Edit(Guest guest)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("UPDATE Guest SET Name=@n, Bio=@b WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@n", guest.Name);
            cmd.Parameters.AddWithValue("@b", guest.Bio);
            cmd.Parameters.AddWithValue("@id", guest.Id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        // GET: /Guest/Delete/5
        public IActionResult Delete(int id)
        {
            using var conn = _context.AccessDatabase();
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM Guest WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}
