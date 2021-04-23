using System;
using System.Collections.Generic;

#nullable disable

namespace JoinTable.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int Deptid { get; set; }
        public string DeptName { get; set; }
        public DateTime? DeptAddedDate { get; set; }

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}
