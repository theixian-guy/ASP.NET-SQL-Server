using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Employee
    {
        [Key] // Add this attribute to specify the primary key
        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
  //      public string OrganizationNode { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Additional properties for employee name and department ID
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short DepartmentID { get; set; }
        // If there are foreign key relationships, you may need navigation properties as well.
        // For example, if there's a one-to-many relationship with another table:
        // public virtual ICollection<OtherEntity> OtherEntities { get; set; }

    }

}
