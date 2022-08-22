using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.EF.Model
{
    public class Person
    {
        public Person()
        {

        }
        public Person(bool isNew)
        {
            if (isNew)
            {
                Id = Guid.NewGuid();
            }
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EasyKey { get; set; }
    }
}
