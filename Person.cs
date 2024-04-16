using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        // public string AdditionalContactInfo { get; set; } // This might be the XML field
        // public string Demographics { get; set; } // This might be the XML field
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}
