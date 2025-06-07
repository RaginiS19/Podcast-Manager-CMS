using MySql.Data.MySqlClient;

namespace PodcastProject.Models
{
    /// <summary>
    /// Database context class for accessing the Podcast CMS database using MySQL.
    /// </summary>
    public class PodcastDbContext
    {
        // MySQL credentials
        private static string User { get { return "ragini"; } }       // Replace with your MySQL username
        private static string Password { get { return "password"; } } // Replace with your password
        private static string Database { get { return "podcast"; } } // Your MySQL database name
        private static string Server { get { return "localhost"; } }  // Host (XAMPP MySQL)
        private static string Port { get { return "3306"; } }         // Default MySQL port

        // Connection string
        protected static string ConnectionString
        {
            get
            {
                return "server=" + Server
                    + ";user=" + User
                    + ";database=" + Database
                    + ";port=" + Port
                    + ";password=" + Password
                    + ";convert zero datetime=True";
            }
        }

        /// <summary>
        /// Returns a new MySqlConnection to the Podcast CMS database.
        /// </summary>
        /// <returns>A MySqlConnection object for database operations.</returns>
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
