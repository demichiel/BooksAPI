using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class Serie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(50)]
        public string Publisher { get; set; }
        public int NumberOfBooks { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string WikipediaLink { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageLink { get; set; }

        public IEnumerable<Book> Books { get; set; }

    }
}
