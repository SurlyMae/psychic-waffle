using System.Collections.Generic;

namespace RESTfulAPI.AspNetCore.NewDb.Models
{
    public class DepartmentForCreationDTO
    {
        public string Name { get; set; }
        public ICollection<EmployeeForCreationDTO> Employees { get; set; } 
        = new List<EmployeeForCreationDTO>();
    }
}