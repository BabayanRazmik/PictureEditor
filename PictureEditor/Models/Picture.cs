using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PictureEditor.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Effect")]
        public int? EffectId { get; set; }
        public Effect Effect { get; set; }
        [ForeignKey("Transform")]
        public int TransformId { get; set; }
        public Transform Transform { get; set; }
    }
}
