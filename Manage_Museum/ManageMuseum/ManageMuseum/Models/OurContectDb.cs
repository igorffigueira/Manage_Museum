using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ManageMuseum.Models
{
    public class OurContectDb: DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<ArtPiece> ArtPieces { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventState> EventStates { get; set; }
        public DbSet<OutSideSpace> OutSideSpaces { get; set; }
        public DbSet<EventType> EventState { get; set; }
        public DbSet<RoomMuseum> RoomMuseums { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ArtPieceState> ArtPieceStates { get; set; }
}
}