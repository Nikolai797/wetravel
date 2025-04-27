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
        /// <summary>
        /// Адреса на клиента
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Телефонния номер на клиента
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Имейла на клиента
        /// </summary>
        public string Email { get; set; }
    }
}
