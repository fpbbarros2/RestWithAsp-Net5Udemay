using RestWithAspNet5UdemayErudio.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5UdemayErudio.Models
{
    [Table("person")]
    public class Person : BaseEntity
    {
        

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

    }
}
