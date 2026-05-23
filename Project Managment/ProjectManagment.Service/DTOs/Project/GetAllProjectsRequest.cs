using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.DTOs.Project
{
    public class GetAllProjectsRequest
    {
        public int? pageSize { get; set; }
        public int? pageCount { get; set; }
    }
}
