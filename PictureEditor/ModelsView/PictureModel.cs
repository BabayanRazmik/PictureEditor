using PictureEditor.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PictureEditor.ModelsView
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EffectId { get; set; }
        public int Size { get; set; }
        public int Crop { get; set; }
        public double Radius { get; set; }
        public bool Horizontal { get; set; }
        public bool Vertical { get; set; }
    }
}
