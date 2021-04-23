using System;
using System.Collections.Generic;

#nullable disable

namespace JoinTable.Models
{
    public partial class TblEmployee
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }
        public string EmpPhone { get; set; }
        public int? EmpDept { get; set; }

        public virtual TblDepartment EmpDeptNavigation { get; set; }
    }
}
