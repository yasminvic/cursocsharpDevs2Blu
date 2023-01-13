using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.Entities
{
    [Table("news")]
    public class News
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Column("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [Column("published")]
        public bool Published { get; set; }

        public virtual Category? Category { get; set; }
    }
}
