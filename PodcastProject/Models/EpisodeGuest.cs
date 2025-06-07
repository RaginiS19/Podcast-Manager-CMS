namespace PodcastProject.Models
{
    public class EpisodeGuest
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }

}
