using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Entities
{
    public class Cart : EntityBase
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public decimal PositionYaw { get; set; }
        public decimal PositionPitch { get; set; }
        public Guid CreateByUserId { get; set; }
        public User CreateByUser { get; set; }
        public Guid UpdateByUserId { get; set; }
        public User UpdateByUser { get; set; }

    }
}
