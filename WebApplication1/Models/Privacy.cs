using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblPrivacy3")]
    public class Privacy
    {
        public int PId { get; set; }
        public string FirstName { get; set; }
        public string Issue { get; set; }
        public string Manager { get; set; }

    }
}
