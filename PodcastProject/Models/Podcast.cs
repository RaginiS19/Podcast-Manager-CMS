namespace PodcastProject.Models
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverArtUrl { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }

}
