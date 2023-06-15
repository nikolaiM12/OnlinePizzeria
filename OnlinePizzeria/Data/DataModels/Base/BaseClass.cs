using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlinePizzeria.Data.DataModels.Base
{
    public abstract class BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public BaseClass()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}
