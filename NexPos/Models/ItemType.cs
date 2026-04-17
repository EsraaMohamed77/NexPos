using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexPos.Models
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BgColor { get; set; }
        public string BgImage { get; set; }
        public bool UseBgImage { get; set; } = false;
    }
}
