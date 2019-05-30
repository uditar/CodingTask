using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class ToDoModel
    {
        [Key]
        public int Task_ID { get; set; }

        public string Task_Description { get; set; }
        public virtual ApplicationUser User { get; set; }
        public bool Is_Task_Complete { get; set; }

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Column(TypeName = "datetime2")]
        public DateTime Due_In { get; set; }

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm}")]
        [Column(TypeName = "datetime2")]
        public DateTime Last_Updated { get; set; }


    }
}