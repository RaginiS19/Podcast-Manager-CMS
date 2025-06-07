namespace PodcastProject.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Status { get; set; } // "Draft", "Published", "Archived"

        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }

        public ICollection<EpisodeGuest> EpisodeGuests { get; set; }
    }

}
