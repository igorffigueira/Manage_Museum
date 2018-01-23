using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageMuseum.Models
{
    public class ArtPiece
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Dimension { get; set; }

        public RoomMuseum RoomMuseum { get; set; }
        //vai dar probelmas se for para inserir na base de dados porque este formato é maior que a BD suporta
        public DateTime Year { get; set; }
        public string Author { get; set; }
        public string State { get; set; }
        public ArtPieceState ArtPieceState { get; set; }

    }
}