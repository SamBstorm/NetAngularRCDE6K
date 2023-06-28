using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.Entities
{
    public class Notice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        [Range(1,5)]
        public int Note { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public DateTime PublishDate { get; set; }
    }
}