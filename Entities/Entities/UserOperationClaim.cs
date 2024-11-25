using System;
using System.Collections.Generic;
using System.Text;

namespace Items.Entities
{
    public class UserOperationClaim:EntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
