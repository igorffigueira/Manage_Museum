using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.Builder;
using ManageMuseumData.DataBaseModel;
using ManageMuseumData.GetData;

namespace ManageMuseumData
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> rooms = new List<string>() { "Sala Funchal", "Sala Câmara de Lobos" };

            //Manager man = new Manager();
            //EventBuilder ev = new ExpositionEventBuilder();
            ////EventBuilder ev = new SocialEventBuilder();
            //man.Construct(ev, rooms, "albertinho é o meu padrinho", DateTime.Now, DateTime.Now.AddDays(1), "gjvlgjklçssfdklsfdklsçºkl", 1);
            //var remove = new ArtPiecesData();

            //remove.RemoveFromExhibition(1);
            ArtPiecesData art = new ArtPiecesData();

            art.AddPieceToRoom(1,2,3, "exposicao");

            Console.ReadKey();
        }
    }
}
