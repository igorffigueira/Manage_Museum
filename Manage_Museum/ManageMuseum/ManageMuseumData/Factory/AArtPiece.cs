using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.Factory
{
    /// <summary>
    /// classe abstrata das peças de arte
    /// </summary>
    public abstract class AArtPiece
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Dimension { get; set; }

        public DateTime Year { get; set; }
        public string Author { get; set; }
    }
}
