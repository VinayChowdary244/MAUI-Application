using SQLite;

namespace Application.Models
{
    [Table("employee")]
    public class Employee
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("employee_name")]
        public string EmployeeName { get; set; }
        [Column("mobile")]
        public string Mobile {  get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("joinedDate")]
        public DateTime JoinedDate { get; set; }
        [Column("department")]
        public String Department { get; set; }
        [Column("image")]
        public string Image { get; set; }
    }
}
