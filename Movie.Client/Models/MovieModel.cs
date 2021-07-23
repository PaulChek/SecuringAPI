using System;

namespace Movie.Client.Models {
    public class MovieModel {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseData { get; set; }

        public string Owner { get; set; }

    }
}
