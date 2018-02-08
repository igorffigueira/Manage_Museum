using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.Builder
{
    public class SocialEventBuilder : EventBuilder
    {
        private DbAccess db = new DbAccess();


        /// <summary>
        /// adiciona os espaços ao evento recebendo uma lista de espaços  exteriores
        /// </summary>
        /// <param name="spaces"></param>
        public override void AddSpace(List<string> spaces)
        {
            List<OutSideSpace> rooms = new List<OutSideSpace>();
            var ocupied = db.SpaceStates.Single(s => s.Name == "ocupada");
            foreach (var item in spaces)
            {
                var aux = db.OutSideSpaces.Single(s => s.Name == item);
                aux.SpaceState = ocupied;
                rooms.Add(aux);
            }


            _event.OutSideSpaces = rooms;
        }
        /// <summary>
        /// addiciona aos eventos o responsavel por a criação desse evento
        /// </summary>
        /// <param name="user"></param>
        public override void AddUser(int user)
        {
            var uu = db.UserAccounts.Include("Role").Single(s => s.Id == user);

            _event.UserAccount = uu;
        }
        /// <summary>
        /// Define o estado do evento consoante o papel do utilizador
        /// </summary>
        public override void AddEventState()
        {

            var state = db.EventStates.Single(s => s.Name == "aceites");
            _event.EventState = state;


        }
        /// <summary>
        /// define o tipo de envento 
        /// </summary>
        public override void AddEventType()
        {
            var type = db.EventTypes.Single(s => s.Name == "social");
            _event.EventType = type;
        }
        /// <summary>
        /// adiciona os detalhes do evento, tais como nome, data de inicio e fim e a descrição desse evento
        /// </summary>
        /// <param name="name"></param>
        /// <param name="starTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="description"></param>
        public override void AddEventDetails(string name, DateTime starTime, DateTime endDateTime, string description)
        {
            _event.Name = name;
            _event.StartDate = starTime;
            _event.EnDate = endDateTime;
            _event.Description = description;

        }

        /// <summary>
        /// guarda o evento na base de dados
        /// </summary>
        public override void Save()
        {
            db.Events.Add(_event);
            db.SaveChanges();
        }
    }
}
