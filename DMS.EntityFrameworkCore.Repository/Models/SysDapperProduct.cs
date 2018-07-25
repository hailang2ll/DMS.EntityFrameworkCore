using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysDapperProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
    }
}
