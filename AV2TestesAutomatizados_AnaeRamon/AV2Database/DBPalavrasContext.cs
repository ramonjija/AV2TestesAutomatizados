using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AV2Database.Model;

namespace AV2Database
{
    public class DBPalavrasContext : DbContext
    {
        public DBPalavrasContext() : 
            base("DBPalavrasContext")
        {
        }
        public DbSet<PalavrasModel> Palavras { get; set; }
    }
}
