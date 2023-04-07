using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Model
{
    public class ProjectTable
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string StatusoftheProject{get; set; }
        public string AssignedBy { get;set; }
        public string Description { get; set; }
        public int SignuploginId { get; set; }

        [ForeignKey("SignuploginId")]
        public virtual Signuplogin Signuplogins { get; set; }
    }
}
