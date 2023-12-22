using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PictureEditor.Models
{
    public class Transform
    {
        [Key]
        public int Id { get; set; }
        public int Size { get; set; }
        public int Crop { get; set; }
        public double Radius { get; set; }
        public bool Horizontal { get; set; }
        public bool Vertical { get; set; }
        [ForeignKey("Picture")]
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
