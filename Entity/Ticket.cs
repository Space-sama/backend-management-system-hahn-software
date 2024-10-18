using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace backend_management_system_api.Entity

{
    [Table("Ticket")]
    public class Ticket
    {
        public int Id {get; set;}

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Description is required !")]
        public string Description {get; set;} = string.Empty;

        [Required(ErrorMessage = "Status is required !")]
        public Status Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}