using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Employee
    {
        [Key]

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [AllowNull]
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        [AllowNull]
        public string MobileNumber { get; set; }
        public string JoinDate { get; set; }
        [ForeignKey("Roles")]
        public string JobTitle { get; set; }
        [ForeignKey("Location")]
        public string Location { get; set; }
        [ForeignKey("Department")]
        public string Department { get; set; }
        [ForeignKey("Employee")]
        [AllowNull]
        public string ManagerId { get; set; }
        [ForeignKey("Project")]
        public string Project { get; set; }
        public static string[] Headers = { "Exit", "FirstName", "LastName", "Date Of Birth", "Email", "MobileNumber", "JoinDate", "JobTitle", "Location", "Department", "ManagerId", "Project" };

    }
}
