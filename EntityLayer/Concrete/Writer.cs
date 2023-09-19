using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [StringLength(100)]
        public string About { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public bool Status { get; set; }

        public ICollection<Content> Contents { get; set; }
        public ICollection<Heading> Headings { get; set; }
    }
}
