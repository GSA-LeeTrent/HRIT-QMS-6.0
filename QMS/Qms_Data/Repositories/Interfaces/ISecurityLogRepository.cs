using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.Repositories.Interfaces
{
    public interface ISecurityLogRepository
    {
        public void SaveEntry(SecSecuritylog logEntry);
        public SecSecuritylogtype RetrieveSecurityLogType(string securityLogTypeCode);
    }
}
