namespace ADONETExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADONETSAMPLE")]
    public partial class ADONETSAMPLE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Region { get; set; }
    }
}
