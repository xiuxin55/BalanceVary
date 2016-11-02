using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorization
{
    public class DutyModel
    {
        public string DutyId { get; set; }
        public string DutyCode { get; set; }
        public string DutyName { get; set; }
        public string DutyDescribe { get; set; }
        public string UserDutyID { get; set; }

        public DutyModel Clone()
        {
            DutyModel dm = new DutyModel();
            dm.DutyId = this.DutyId;
            dm.DutyCode = this.DutyCode;
            dm.DutyName = this.DutyName;
            dm.DutyDescribe = this.DutyDescribe;
            return dm;
        }
    }
}
