using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using QmsCore.Model;
using Qms_Data.Repositories.Interfaces;

namespace Qms_DataCore.Repositories
{
    public class SecurityLogRepository : ISecurityLogRepository
    {
        internal QMSContext _dbContext;

        public SecurityLogRepository()
        {
            _dbContext = new QMSContext();
        }

        public SecurityLogRepository(QMSContext qMSContext)
        {
            _dbContext = qMSContext;
        }

        public void SaveEntry(SecSecuritylog logEntry)
        {
            _dbContext.SecSecuritylog.Add(logEntry);
            _dbContext.SaveChanges();
        }

        public SecSecuritylogtype RetrieveSecurityLogType(string securityLogTypeCode)
        {
            return _dbContext.SecSecuritylogtype.Where(s => s.SecurityLogTypeCode == securityLogTypeCode).SingleOrDefault();
        }

        



    }//end class
}//end namespace