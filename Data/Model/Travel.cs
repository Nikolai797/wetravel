using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        ///  Идентификация
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Дестинация
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Идентификатор на клиента
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
