namespace RESTfulAPI.AspNetCore.NewDb.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int DepartmentId { get; set; }
    }
}