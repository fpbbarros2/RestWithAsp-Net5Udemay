using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5UdemayErudio.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
