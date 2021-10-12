using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Table("Constellation")]
    public partial class Constellation
    {

		[Key]
		public int cid { get; set; }

		[StringLength(50)]
		public string cname { get; set; }

		[StringLength(100)]
		public string cimage { get; set; }

		public bool? cisshow { get; set; }

		public int? csort { get; set; }

		public string cremark { get; set; }

    }
}
