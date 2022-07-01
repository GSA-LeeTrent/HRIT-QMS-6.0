using Qms_Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using QmsCore.Model;
using MySql.Data.MySqlClient;

namespace Qms_Data.Repository
{
    public class PositionClassificationRepository
    {
        string databaseConnection;
        const int defaultPageSize = 50;

        public PositionClassificationRepository()
        {
            databaseConnection = Config.Settings.ReconDB;

        }

        #region "FullList"
        #region "All"
        public EmployeeCategorizationListItemPager GetFullList(string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            string commandName = "epc_getFullEmplCategorization";
            EmployeeCategorizationListItemPager pager = new EmployeeCategorizationListItemPager();
            pager.Records = loadData(commandName, orderBy, pageNumber, pageSize);
            pager.TotalRecords = GetFullListCount();
            decimal pageCount = pager.TotalRecords / defaultPageSize;
            int x = (pager.TotalRecords % defaultPageSize) > 0 ? 1 : 0;
            //            double pageCount = (double)((decimal)pager.Records.Count / Convert.ToDecimal(defaultPageSize));
            pager.PageCount = (int)pageCount + x;
            return pager;
        }

        internal int GetFullListCount()
        {
            string sql = "select count(*) Total FROM aca.epc_EmployeePositionCategorizationList";
            return getCount(sql);
        }


        public EmployeeCategorizationListItemPager GetFullListSearchResults(string searchCriteria, string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            string commandName = "epc_searchEmplPositionCategorization";
            EmployeeCategorizationListItemPager pager = new EmployeeCategorizationListItemPager();
            pager.Records = loadSearchResults(commandName, searchCriteria, orderBy, pageNumber, pageSize);
            pager.TotalRecords = GetFullListSearchCount(searchCriteria);
            decimal pageCount = pager.TotalRecords / defaultPageSize;
            int x = (pager.TotalRecords % defaultPageSize) > 0 ? 1 : 0;
            //            double pageCount = (double)((decimal)pager.Records.Count / Convert.ToDecimal(defaultPageSize));
            pager.PageCount = (int)pageCount + x;
            return pager;
        }

        public int GetFullListSearchCount(string searchCriteria)
        {
            string sql = string.Concat("select count(*) Total FROM aca.epc_EmployeePositionCategorizationList ",
                                       "where (emplid like ('%", searchCriteria, "%') ",
                                       "or employee like ('%", searchCriteria, "%')) ");
            return getCount(sql);
        }


        #endregion
        #region "By Org"
        public EmployeeCategorizationListItemPager GetFullListByOrg(string orderBy, int pageNumber, int userOrgId, int pageSize = defaultPageSize)
        {
            string commandName = "epc_getFullEmplCategorizationByOrg";
            EmployeeCategorizationListItemPager pager = new EmployeeCategorizationListItemPager();
            pager.Records = loadData(commandName, orderBy, pageNumber, pageSize, userOrgId);
            pager.TotalRecords = GetFullListByOrgCount(userOrgId);
            double pageCount = (double)((decimal)pager.TotalRecords / Convert.ToDecimal(pageSize));
            pager.PageCount = (int)Math.Ceiling(pageCount);
            return pager;


        }
        public int GetFullListByOrgCount(int userOrgId)
        {
            //return 0;   
            string sql = "select count(*) Total FROM aca.epc_EmployeePositionCategorizationList where PersonnelOfficeIdentifier = (select poi_Id from aca.qms_personnel_office_identifier where OrgID = " + userOrgId + ");";
            return getCount(sql);
        }

        //epc_searchEmplPositionCategorizationByOrg

        public EmployeeCategorizationListItemPager GetFullListSearchResultsByOrg(int orgId, string searchCriteria, string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            string commandName = "epc_searchEmplPositionCategorizationByOrg";
            EmployeeCategorizationListItemPager pager = new EmployeeCategorizationListItemPager();
            pager.Records = loadSearchResults(commandName, searchCriteria, orderBy, orgId, pageNumber, pageSize);
            pager.TotalRecords = pager.Records.Count;
            decimal pageCount = pager.TotalRecords / defaultPageSize;
            int x = (pager.TotalRecords % defaultPageSize) > 0 ? 1 : 0;
            //            double pageCount = (double)((decimal)pager.Records.Count / Convert.ToDecimal(defaultPageSize));
            pager.PageCount = (int)pageCount + x;
            return pager;
        }



        #endregion
        #endregion


        #region "Chase List"

        #region "All"
        public EmployeeCategorizationChaseListItemPager GetFullChaseList(string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            string commandName = "epc_getEmplCategorizationChaseList";
            EmployeeCategorizationChaseListItemPager pager = new EmployeeCategorizationChaseListItemPager();
            pager.Records = loadChaseData(commandName, orderBy, pageNumber, pageSize);
            pager.TotalRecords = GetFullChaseListCount();
            decimal pageCount = pager.TotalRecords / defaultPageSize;
            int x = (pager.TotalRecords % defaultPageSize) > 0 ? 1 : 0;
            //            double pageCount = (double)((decimal)pager.Records.Count / Convert.ToDecimal(defaultPageSize));
            pager.PageCount = (int)pageCount + x;
            return pager;
        }
        public int GetFullChaseListCount()
        {
            string sql = "SELECT count(*) Total FROM aca.epc_employeepositiontobevalidated;";
            return getCount(sql);
        }


        public EmployeeCategorizationChaseListItemPager GetFullChaseListSearch(string searchCriteria, string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            string commandName = "epc_searchEmplPositionCategorizationChaseList";
            EmployeeCategorizationChaseListItemPager pager = new EmployeeCategorizationChaseListItemPager();
            pager.Records = loadChaseListSearchResults(commandName, searchCriteria, orderBy, pageNumber, pageSize);
            pager.TotalRecords = GetFullChaseListSearchCount(searchCriteria);
            decimal pageCount = pager.TotalRecords / defaultPageSize;
            int x = (pager.TotalRecords % defaultPageSize) > 0 ? 1 : 0;
            //            double pageCount = (double)((decimal)pager.Records.Count / Convert.ToDecimal(defaultPageSize));
            pager.PageCount = (int)pageCount + x;
            return pager;

        }
        public int GetFullChaseListSearchCount(string searchCriteria)
        {
            string sql = string.Concat("select count(*) FROM aca.epc_employeepositiontobevalidated ",
                  "where emplid like ('%", searchCriteria, "%') ",
                  "or employee like ('%", searchCriteria, "%') ",
                  "or chasereason like ('%", searchCriteria, "%') ");
            return getCount(sql);
        }


        #endregion

        #region "By Org"
        //
        public EmployeeCategorizationChaseListItemPager GetChaseListSearchByOrg(int orgId, string searchCriteria, string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            string commandName = "epc_searchEmplPositionCategorizationChaseListByOrg";
            EmployeeCategorizationChaseListItemPager pager = new EmployeeCategorizationChaseListItemPager();
            pager.Records = loadChaseListSearchResults(commandName, searchCriteria, orderBy, orgId, pageNumber, pageSize);
            pager.TotalRecords = GetFullChaseListSearchByOrgCount(searchCriteria, orgId);
            double pageCount = (double)((decimal)pager.Records.Count / Convert.ToDecimal(defaultPageSize));
            pager.PageCount = (int)Math.Ceiling(pageCount);
            return pager;

        }



        public int GetFullChaseListSearchByOrgCount(string searchCriteria, int orgId)
        {
            string sql = string.Concat("select count(*) from FROM aca.epc_employeepositiontobevalidated ",
                  "where (emplid like ('%", searchCriteria, "%') ",
                  "or employee like ('%", searchCriteria, "%') ",
                  "or chasereason like ('%", searchCriteria, "%')) ",
                  "and (PersonnelOfficeId = '", orgId, "') ");
            return getCount(sql);
        }





        public EmployeeCategorizationChaseListItemPager GetFullChaseListByOrg(string orderBy, int pageNumber, int userOrgId, int pageSize = defaultPageSize)
        {
            string commandName = "epc_getEmplCategorizationChaseListByOrg";
            EmployeeCategorizationChaseListItemPager pager = new EmployeeCategorizationChaseListItemPager();
            pager.Records = loadChaseData(commandName, orderBy, pageNumber, pageSize, userOrgId);
            pager.TotalRecords = GetChaseListByOrgCount(userOrgId);
            double pageCount = (double)((decimal)pager.TotalRecords / Convert.ToDecimal(pageSize));
            pager.PageCount = (int)Math.Ceiling(pageCount);
            return pager;
        }
        public int GetChaseListByOrgCount(int userOrgId)
        {
            //(select poi_Id from aca.qms_personnel_office_identifier where OrgID =userOrgId);
            string sql = "SELECT count(*) Total FROM aca.epc_employeepositiontobevalidated where PersonnelOfficeId = (select poi_Id from aca.qms_personnel_office_identifier where OrgID = " + userOrgId + ");";
            return getCount(sql);
        }

        #endregion

        #endregion


        public List<EmployeePositionCategory> GetPositionCategorizations()
        {
            List<EmployeePositionCategory> items = new List<EmployeePositionCategory>();
            string commandName = "SELECT PositionCategoryId CategorizationId, PositionCategoryLabel Categorization FROM aca.epc_positioncategory where deleted_at is null;";
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeePositionCategory item = new EmployeePositionCategory();
                        item.CategorizationId = reader.GetInt32("CategorizationId");
                        item.Categorization = reader.GetString("Categorization");
                        items.Add(item);
                    }
                    connection.Close();
                }//end command
            }//end connection
            return items;
        }



        public List<EmployeeCategorizationIntegerBasedDropDownItem> GetEmployeeCategorizationDaysInOfficeItem()
        {
            List<EmployeeCategorizationIntegerBasedDropDownItem> items = new List<EmployeeCategorizationIntegerBasedDropDownItem>();
            EmployeeCategorizationIntegerBasedDropDownItem initialValue = new EmployeeCategorizationIntegerBasedDropDownItem();
            initialValue.ItemText = "No Selection";
            initialValue.ItemValue = -1;
            items.Add(initialValue);
            for (int i = 0; i < 11; i++)
            {
                EmployeeCategorizationIntegerBasedDropDownItem item = new EmployeeCategorizationIntegerBasedDropDownItem();
                item.ItemValue = i;
                item.ItemText = i.ToString();
                items.Add(item);
            }
            return items;
        }
        public List<EmployeeCategorizationStringBasedDropDownItem> GetPositionNeedsToBeInLocationItems()
        {
            List<EmployeeCategorizationStringBasedDropDownItem> items = new List<EmployeeCategorizationStringBasedDropDownItem>();
            items.Add(new EmployeeCategorizationStringBasedDropDownItem { ItemText = "Select Option", ItemValue = "" });
            items.Add(new EmployeeCategorizationStringBasedDropDownItem { ItemText = "No", ItemValue = "N" });
            items.Add(new EmployeeCategorizationStringBasedDropDownItem { ItemText = "Yes", ItemValue = "Y" });
            return items;
        }



        public EmployeeCategorizationListItem GetEmployeeCategorizationItem(int id)
        {
            EmployeeCategorizationListItem item = new EmployeeCategorizationListItem();
            string commandName = "SELECT ID,EmplId,Employee,DepartmentId,AgencySubElement,PersonnelOfficeIdentifier,personnelofficelabel,ReportedOnPositionNumber,CurrentPositionNumber,PositionCategoryId,PositionCategoryLabel,PositionNeedsToBeInLocation,EstimatedDaysInOffice,comments,businessreason,FromDate, UpdatedBy FROM aca.epc_employeepositioncategorizationlist where id = " + id;
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item.Id = reader.GetInt32("Id");
                        item.EmplId = reader.GetString("EmplId");
                        item.Employee = reader.GetString("Employee");
                        item.DepartmentId = reader.GetString("DepartmentId");
                        item.AgencySubElement = reader.GetString("AgencySubElement");
                        item.PersonnelOfficeId = int.Parse(reader.GetString("PersonnelOfficeIdentifier"));
                        item.PersonnelOfficeLabel = reader.GetString("personnelofficelabel");
                        item.ReportedOnPositionNumber = reader.GetString("ReportedOnPositionNumber");
                        item.CurrentPositionNumber = reader.GetString("CurrentPositionNumber");
                        item.CategorizationId = reader.GetInt32("PositionCategoryId");
                        item.Categorization = reader.GetString("PositionCategoryLabel");
                        item.PositionNeedsToBeInLocation = reader.IsDBNull(11) ? string.Empty : reader.GetString("PositionNeedsToBeInLocation");
                        if (!reader.IsDBNull(12))
                            item.EstimatedDaysInOffice = reader.GetInt32("EstimatedDaysInOffice");
                        item.Comments = reader.IsDBNull(13) ? string.Empty : reader.GetString("comments");
                        item.BusinessReason = reader.IsDBNull(14) ? string.Empty : reader.GetString("businessreason");
                        item.FromDate = reader.GetDateTime("FromDate");
                        item.LastUpdatedBy = reader.GetString("UpdatedBy");
                    }
                    connection.Close();
                }//end command
            }//end connection

            return item;
        }






        private int getCount(string commandName)
        {
            int count = 0;
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    connection.Open();
                    count = Int32.Parse(command.ExecuteScalar().ToString());
                    connection.Close();
                }
            }
            return count;
        }

        private List<EmployeeCategorizationListItem> loadSearchResults(string commandName, string searchCriteria, string orderBy, int pageNumber, int pageSize)
        {
            List<EmployeeCategorizationListItem> items = new List<EmployeeCategorizationListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("searchCriteria", searchCriteria);
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }


        private List<EmployeeCategorizationListItem> loadSearchResults(string commandName, string searchCriteria, string orderBy, int orgId, int pageNumber, int pageSize)
        {
            List<EmployeeCategorizationListItem> items = new List<EmployeeCategorizationListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("searchCriteria", searchCriteria);
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("userOrgId", orgId);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }

        private List<EmployeeCategorizationListItem> loadData(string commandName, string orderBy, int pageNumber, int pageSize)
        {
            List<EmployeeCategorizationListItem> items = new List<EmployeeCategorizationListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }

        private List<EmployeeCategorizationListItem> loadData(string commandName, string orderBy, int pageNumber, int pageSize, int userOrgId)
        {
            List<EmployeeCategorizationListItem> items = new List<EmployeeCategorizationListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    command.Parameters.AddWithValue("userOrgId", userOrgId);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }


        private List<EmployeeCategorizationChaseListItem> loadChaseListSearchResults(string commandName, string searchCriteria, string orderBy, int orgId, int pageNumber, int pageSize = defaultPageSize)
        {
            List<EmployeeCategorizationChaseListItem> items = new List<EmployeeCategorizationChaseListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("userOrgId", orgId);
                    command.Parameters.AddWithValue("searchCriteria", searchCriteria);
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadChaseItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }

        private List<EmployeeCategorizationChaseListItem> loadChaseListSearchResults(string commandName, string searchCriteria, string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            List<EmployeeCategorizationChaseListItem> items = new List<EmployeeCategorizationChaseListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("searchCriteria", searchCriteria);
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadChaseItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }

        private List<EmployeeCategorizationChaseListItem> loadChaseData(string commandName, string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            List<EmployeeCategorizationChaseListItem> items = new List<EmployeeCategorizationChaseListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadChaseItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }

        private List<EmployeeCategorizationChaseListItem> loadChaseData(string commandName, string orderBy, int pageNumber, int pageSize, int userOrgId)
        {
            List<EmployeeCategorizationChaseListItem> items = new List<EmployeeCategorizationChaseListItem>();
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand(commandName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("orderBy", orderBy);
                    command.Parameters.AddWithValue("pageNumber", pageNumber);
                    command.Parameters.AddWithValue("pageSize", pageSize);
                    command.Parameters.AddWithValue("userOrgId", userOrgId);
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();
                    items = loadChaseItems(dataReader);
                    connection.Close();
                }
            }
            return items;
        }


        private List<EmployeeCategorizationListItem> loadItems(MySqlDataReader dataReader)
        {
            List<EmployeeCategorizationListItem> items = new List<EmployeeCategorizationListItem>();
            while (dataReader.Read())
            {
                EmployeeCategorizationListItem item = new EmployeeCategorizationListItem();
                item.Id = dataReader.GetInt32("ID");
                item.EmplId = dataReader.GetString("EmplId");
                item.Employee = dataReader.GetString("Employee");
                item.DepartmentId = dataReader.GetString("DepartmentId");
                item.AgencySubElement = dataReader.GetString("AgencySubElement");
                item.PersonnelOfficeId = int.Parse(dataReader.GetString("PersonnelOfficeIdentifier"));
                item.PersonnelOfficeLabel = dataReader.GetString("personnelofficelabel");
                item.ReportedOnPositionNumber = dataReader.GetString("ReportedOnPositionNumber");
                item.Categorization = dataReader.GetString("PositionCategoryLabel");
                item.FromDate = dataReader.GetDateTime("FromDate");
                items.Add(item);
            }
            return items;
        }

        //EmployeeCategorizationChaseListItem
        private List<EmployeeCategorizationChaseListItem> loadChaseItems(MySqlDataReader dataReader)
        {
            List<EmployeeCategorizationChaseListItem> items = new List<EmployeeCategorizationChaseListItem>();
            while (dataReader.Read())
            {
                EmployeeCategorizationChaseListItem item = new EmployeeCategorizationChaseListItem();
                item.Id = dataReader.GetInt32("ID");
                item.EmplId = dataReader.GetString("EmplId");
                item.Employee = dataReader.GetString("Employee");
                item.DepartmentId = dataReader.GetString("DepartmentId");
                item.AgencySubElement = dataReader.GetString("AgencySubElement");
                item.PersonnelOfficeId = dataReader.GetInt32("PersonnelOfficeId").ToString();
                item.PersonnelOfficeLabel = dataReader.GetString("PersonnelOfficeLabel");
                item.ReportedOnPositionNumber = dataReader.GetString("ReportedOnPositionNumber");
                item.CurrentPositionNumber = dataReader.GetString("CurrentPositionNumber");
                item.PositionCategoryId = dataReader.GetInt32("PositionCategoryId");
                item.Categorization = dataReader.GetString("Categorization");
                item.FromDate = dataReader.GetDateTime("FromDate");
                item.UpdatedBy = dataReader.GetString("UpdatedBy");
                item.ChaseReason = dataReader.GetString("ChaseReason");
                items.Add(item);
            }
            return items;
        }

        public void Insert(string emplId
                            , string positionNumber
                            , int positionCategoryId
                            , string positionNeedsToBeInLocation
                            , int? EstimatedDaysInOffice
                            , string businessReason
                            , string comments
                            , int userId
                            )
        {
            using (MySqlConnection connection = new MySqlConnection(databaseConnection))
            {
                using (MySqlCommand command = new MySqlCommand("aca.epc_updateEmployeePositionCategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("EmplId_in", emplId);
                    command.Parameters.AddWithValue("Position_Nbr_in", positionNumber);
                    command.Parameters.AddWithValue("PostionCategoryId_in", positionCategoryId);
                    command.Parameters.AddWithValue("PositionNeedsToBeInLocation_in", positionNeedsToBeInLocation);
                    command.Parameters.AddWithValue("EstimatedDaysInOffice_in", EstimatedDaysInOffice);
                    command.Parameters.AddWithValue("BusinessReason_in", businessReason);
                    command.Parameters.AddWithValue("Comments_in", comments);
                    command.Parameters.AddWithValue("UpdatedByUserId_in", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}