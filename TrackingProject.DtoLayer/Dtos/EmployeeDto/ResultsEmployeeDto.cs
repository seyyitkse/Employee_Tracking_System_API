using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.DtoLayer.Dtos.EmployeeDto
{
    public class ResultsEmployeeDto
    {
        public string? Id { get; set; }
        public string? Mail { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int DepartmentID { get; set; }
    }
}
