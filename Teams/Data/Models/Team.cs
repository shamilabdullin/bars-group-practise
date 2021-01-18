using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Data.Models
{
    /// <summary>
    /// Судья.
    /// </summary>
    [Table("teams")]
    public class Team
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Имя команды
        /// </summary>
        [Column("name", TypeName = «varchar(150)»)]
        public string Name { get; set; }

        [Column("sport_id", TypeName= "integer")]
        public int? SportId { get; set; }

        [ForeignKey("SportId")]
        public virtual Sport Sport { get; set; }
    }
}
