using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.API.Models_Data {
    public class Movie {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReleaseData { get; set; }
        [MaxLength(50)]
        public string Owner { get; set; }

    }
}
