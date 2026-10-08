using System;
using System.ComponentModel.DataAnnotations;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required, MaxLength(150)]
        public string Venue { get; set; }

        [Required]
        public string Details { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
