
using Microsoft.EntityFrameworkCore;
using PictureEditor.Models;
using System.Collections.Generic;


namespace DataAccess
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Effect> Effects { get; set; }
        public DbSet<Transform> Transforms { get; set; }

    }
}