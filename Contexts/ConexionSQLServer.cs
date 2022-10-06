using Encuestadiego.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuestadiego.Contexts
{
    public class ConexionSQLServer:DbContext

    {

        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options){
        
        }

        public DbSet<EncuestaEntity> Encuestas { get; set; }

    }
}
