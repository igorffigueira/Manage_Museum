using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.DataBaseModel
{
    public class DbAccess :  DbContext
    {


        private static DbAccess _instance;

        public DbAccess()
        {
           
        }

        public static DbAccess getInstance()
        {
            if (_instance == null)
            {
                _instance = new DbAccess();
            }
            return _instance;
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<ArtPiece> ArtPieces { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventState> EventStates { get; set; }
        public DbSet<OutSideSpace> OutSideSpaces { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<RoomMuseum> RoomMuseums { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ArtPieceState> ArtPieceStates { get; set; }
        public DbSet<SpaceState> SpaceStates { get; set; }
    }
}
