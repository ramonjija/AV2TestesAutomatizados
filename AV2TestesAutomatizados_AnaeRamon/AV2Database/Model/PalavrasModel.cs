using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV2Database.Model
{
    [Table("TbPalavras")]
    public class PalavrasModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
