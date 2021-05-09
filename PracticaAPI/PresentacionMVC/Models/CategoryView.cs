using System.Drawing;

namespace PresentacionMVC.Models
{
    public class CategoryView
    {
        public byte[] Imagen { get; set; }
        public Image PictureCat { get; set; }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }

}