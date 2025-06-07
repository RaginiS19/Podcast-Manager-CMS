namespace PodcastProject.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public ICollection<EpisodeGuest> EpisodeGuests { get; set; }
    }

}
