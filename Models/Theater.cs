using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class Theater
    {
        [Key]
        public uint ID { get; set; } // db id
        [StringLength(255)]
        public string Name { get; set; } // user-friendly name
        [Range(1, 255)]
        public byte NumCols { get; set; } // number of seats per row
        [Range(1, 255)]
        public byte NumRows { get; set; } // number of rows parallel to the screen


        public Theater(string name, byte rows, byte cols)
        {
            Name = name;
            NumRows = rows;
            NumCols = cols;
        }

        public Theater()
        {

        }
    }
}