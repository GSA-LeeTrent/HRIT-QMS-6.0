using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QmsCore.Model;
using QmsCore.UIModel;
using MySql.Data.MySqlClient;
using Qms_Data.Model;

namespace QmsCore.Repository
{
    public class StaffingErrorRepository
    {
        string databaseConnection;
        string dateFormat = "yyy-MM-dd";
        const int defaultPageSize = 50;
        const int archiveDaysBack = -30;
        DateTime archiveDate;
        internal QMSContext context;
        public StaffingErrorRepository(QMSContext qMSContext)
        {
            context = qMSContext;
            databaseConnection = Config.Settings.ReconDB;
            archiveDate = DateTime.Now.AddDays(archiveDaysBack);
        }

        public StaffingErrorRepository() 
        {
            archiveDate = DateTime.Now.AddDays(archiveDaysBack);
            databaseConnection = Config.Settings.ReconDB;
        }

        public void Update(QmsStfacqError entity)
        {
            QmsStfacqError oldEntity = this.RetrieveById(entity.QmsStfacqErrorId);
            context.Entry(oldEntity).State = EntityState.Deleted;
            context.Entry(entity).State = EntityState.Modified;
            entity.RowVersion++;
            entity.UpdatedAt = DateTime.Now;
            context.SaveChanges();
        }


        internal IQueryable<QmsWorkitemcomment> RetrieveComments(int entityId)
        {
            return context.QmsWorkitemcomment.Where(c => c.WorkItemId == entityId && c.WorkItemTypeCode == WorkItemTypeEnum.StaffAcquisition && c.DeletedAt == null).Include(c => c.Author).OrderByDescending(c => c.WorkItemId);
        }

        internal QmsWorkitemcomment RetrieveLatestComment(int entityId)
        {
            return context.QmsWorkitemcomment.Where(c => c.WorkItemId == entityId && c.WorkItemTypeCode == WorkItemTypeEnum.StaffAcquisition).Include(c => c.Author).OrderByDescending(c => c.WorkItemId).FirstOrDefault();
        }

        internal IQueryable<QmsWorkitemhistory> RetrieveHistory(int entityId)
        {
            return context.QmsWorkitemhistory.AsNoTracking().Where(c => c.WorkItemId == entityId && c.WorkItemTypeCode == WorkItemTypeEnum.StaffAcquisition).Include(c => c.PreviousAssignedByUser).Include(c => c.PreviousAssignedToOrg).Include(c => c.PreviousStatus).Include(c => c.PreviousAssignedtoUser).Include(c => c.ActionTakenByUser).Include(c => c.WorkItemTypeCodeNavigation);
        }


        public QmsStfacqError RetrieveById(int id)
        {
            return context.QmsStfacqError.AsNoTracking().Where(e => e.QmsStfacqErrorId == id)
                                      .Include(e => e.AssignedByUser)
                                      .Include(e => e.AssignedToOrg)
                                      .Include(e => e.AssignedToUser)
                                      .Include(e => e.Status)
                                      .Include(e => e.CreatedByUser)
                                      .SingleOrDefault();

        }

        public StaffingErrorListItemPager GetActiveRecordsAll(string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            StaffingErrorListItemPager pager = new StaffingErrorListItemPager();
            pager.Records = getActiveRecordsAll(orderBy, pageNumber, pageSize);
            int totalRecordCount = getActiveCountAll();
            pager.SetPagerInfo(pageSize, totalRecordCount, pageNumber);
            return pager;
        }

        public StaffingErrorListItemPager GetArchiveRecordsAll(string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            StaffingErrorListItemPager pager = new StaffingErrorListItemPager();
            pager.Records = getArchiveRecordsAll(orderBy, pageNumber, pageSize);
            int totalRecordCount = getArchiveCountAll();
            pager.SetPagerInfo(pageSize, totalRecordCount, pageNumber);
            return pager;
        }

        private List<SaStaffacquisitionlistitem> getActiveRecordsAll(string orderBy, int pageNumber, int pageSize)
        {
            return getItemList(orderBy, pageNumber, pageSize, "aca.epc_getActiveStaffAcquisitionListItems");
        }

        private List<SaStaffacquisitionlistitem> getArchiveRecordsAll(string orderBy, int pageNumber, int pageSize)
        {
            return getItemList(orderBy, pageNumber, pageSize, "aca.epc_getArchiveStaffAcquisitionListItems");
        }

        private List<SaStaffacquisitionlistitem> getItemList(string orderBy, int pageNumber, int pageSize, string commandName)
        {
            
            List<SaStaffacquisitionlistitem> items = new List<SaStaffacquisitionlistitem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    command.Parameters.AddWithValue("archive_date", archiveDate);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }


        public StaffingErrorListItemPager GetActiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize = defaultPageSize)
        {
            StaffingErrorListItemPager pager = new StaffingErrorListItemPager();
            pager.Records = getActiveRecordsByOrg(orderBy, pageNumber, orgId, pageSize);
            int totalRecordCount = getActiveCountByOrg(orgId);
            pager.SetPagerInfo(pageSize, totalRecordCount, pageNumber);
            return pager;
        }
        public StaffingErrorListItemPager GetArchiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize = defaultPageSize)
        {
            StaffingErrorListItemPager pager = new StaffingErrorListItemPager();
            pager.Records = getArchiveRecordsByOrg(orderBy, pageNumber, orgId, pageSize);
            int totalRecordCount = getArchiveCountByOrg(orgId);
            pager.SetPagerInfo(pageSize, totalRecordCount, pageNumber);
            return pager;
        }

        private List<SaStaffacquisitionlistitem> getActiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize = defaultPageSize)
        {
            return getItemListByOrg(orderBy, pageNumber, pageSize, orgId, "aca.epc_getActiveStaffAcquisitionListItemsByOrg");
        }

        private List<SaStaffacquisitionlistitem> getArchiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize = defaultPageSize)
        {
            return getItemListByOrg(orderBy, pageNumber, pageSize, orgId, "aca.epc_getArchiveStaffAcquisitionListItemsByOrg");
        }

        private List<SaStaffacquisitionlistitem> getItemListByOrg(string orderBy, int pageNumber, int pageSize, int orgId, string commandName)
        {
            List<SaStaffacquisitionlistitem> items = new List<SaStaffacquisitionlistitem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    command.Parameters.AddWithValue("archive_date", archiveDate);
                    command.Parameters.AddWithValue("org_id", orgId);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }


        public StaffingErrorListItemPager GetActiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize = defaultPageSize)
        {
            StaffingErrorListItemPager pager = new StaffingErrorListItemPager();
            pager.Records = getActiveRecordsByUser(orderBy, pageNumber, userId, pageSize);
            int totalRecordCount = getActiveCountByUser(userId);
            pager.SetPagerInfo(pageSize, totalRecordCount, pageNumber);
            return pager;
        }
        public StaffingErrorListItemPager GetArchiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize = defaultPageSize)
        {
            StaffingErrorListItemPager pager = new StaffingErrorListItemPager();
            pager.Records = getArchiveRecordsByUser(orderBy, pageNumber, userId, pageSize);
            int totalRecordCount = getArchiveCountByUser(userId);
            pager.SetPagerInfo(pageSize, totalRecordCount, pageNumber);
            return pager;
        }
        private List<SaStaffacquisitionlistitem> getActiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize = defaultPageSize)
        {
            return getItemListByUser(orderBy, pageNumber, pageSize, userId, "aca.epc_getActiveStaffAcquisitionListItemsByUser");
        }

        private List<SaStaffacquisitionlistitem> getArchiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize = defaultPageSize)
        {
            return getItemListByUser(orderBy, pageNumber, pageSize, userId, "aca.epc_getArchiveStaffAcquisitionListItemsByUser");
        }
        private List<SaStaffacquisitionlistitem> getItemListByUser(string orderBy, int pageNumber, int pageSize, int userId, string commandName)
        {
            List<SaStaffacquisitionlistitem> items = new List<SaStaffacquisitionlistitem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    command.Parameters.AddWithValue("archive_date", archiveDate);
                    command.Parameters.AddWithValue("user_id", userId);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }

        private List<SaStaffacquisitionlistitem> loadItems(MySqlDataReader dataReader)
        {
            List<SaStaffacquisitionlistitem> items = new List<SaStaffacquisitionlistitem>();
            while (dataReader.Read())
            {
                SaStaffacquisitionlistitem item = new SaStaffacquisitionlistitem();
                item.QmsStfacqErrorId = dataReader.GetInt32("qms_stfacq_error_id");
                item.QmsKey = dataReader.GetString("qms_key");
                item.SystemName = dataReader.GetString("system_name");
                item.ErrorSummary = dataReader.GetString("error_summary");
                item.ErrorDetails = dataReader.GetString("error_details");
                item.AssignedByUserId = dataReader.GetUInt32("assigned_by_user_id");
                item.AssignedByUserName = dataReader.GetString("assigned_by_user_name");
                item.AssignedToOrgId = dataReader.GetUInt32("assigned_to_org_id");
                item.AssignedToOrgName = dataReader.GetString("assigned_to_org_name");
                item.AssignedToUserId = dataReader.GetUInt32("assigned_to_user_id");
                item.AssignedToUserName = dataReader.GetString("assigned_to_user_name");
                item.CreatedAt = dataReader.GetDateTime("created_at");
                item.QmsErrorCode = dataReader.GetString("qms_error_code");
                item.RowVersion = dataReader.GetSByte("row_version");
                item.ShortErrorDescription = dataReader.GetString("short_error_description");
                item.StatusDescription = dataReader.GetString("status_description");
                item.StatusId = dataReader.GetUInt32("status_id");
                if (!dataReader.IsDBNull(5))
                    item.Notes = dataReader.GetString("notes");
                if (!dataReader.IsDBNull(17))
                    item.AssignedAt = dataReader.GetDateTime("assigned_at");
                if (!dataReader.IsDBNull(20))
                    item.DeletedAt = dataReader.GetDateTime("deleted_at");
                if(!dataReader.IsDBNull(18))
                    item.ResolvedAt = dataReader.GetDateTime("resolved_at");
                if (!dataReader.IsDBNull(19))
                    item.UpdatedAt = dataReader.GetDateTime("updated_at");
                items.Add(item);


            }
            return items;
        }

        private int getActiveCountAll()
        {
            string whereClause = string.Format(" deleted_at is null and (resolved_at is null or resolved_at >= '{0}')", archiveDate.ToString(dateFormat));
            return getCount(whereClause);
        }

        private int getArchiveCountAll()
        {
            string whereClause = string.Format(" deleted_at is not null and resolved_at <= '{0}'", archiveDate.ToString(dateFormat));
            return getCount(whereClause);
        }

        private int getActiveCountByOrg(int orgId)
        {
            string whereClause = string.Format(" deleted_at is null and (resolved_at is null or resolved_at >= '{0}') and assigned_to_org_id = {1}", archiveDate.ToString(dateFormat), orgId);
            return getCount(whereClause);
        }

        private int getArchiveCountByOrg(int orgId)
        {
            string whereClause = string.Format(" deleted_at is not null and resolved_at <= '{0}' and assigned_to_org_id = {1}", archiveDate.ToString(dateFormat), orgId);
            return getCount(whereClause);
        }

        private int getActiveCountByUser(int userId)
        {
            string whereClause = string.Format(" deleted_at is null and (resolved_at is null or resolved_at >= '{0}') and assigned_to_user_id = {1}", archiveDate.ToString(dateFormat), userId);
            return getCount(whereClause);
        }

        private int getArchiveCountByUser(int userId)
        {
            string whereClause = string.Format(" deleted_at is not null and resolved_at <= '{0}' and assigned_to_user_id = {1}", archiveDate.ToString(dateFormat), userId);
            return getCount(whereClause);
        }


        private int getCount(string whereClause)
        {
            string sql = "select count(*) T FROM aca.sa_StaffAcquisitionListItem where " + whereClause;
            int count = 0;
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    count = Int32.Parse(command.ExecuteScalar().ToString());
                    connection.Close();
                }
            }
            return count;
        }



    }
}
