using System;
using System.ComponentModel.DataAnnotations;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas
{
    public class EventModel
    {
        [Required(ErrorMessage = "The Title field is required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "The Date field is required")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The Time field is required")]
        public TimeSpan Time { get; set; } = TimeSpan.Zero;

        [Required(ErrorMessage = "The Venue field is required")]
        public string Venue { get; set; } = "";

        [Required(ErrorMessage = "The Details field is required")]
        public string Details { get; set; } = "";
    }
}
