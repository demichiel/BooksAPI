using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }
        public int NumberInSeries { get; set; }
        public bool Read { get; set; }
        public bool CurrentlyReading { get; set; }
        public int Rating { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string WikipediaLink { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageLink { get; set; }

        public Guid SerieId { get; set; }
    }
}
