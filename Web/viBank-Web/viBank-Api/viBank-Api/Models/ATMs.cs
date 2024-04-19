using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class ATMs
    {
        public long ID { get; set; }

        public Guid ATMID { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal AvailbleBalance { get; set; }
        public Guid TransactionID { get; set; }
        public Boolean isActive { get; set; } = true;
        public Boolean isDeleted { get; set; } = false;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDTM { get; set; }
        public DateTime UpdatedDTM { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
    }
}