using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        /// <summary>
        /// The official title of the video game
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// The sales price of the game
        /// </summary>
        [Range(0, 1000)]
        public double Price { get; set; }

        // ToDo: Add rating
    }
}
