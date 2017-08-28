namespace PublicServiceRequest.Admin.Common.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PSR.DbObjects")]
    public partial class DbObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string TableSchema { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        [Required]
        [StringLength(100)]
        public string ColumnName { get; set; }

        [Required]
        [StringLength(50)]
        public string DataType { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [StringLength(2254)]
        public string Tooltip { get; set; }
    }
}
