using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на клиента
        /// </summary>
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
