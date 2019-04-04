namespace RESTfulAPI.AspNetCore.NewDb.Models
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Department Department { get; set; }
    }
}