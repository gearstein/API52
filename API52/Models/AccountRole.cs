using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Models
{
    [Table("tb_Tr_AccountRole")]
    public class AccountRole
    {
        public string NIK { get; set; }
        public int RoleID { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
