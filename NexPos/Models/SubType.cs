using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPos.Models
{
    public class SubType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public string BgColor { get; set; }

        public string BgImage { get; set; }

        public bool UseBgImage { get; set; } = false;

        public bool HasMultiplePrices { get; set; } = false;
    }
}
