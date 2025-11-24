namespace CoreAPI.Models
{
    public class Employee
    {
        public int eid { set; get; }
        public string? ename { set; get; }
        public string? eaddr { set; get; }
        public string? esal { set; get; }
    }

    public class EmployeeDTO
    {
       
        public string? ename { set; get; }
        public string? eaddr { set; get; }
        public string? esal { set; get; }
    }
}
