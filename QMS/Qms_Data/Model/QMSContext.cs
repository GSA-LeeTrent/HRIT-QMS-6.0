using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QMSContext : DbContext
    {
        public QMSContext()
        {
        }

        public QMSContext(DbContextOptions<QMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EpcEmployeepositioncategorizationlist> EpcEmployeepositioncategorizationlist { get; set; }
        public virtual DbSet<EpcEmployeepositioncategory> EpcEmployeepositioncategory { get; set; }
        public virtual DbSet<EpcEmployeepositiontobevalidated> EpcEmployeepositiontobevalidated { get; set; }
        public virtual DbSet<EpcPositioncategory> EpcPositioncategory { get; set; }
        public virtual DbSet<HrlinksEmployee> HrlinksEmployee { get; set; }
        public virtual DbSet<NtfEmaillog> NtfEmaillog { get; set; }
        public virtual DbSet<NtfNotification> NtfNotification { get; set; }
        public virtual DbSet<NtfNotificationevent> NtfNotificationevent { get; set; }
        public virtual DbSet<NtfNotificationeventtype> NtfNotificationeventtype { get; set; }
        public virtual DbSet<NtfNotificationuserpreference> NtfNotificationuserpreference { get; set; }
        public virtual DbSet<QmsCorrectiveactionErrortype> QmsCorrectiveactionErrortype { get; set; }
        public virtual DbSet<QmsCorrectiveactionrequest> QmsCorrectiveactionrequest { get; set; }
        public virtual DbSet<QmsCorrectiveactiontype> QmsCorrectiveactiontype { get; set; }
        public virtual DbSet<QmsDataItem> QmsDataItem { get; set; }
        public virtual DbSet<QmsDataerror> QmsDataerror { get; set; }
        public virtual DbSet<QmsDataerrortype> QmsDataerrortype { get; set; }
        public virtual DbSet<QmsEmployee> QmsEmployee { get; set; }
        public virtual DbSet<QmsErrorStat> QmsErrorStat { get; set; }
        public virtual DbSet<QmsErrorroutingtype> QmsErrorroutingtype { get; set; }
        public virtual DbSet<QmsErrortype> QmsErrortype { get; set; }
        public virtual DbSet<QmsKnowledgebase> QmsKnowledgebase { get; set; }
        public virtual DbSet<QmsMasterErrorList> QmsMasterErrorList { get; set; }
        public virtual DbSet<QmsNatureofaction> QmsNatureofaction { get; set; }
        public virtual DbSet<QmsOrgStatusTrans> QmsOrgStatusTrans { get; set; }
        public virtual DbSet<QmsOrgtype> QmsOrgtype { get; set; }
        public virtual DbSet<QmsPersonnelOfficeIdentifier> QmsPersonnelOfficeIdentifier { get; set; }
        public virtual DbSet<QmsStatus> QmsStatus { get; set; }
        public virtual DbSet<QmsStatusTrans> QmsStatusTrans { get; set; }
        public virtual DbSet<QmsStfacqError> QmsStfacqError { get; set; }
        public virtual DbSet<QmsWorkitemcomment> QmsWorkitemcomment { get; set; }
        public virtual DbSet<QmsWorkitemfile> QmsWorkitemfile { get; set; }
        public virtual DbSet<QmsWorkitemhistory> QmsWorkitemhistory { get; set; }
        public virtual DbSet<QmsWorkitemtype> QmsWorkitemtype { get; set; }
        public virtual DbSet<QmsWorkitemviewlog> QmsWorkitemviewlog { get; set; }
        public virtual DbSet<SaStaffacquisitionlistitem> SaStaffacquisitionlistitem { get; set; }
        public virtual DbSet<SecOrg> SecOrg { get; set; }
        public virtual DbSet<SecPermission> SecPermission { get; set; }
        public virtual DbSet<SecRole> SecRole { get; set; }
        public virtual DbSet<SecRolePermission> SecRolePermission { get; set; }
        public virtual DbSet<SecSecurityitemtype> SecSecurityitemtype { get; set; }
        public virtual DbSet<SecSecuritylog> SecSecuritylog { get; set; }
        public virtual DbSet<SecSecuritylogtype> SecSecuritylogtype { get; set; }
        public virtual DbSet<SecUser> SecUser { get; set; }
        public virtual DbSet<SecUserRole> SecUserRole { get; set; }
        public virtual DbSet<SecUserlogin> SecUserlogin { get; set; }
        public virtual DbSet<StfacqSysUser> StfacqSysUser { get; set; }
        public virtual DbSet<SysMenuitem> SysMenuitem { get; set; }
        public virtual DbSet<SysModule> SysModule { get; set; }
        public virtual DbSet<SysModuleRole> SysModuleRole { get; set; }
        public virtual DbSet<SysProcessLog> SysProcessLog { get; set; }
        public virtual DbSet<SysReport> SysReport { get; set; }
        public virtual DbSet<SysSetting> SysSetting { get; set; }
        public virtual DbSet<SysSettingtype> SysSettingtype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Config.Settings.ReconDB, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.37-mysql"));
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpcEmployeepositioncategorizationlist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("epc_employeepositioncategorizationlist");

                entity.Property(e => e.AgencySubElement)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Businessreason)
                    .HasColumnName("businessreason")
                    .HasColumnType("varchar(700)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(700)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CurrentPositionNumber)
                    .HasColumnType("varchar(8)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmplId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Employee)
                    .HasColumnType("varchar(93)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EstimatedDaysInOffice).HasColumnType("tinyint(2)");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(10)");

                entity.Property(e => e.PersonnelOfficeIdentifier)
                    .HasColumnType("varchar(4)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Personnelofficelabel)
                    .IsRequired()
                    .HasColumnName("personnelofficelabel")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionCategoryId).HasColumnType("int(10)");

                entity.Property(e => e.PositionCategoryLabel)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionNeedsToBeInLocation)
                    .HasColumnType("varchar(1)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ReportedOnPositionNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<EpcEmployeepositioncategory>(entity =>
            {
                entity.HasKey(e => e.EmployedPositionCategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("epc_employeepositioncategory");

                entity.HasIndex(e => e.PositionCategoryId)
                    .HasDatabaseName("employeepositioncategory_posncat_fk");

                entity.HasIndex(e => e.UpdatedByUserId)
                    .HasDatabaseName("employeepositioncategory_user_fk");

                entity.HasIndex(e => new { e.EmplId, e.FromDate })
                    .HasDatabaseName("EmplId");

                entity.HasIndex(e => new { e.PositionNbr, e.FromDate })
                    .HasDatabaseName("Position_Nbr");

                entity.HasIndex(e => new { e.EmplId, e.PositionNbr, e.FromDate })
                    .HasDatabaseName("EmplId_2");

                entity.Property(e => e.EmployedPositionCategoryId).HasColumnType("int(10)");

                entity.Property(e => e.BusinessReason)
                    .HasColumnType("varchar(700)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Comments)
                    .HasColumnType("varchar(700)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmplId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EstimatedDaysInOffice).HasColumnType("tinyint(2)");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.PositionCategoryId)
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'4'");

                entity.Property(e => e.PositionNbr)
                    .IsRequired()
                    .HasColumnName("Position_Nbr")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionNeedsToBeInLocation)
                    .HasColumnType("varchar(1)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UpdatedByUserId).HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.EpcEmployeepositioncategory)
                    .HasForeignKey(d => d.EmplId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("epc_employeepositioncategory_ibfk_1");

                entity.HasOne(d => d.PositionCategory)
                    .WithMany(p => p.EpcEmployeepositioncategory)
                    .HasForeignKey(d => d.PositionCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("epc_employeepositioncategory_ibfk_2");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.EpcEmployeepositioncategory)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("epc_employeepositioncategory_ibfk_3");
            });

            modelBuilder.Entity<EpcEmployeepositiontobevalidated>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("epc_employeepositiontobevalidated");

                entity.Property(e => e.AgencySubElement)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Categorization)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ChaseReason)
                    .IsRequired()
                    .HasColumnType("varchar(33)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.CurrentPositionNumber)
                    .HasColumnType("varchar(8)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmplId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Employee)
                    .HasColumnType("varchar(93)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.PersonnelOfficeId).HasColumnType("int(4)");

                entity.Property(e => e.PersonnelOfficeLabel)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionCategoryId)
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'4'");

                entity.Property(e => e.ReportedOnPositionNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedByUserId).HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<EpcPositioncategory>(entity =>
            {
                entity.HasKey(e => e.PositionCategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("epc_positioncategory");

                entity.Property(e => e.PositionCategoryId).HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.PositionCategoryCode)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionCategoryLabel)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<HrlinksEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("hrlinks_employee");

                entity.Property(e => e.AgencySubElement)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnType("varchar(70)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmplId)
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnType("varchar(3)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ManagerId)
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PayPlan)
                    .IsRequired()
                    .HasColumnType("varchar(2)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PersonnelOfficeIdentifier)
                    .IsRequired()
                    .HasColumnType("varchar(4)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionNbr)
                    .HasColumnName("Position_Nbr")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Userkey)
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<NtfEmaillog>(entity =>
            {
                entity.HasKey(e => e.EmailLogId)
                    .HasName("PRIMARY");

                entity.ToTable("ntf_emaillog");

                entity.HasIndex(e => e.SentDate)
                    .HasDatabaseName("ntf_emaillog_uc")
                    .IsUnique();

                entity.Property(e => e.EmailLogId).HasColumnType("int(10)");

                entity.Property(e => e.SentAmount).HasColumnType("int(10)");

                entity.Property(e => e.SentDate)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<NtfNotification>(entity =>
            {
                entity.HasKey(e => e.NotificationId)
                    .HasName("PRIMARY");

                entity.ToTable("ntf_notification");

                entity.HasIndex(e => e.NotificationEventId)
                    .HasDatabaseName("ntf_Notification_notificationEvent_fk");

                entity.HasIndex(e => e.UserId)
                    .HasDatabaseName("ntf_Notification_secuser_fk");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("qms_notification_workItemType_fk");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("Notification_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Hasbeenread)
                    .HasColumnName("hasbeenread")
                    .HasColumnType("tinyint(2)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("varchar(2500)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.NotificationEventId)
                    .HasColumnName("NotificationEvent_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ReadAt).HasColumnType("datetime");

                entity.Property(e => e.Sendasemail)
                    .HasColumnName("sendasemail")
                    .HasColumnType("tinyint(2)");

                entity.Property(e => e.SentAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.WorkItemTypeCode)
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.WorkitemId)
                    .HasColumnName("workitem_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.NtfNotification)
                    .HasForeignKey(d => d.NotificationEventId)
                    .HasConstraintName("ntf_Notification_notificationEvent_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NtfNotification)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ntf_Notification_secuser_fk");

                entity.HasOne(d => d.WorkItemTypeCodeNavigation)
                    .WithMany(p => p.NtfNotification)
                    .HasPrincipalKey(p => p.WorkItemTypeCode)
                    .HasForeignKey(d => d.WorkItemTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_notification_workItemType_fk");
            });

            modelBuilder.Entity<NtfNotificationevent>(entity =>
            {
                entity.HasKey(e => e.NotificationEventId)
                    .HasName("PRIMARY");

                entity.ToTable("ntf_notificationevent");

                entity.HasIndex(e => e.NotificationEventTypeId)
                    .HasDatabaseName("ntf_NotificationEvent_notificationEventType_fk");

                entity.Property(e => e.NotificationEventId)
                    .HasColumnName("NotificationEvent_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.MessageTemplate)
                    .HasColumnType("varchar(2000)")
                    .HasDefaultValueSql("'Corrective Acton ID: {0}<br/>Updated on: {1}<br/>Employee: {2}-{3}'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.NotificationEventCode)
                    .IsRequired()
                    .HasColumnName("NotificationEvent_Code")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.NotificationEventLabel)
                    .IsRequired()
                    .HasColumnName("NotificationEvent_Label")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.NotificationEventTypeId)
                    .HasColumnName("NotificationEventType_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.TitleTemplate)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'HRQMS - Corrective Action {0} ({1})'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.NotificationEventType)
                    .WithMany(p => p.NtfNotificationevent)
                    .HasForeignKey(d => d.NotificationEventTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ntf_NotificationEvent_notificationEventType_fk");
            });

            modelBuilder.Entity<NtfNotificationeventtype>(entity =>
            {
                entity.HasKey(e => e.NotificationEventTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("ntf_notificationeventtype");

                entity.Property(e => e.NotificationEventTypeId)
                    .HasColumnName("NotificationEventType_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.NotificationEventTypeCode)
                    .IsRequired()
                    .HasColumnName("NotificationEventType_Code")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.NotificationEventTypeLabel)
                    .IsRequired()
                    .HasColumnName("NotificationEventType_Label")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<NtfNotificationuserpreference>(entity =>
            {
                entity.HasKey(e => e.NotificationUserPreferenceId)
                    .HasName("PRIMARY");

                entity.ToTable("ntf_notificationuserpreference");

                entity.HasIndex(e => e.NotificationEventId)
                    .HasDatabaseName("ntf_NotificationUserPreference_notificationEvent_fk");

                entity.HasIndex(e => e.UserId)
                    .HasDatabaseName("ntf_NotificationUserPreference_secuser_fk");

                entity.Property(e => e.NotificationUserPreferenceId)
                    .HasColumnName("NotificationUserPreference_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MessageDeliveryIsOn)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NotificationEventId)
                    .HasColumnName("NotificationEvent_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.NtfNotificationuserpreference)
                    .HasForeignKey(d => d.NotificationEventId)
                    .HasConstraintName("ntf_NotificationUserPreference_notificationEvent_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NtfNotificationuserpreference)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ntf_NotificationUserPreference_secuser_fk");
            });

            modelBuilder.Entity<QmsCorrectiveactionErrortype>(entity =>
            {
                entity.ToTable("qms_correctiveaction_errortype");

                entity.HasIndex(e => e.CorrectiveActionId)
                    .HasDatabaseName("qms_correctiveaction_car_fk");

                entity.HasIndex(e => e.ErrorTypeId)
                    .HasDatabaseName("qms_correctiveaction_error_fk");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.CorrectiveActionId).HasColumnType("int(10)");

                entity.Property(e => e.ErrorTypeId).HasColumnType("int(10)");

                entity.HasOne(d => d.CorrectiveAction)
                    .WithMany(p => p.QmsCorrectiveactionErrortype)
                    .HasForeignKey(d => d.CorrectiveActionId)
                    .HasConstraintName("qms_correctiveaction_car_fk");

                entity.HasOne(d => d.ErrorType)
                    .WithMany(p => p.QmsCorrectiveactionErrortype)
                    .HasForeignKey(d => d.ErrorTypeId)
                    .HasConstraintName("qms_correctiveaction_error_fk");
            });

            modelBuilder.Entity<QmsCorrectiveactionrequest>(entity =>
            {
                entity.ToTable("qms_correctiveactionrequest");

                entity.HasIndex(e => e.ActionRequestTypeId)
                    .HasDatabaseName("qms_correctiveaction_requestype_fk");

                entity.HasIndex(e => e.AssignedByUserId)
                    .HasDatabaseName("qms_correctiveactionrequest_assigner_fk");

                entity.HasIndex(e => e.AssignedToOrgId)
                    .HasDatabaseName("qms_correctiveactionrequest_org_fk");

                entity.HasIndex(e => e.AssignedToUserId)
                    .HasDatabaseName("qms_correctiveactionrequest_assignee_fk");

                entity.HasIndex(e => e.CreatedAtOrgId)
                    .HasDatabaseName("qms_correctiveactionrequest_createdatorg_fk");

                entity.HasIndex(e => e.CreatedByUserId)
                    .HasDatabaseName("qms_correctiveactionrequest_createdbyuser_fk");

                entity.HasIndex(e => e.EmplId)
                    .HasDatabaseName("qms_correctiveactionrequest_employee_fk");

                entity.HasIndex(e => e.NatureOfAction)
                    .HasDatabaseName("qms_correctiveaction_noa_fk");

                entity.HasIndex(e => e.StatusId)
                    .HasDatabaseName("qms_correctiveactionrequest_status_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ActionRequestTypeId).HasColumnType("int(10)");

                entity.Property(e => e.AssignedByUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToOrgId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Assignedat)
                    .HasColumnName("assignedat")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAtOrgId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedByUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Deletedat)
                    .HasColumnName("deletedat")
                    .HasColumnType("date");

                entity.Property(e => e.Details)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EffectiveDateOfPar)
                    .HasColumnName("EffectiveDateOfPAR")
                    .HasColumnType("date");

                entity.Property(e => e.EmplId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.IsPaymentMismatch)
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.NatureOfAction)
                    .HasColumnType("varchar(3)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PareffectiveDate)
                    .HasColumnName("PAREffectiveDate")
                    .HasColumnType("date");

                entity.Property(e => e.Resolvedat)
                    .HasColumnName("resolvedat")
                    .HasColumnType("date");

                entity.Property(e => e.RowVersion).HasColumnType("tinyint(2)");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SubmittedAt).HasColumnType("datetime");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasColumnType("date");

                entity.HasOne(d => d.ActionRequestType)
                    .WithMany(p => p.QmsCorrectiveactionrequest)
                    .HasForeignKey(d => d.ActionRequestTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_correctiveaction_requestype_fk");

                entity.HasOne(d => d.AssignedByUser)
                    .WithMany(p => p.QmsCorrectiveactionrequestAssignedByUser)
                    .HasForeignKey(d => d.AssignedByUserId)
                    .HasConstraintName("qms_correctiveactionrequest_assigner_fk");

                entity.HasOne(d => d.AssignedToOrg)
                    .WithMany(p => p.QmsCorrectiveactionrequestAssignedToOrg)
                    .HasForeignKey(d => d.AssignedToOrgId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_correctiveactionrequest_org_fk");

                entity.HasOne(d => d.AssignedToUser)
                    .WithMany(p => p.QmsCorrectiveactionrequestAssignedToUser)
                    .HasForeignKey(d => d.AssignedToUserId)
                    .HasConstraintName("qms_correctiveactionrequest_assignee_fk");

                entity.HasOne(d => d.CreatedAtOrg)
                    .WithMany(p => p.QmsCorrectiveactionrequestCreatedAtOrg)
                    .HasForeignKey(d => d.CreatedAtOrgId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_correctiveactionrequest_createdatorg_fk");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.QmsCorrectiveactionrequestCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("qms_correctiveactionrequest_createdbyuser_fk");

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.QmsCorrectiveactionrequest)
                    .HasForeignKey(d => d.EmplId)
                    .HasConstraintName("qms_correctiveactionrequest_employee_fk");

                entity.HasOne(d => d.NatureOfActionNavigation)
                    .WithMany(p => p.QmsCorrectiveactionrequest)
                    .HasForeignKey(d => d.NatureOfAction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_correctiveaction_noa_fk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.QmsCorrectiveactionrequest)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_correctiveactionrequest_status_fk");
            });

            modelBuilder.Entity<QmsCorrectiveactiontype>(entity =>
            {
                entity.ToTable("qms_correctiveactiontype");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<QmsDataItem>(entity =>
            {
                entity.HasKey(e => e.DataItemId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_data_item");

                entity.Property(e => e.DataItemId)
                    .HasColumnName("data_item_Id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataItemCategory)
                    .IsRequired()
                    .HasColumnName("data_item_category")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DataItemName)
                    .IsRequired()
                    .HasColumnName("data_item_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasColumnName("system_name")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<QmsDataerror>(entity =>
            {
                entity.HasKey(e => e.DataErrorId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_dataerror");

                entity.HasIndex(e => e.AssignedByUserId)
                    .HasDatabaseName("qms_DataError_AssignedByUser_fk");

                entity.HasIndex(e => e.AssignedToOrgId)
                    .HasDatabaseName("qms_DataError_AssignedToOrganization_fk");

                entity.HasIndex(e => e.AssignedToUserId)
                    .HasDatabaseName("qms_DataError_AssignedToUser_fk");

                entity.HasIndex(e => e.CorrectiveActionId)
                    .HasDatabaseName("qms_DataError_car_fk");

                entity.HasIndex(e => e.CreatedByOrgId)
                    .HasDatabaseName("qms_DataError_CreatedByOrganization_fk");

                entity.HasIndex(e => e.CreatedByUserId)
                    .HasDatabaseName("qms_DataError_CreatedByUser_fk");

                entity.HasIndex(e => e.DataErrorKey)
                    .HasDatabaseName("qms_DataErrorKey_ix");

                entity.HasIndex(e => e.Emplid)
                    .HasDatabaseName("qms_DataError_employee_fk");

                entity.HasIndex(e => e.ErrorListId)
                    .HasDatabaseName("qms_DataError_errorlist_fk");

                entity.HasIndex(e => e.StatusId)
                    .HasDatabaseName("qms_DataError_status_fk");

                entity.Property(e => e.DataErrorId)
                    .HasColumnName("DataError_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.AssignedAt)
                    .HasColumnName("Assigned_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssignedByUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToOrgId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToUserId)
                    .HasColumnName("AssignedToUserID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CorrectiveActionId)
                    .HasColumnName("correctiveActionId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedByOrgId)
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedByUserId)
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DataErrorKey)
                    .IsRequired()
                    .HasColumnName("DataError_Key")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Emplid)
                    .IsRequired()
                    .HasColumnName("emplid")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorListId)
                    .HasColumnName("error_list_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.QmsErrorCode)
                    .IsRequired()
                    .HasColumnName("qms_error_code")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsErrorMessageText)
                    .HasColumnName("qms_error_message_text")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ResolvedAt)
                    .HasColumnName("resolved_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SubmittedAt)
                    .HasColumnName("submitted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AssignedByUser)
                    .WithMany(p => p.QmsDataerrorAssignedByUser)
                    .HasForeignKey(d => d.AssignedByUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_DataError_AssignedByUser_fk");

                entity.HasOne(d => d.AssignedToOrg)
                    .WithMany(p => p.QmsDataerrorAssignedToOrg)
                    .HasForeignKey(d => d.AssignedToOrgId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_DataError_AssignedToOrganization_fk");

                entity.HasOne(d => d.AssignedToUser)
                    .WithMany(p => p.QmsDataerrorAssignedToUser)
                    .HasForeignKey(d => d.AssignedToUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_DataError_AssignedToUser_fk");

                entity.HasOne(d => d.CorrectiveAction)
                    .WithMany(p => p.QmsDataerror)
                    .HasForeignKey(d => d.CorrectiveActionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_DataError_car_fk");

                entity.HasOne(d => d.CreatedByOrg)
                    .WithMany(p => p.QmsDataerrorCreatedByOrg)
                    .HasForeignKey(d => d.CreatedByOrgId)
                    .HasConstraintName("qms_DataError_CreatedByOrganization_fk");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.QmsDataerrorCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_DataError_CreatedByUser_fk");

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.QmsDataerror)
                    .HasForeignKey(d => d.Emplid)
                    .HasConstraintName("qms_DataError_employee_fk");

                entity.HasOne(d => d.ErrorList)
                    .WithMany(p => p.QmsDataerror)
                    .HasForeignKey(d => d.ErrorListId)
                    .HasConstraintName("qms_DataError_errorlist_fk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.QmsDataerror)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_DataError_status_fk");
            });

            modelBuilder.Entity<QmsDataerrortype>(entity =>
            {
                entity.HasKey(e => e.DataRoutingTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_dataerrortype");

                entity.Property(e => e.DataRoutingTypeId)
                    .HasColumnName("dataRoutingType_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRoutingTypeCode)
                    .IsRequired()
                    .HasColumnName("dataRoutingType_Code")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DataRoutingTypeLabel)
                    .IsRequired()
                    .HasColumnName("dataRoutingType_Label")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<QmsEmployee>(entity =>
            {
                entity.HasKey(e => e.EmplId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_employee");

                entity.HasIndex(e => e.ManagerId)
                    .HasDatabaseName("idx_qms_employee_ManagerId");

                entity.Property(e => e.EmplId)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.AgencySubElement)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(70)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Grade)
                    .HasColumnType("varchar(2)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ManagerId)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.MiddleName)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PayPlan)
                    .HasColumnType("varchar(2)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PersonnelOfficeIdentifier)
                    .HasColumnType("varchar(4)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PositionNbr)
                    .HasColumnName("Position_Nbr")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserKey)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'--'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<QmsErrorStat>(entity =>
            {
                entity.HasKey(e => e.QmsErrorStat1)
                    .HasName("PRIMARY");

                entity.ToTable("qms_error_stat");

                entity.HasIndex(e => new { e.Poid, e.ErrorCode, e.SnapshotDate })
                    .HasDatabaseName("qms_error_status");

                entity.Property(e => e.QmsErrorStat1)
                    .HasColumnName("qms_error_stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ErrorCode)
                    .IsRequired()
                    .HasColumnName("error_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorCount)
                    .HasColumnName("error_count")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Poid)
                    .IsRequired()
                    .HasColumnName("poid")
                    .HasColumnType("varchar(4)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SnapshotDate)
                    .HasColumnName("snapshot_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<QmsErrorroutingtype>(entity =>
            {
                entity.HasKey(e => e.ErrorRoutingTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_errorroutingtype");

                entity.Property(e => e.ErrorRoutingTypeId)
                    .HasColumnName("errorRoutingType_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorRoutingTypeCode)
                    .IsRequired()
                    .HasColumnName("errorRoutingType_Code")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorRoutingTypeLabel)
                    .IsRequired()
                    .HasColumnName("errorRoutingType_Label")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<QmsErrortype>(entity =>
            {
                entity.ToTable("qms_errortype");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DisplayOrder).HasColumnType("tinyint(4)");

                entity.Property(e => e.RoutesToBr)
                    .IsRequired()
                    .HasColumnName("RoutesToBR")
                    .HasColumnType("varchar(1)")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<QmsKnowledgebase>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_knowledgebase");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CorrectionComplexity)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.ErrorCode)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorDescription)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorType)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Hrsupport)
                    .HasColumnName("HRSupport")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Impact)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Risk)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ShortDescription)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SupportingDocLink)
                    .HasColumnType("varchar(75)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<QmsMasterErrorList>(entity =>
            {
                entity.HasKey(e => e.ErrorListId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_master_error_list");

                entity.HasIndex(e => e.DataItemId)
                    .HasDatabaseName("qms_error_loader_master_DataItem_fk");

                entity.HasIndex(e => e.DataRoutingTypeId)
                    .HasDatabaseName("qms_error_loader_master_DataErrorType_fk");

                entity.HasIndex(e => e.ErrorRoutingTypeId)
                    .HasDatabaseName("qms_error_loader_master_ErrorRoutingType_fk");

                entity.Property(e => e.ErrorListId)
                    .HasColumnName("error_list_id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataItemId)
                    .HasColumnName("data_item_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DataRoutingTypeId)
                    .HasColumnName("dataRoutingTypeId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorMessageText)
                    .IsRequired()
                    .HasColumnName("error_message_text")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorRoutingTypeId)
                    .HasColumnName("errorRoutingTypeId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HrdwDataLoadEnabled)
                    .IsRequired()
                    .HasColumnName("hrdw_data_load_enabled")
                    .HasColumnType("char(1)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsDataLoadEnabled)
                    .IsRequired()
                    .HasColumnName("qms_data_load_enabled")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsErrorCode)
                    .IsRequired()
                    .HasColumnName("qms_error_code")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.DataItem)
                    .WithMany(p => p.QmsMasterErrorList)
                    .HasForeignKey(d => d.DataItemId)
                    .HasConstraintName("qms_error_loader_master_DataItem_fk");

                entity.HasOne(d => d.DataRoutingType)
                    .WithMany(p => p.QmsMasterErrorList)
                    .HasForeignKey(d => d.DataRoutingTypeId)
                    .HasConstraintName("qms_error_loader_master_DataErrorType_fk");

                entity.HasOne(d => d.ErrorRoutingType)
                    .WithMany(p => p.QmsMasterErrorList)
                    .HasForeignKey(d => d.ErrorRoutingTypeId)
                    .HasConstraintName("qms_error_loader_master_ErrorRoutingType_fk");
            });

            modelBuilder.Entity<QmsNatureofaction>(entity =>
            {
                entity.HasKey(e => e.Noacode)
                    .HasName("PRIMARY");

                entity.ToTable("qms_natureofaction");

                entity.Property(e => e.Noacode)
                    .HasColumnName("NOACode")
                    .HasColumnType("varchar(3)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.RoutesToBr)
                    .HasColumnName("RoutesToBR")
                    .HasColumnType("varchar(1)")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ShortDescription)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValidFrom).HasColumnType("date");

                entity.Property(e => e.ValidTo).HasColumnType("date");
            });

            modelBuilder.Entity<QmsOrgStatusTrans>(entity =>
            {
                entity.HasKey(e => e.OrgStatusTransId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_org_status_trans");

                entity.HasIndex(e => e.ToOrgtypeId)
                    .HasDatabaseName("qms_org_status_trans_fk2");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("qms_org_status_trans_workItemType_fk");

                entity.HasIndex(e => new { e.StatusTransId, e.FromOrgId, e.ToOrgtypeId, e.WorkItemTypeCode })
                    .HasDatabaseName("qms_org_status_trans_status_wtk_idx")
                    .IsUnique();

                entity.Property(e => e.OrgStatusTransId)
                    .HasColumnName("org_status_trans_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromOrgId)
                    .HasColumnName("from_org_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.StatusTransId)
                    .HasColumnName("status_trans_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ToOrgtypeId)
                    .HasColumnName("to_orgtype_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.WorkItemTypeCode)
                    .IsRequired()
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'CorrectiveActionRequest'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.StatusTrans)
                    .WithMany(p => p.QmsOrgStatusTrans)
                    .HasForeignKey(d => d.StatusTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qms_org_status_trans_fk1");

                entity.HasOne(d => d.ToOrgtype)
                    .WithMany(p => p.QmsOrgStatusTrans)
                    .HasForeignKey(d => d.ToOrgtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qms_org_status_trans_fk2");

                entity.HasOne(d => d.WorkItemTypeCodeNavigation)
                    .WithMany(p => p.QmsOrgStatusTrans)
                    .HasPrincipalKey(p => p.WorkItemTypeCode)
                    .HasForeignKey(d => d.WorkItemTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qms_org_status_trans_workItemType_fk");
            });

            modelBuilder.Entity<QmsOrgtype>(entity =>
            {
                entity.HasKey(e => e.OrgtypeId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_orgtype");

                entity.HasIndex(e => e.OrgtypeCode)
                    .HasDatabaseName("qms_orgtype_uk2")
                    .IsUnique();

                entity.HasIndex(e => e.OrgtypeLabel)
                    .HasDatabaseName("qms_orgtype_uk1")
                    .IsUnique();

                entity.Property(e => e.OrgtypeId)
                    .HasColumnName("orgtype_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrgtypeCode)
                    .IsRequired()
                    .HasColumnName("orgtype_code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.OrgtypeLabel)
                    .IsRequired()
                    .HasColumnName("orgtype_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<QmsPersonnelOfficeIdentifier>(entity =>
            {
                entity.HasKey(e => e.PoiId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_personnel_office_identifier");

                entity.HasIndex(e => e.OrgId)
                    .HasDatabaseName("qms_poi_org_fk");

                entity.Property(e => e.PoiId)
                    .HasColumnName("poi_Id")
                    .HasColumnType("int(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrgId)
                    .HasColumnName("OrgID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PoiCode)
                    .IsRequired()
                    .HasColumnName("poi_code")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PoiLabel)
                    .IsRequired()
                    .HasColumnName("poi_label")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.QmsPersonnelOfficeIdentifier)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("qms_poi_org_fk");
            });

            modelBuilder.Entity<QmsStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_status");

                entity.HasIndex(e => e.StatusCode)
                    .HasDatabaseName("qms_status_uk1")
                    .IsUnique();

                entity.HasIndex(e => e.StatusLabel)
                    .HasDatabaseName("qms_role_uk2")
                    .IsUnique();

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayOrder)
                    .HasColumnName("display_order")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnName("status_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.StatusLabel)
                    .IsRequired()
                    .HasColumnName("status_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<QmsStatusTrans>(entity =>
            {
                entity.HasKey(e => e.StatusTransId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_status_trans");

                entity.HasIndex(e => e.ToStatusId)
                    .HasDatabaseName("qms_status_trans_fk2");

                entity.HasIndex(e => new { e.FromStatusId, e.ToStatusId })
                    .HasDatabaseName("qms_status_trans_uk1")
                    .IsUnique();

                entity.Property(e => e.StatusTransId)
                    .HasColumnName("status_trans_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromStatusId)
                    .HasColumnName("from_status_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.StatusTransCode)
                    .IsRequired()
                    .HasColumnName("status_trans_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.StatusTransLabel)
                    .IsRequired()
                    .HasColumnName("status_trans_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ToStatusId)
                    .HasColumnName("to_status_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FromStatus)
                    .WithMany(p => p.QmsStatusTransFromStatus)
                    .HasForeignKey(d => d.FromStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qms_status_trans_fk1");

                entity.HasOne(d => d.ToStatus)
                    .WithMany(p => p.QmsStatusTransToStatus)
                    .HasForeignKey(d => d.ToStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qms_status_trans_fk2");
            });

            modelBuilder.Entity<QmsStfacqError>(entity =>
            {
                entity.ToTable("qms_stfacq_error");

                entity.HasIndex(e => e.AssignedByUserId)
                    .HasDatabaseName("qms_stfacq_error_AssignedByUser_fk");

                entity.HasIndex(e => e.AssignedToOrgId)
                    .HasDatabaseName("qms_stfacq_error_AssignedToOrganization_fk");

                entity.HasIndex(e => e.AssignedToUserId)
                    .HasDatabaseName("qms_stfacq_error_AssignedToUser_fk");

                entity.HasIndex(e => e.CreatedByUserId)
                    .HasDatabaseName("qms_stfacq_error_CreatedByUser_fk");

                entity.HasIndex(e => e.DataItemId)
                    .HasDatabaseName("qms_stfacq_error_dataitem_fk");

                entity.HasIndex(e => e.ErrorListId)
                    .HasDatabaseName("qms_stfacq_error_errorlist_fk");

                entity.HasIndex(e => e.QmsKey)
                    .HasDatabaseName("qms_key_uk1");

                entity.HasIndex(e => e.StatusId)
                    .HasDatabaseName("qms_stfacq_error_status_fk");

                entity.Property(e => e.QmsStfacqErrorId)
                    .HasColumnName("qms_stfacq_error_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.AssignedAt)
                    .HasColumnName("assigned_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssignedByUserId)
                    .HasColumnName("assigned_by_user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToOrgId)
                    .HasColumnName("assigned_to_org_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToUserId)
                    .HasColumnName("assigned_to_user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedByUserId)
                    .HasColumnName("created_by_user_id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DataItemId)
                    .HasColumnName("data_item_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorDetails)
                    .IsRequired()
                    .HasColumnName("error_details")
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorListId)
                    .HasColumnName("error_list_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ErrorSummary)
                    .IsRequired()
                    .HasColumnName("error_summary")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsErrorCode)
                    .IsRequired()
                    .HasColumnName("qms_error_code")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsKey)
                    .IsRequired()
                    .HasColumnName("qms_key")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ResolvedAt)
                    .HasColumnName("resolved_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .HasColumnName("row_version")
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShortErrorDescription)
                    .IsRequired()
                    .HasColumnName("short_error_description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SubmittedAt)
                    .HasColumnName("submitted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasColumnName("system_name")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AssignedByUser)
                    .WithMany(p => p.QmsStfacqErrorAssignedByUser)
                    .HasForeignKey(d => d.AssignedByUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_stfacq_error_AssignedByUser_fk");

                entity.HasOne(d => d.AssignedToOrg)
                    .WithMany(p => p.QmsStfacqError)
                    .HasForeignKey(d => d.AssignedToOrgId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_stfacq_error_AssignedToOrganization_fk");

                entity.HasOne(d => d.AssignedToUser)
                    .WithMany(p => p.QmsStfacqErrorAssignedToUser)
                    .HasForeignKey(d => d.AssignedToUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_stfacq_error_AssignedToUser_fk");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.QmsStfacqErrorCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_stfacq_error_CreatedByUser_fk");

                entity.HasOne(d => d.DataItem)
                    .WithMany(p => p.QmsStfacqError)
                    .HasForeignKey(d => d.DataItemId)
                    .HasConstraintName("qms_stfacq_error_dataitem_fk");

                entity.HasOne(d => d.ErrorList)
                    .WithMany(p => p.QmsStfacqError)
                    .HasForeignKey(d => d.ErrorListId)
                    .HasConstraintName("qms_stfacq_error_errorlist_fk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.QmsStfacqError)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_stfacq_error_status_fk");
            });

            modelBuilder.Entity<QmsWorkitemcomment>(entity =>
            {
                entity.ToTable("qms_workitemcomment");

                entity.HasIndex(e => e.AuthorId)
                    .HasDatabaseName("qms_reconworkitemcomment_user_fk");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("qms_workitemcomment_workItemType_fk");

                entity.HasIndex(e => new { e.WorkItemId, e.WorkItemTypeCode })
                    .HasDatabaseName("qms_workitemtypeandid_ix");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AuthorId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deletedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.WorkItemId).HasColumnType("int(11)");

                entity.Property(e => e.WorkItemTypeCode)
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.QmsWorkitemcomment)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("qms_workitemauthor_fk");

                entity.HasOne(d => d.WorkItemTypeCodeNavigation)
                    .WithMany(p => p.QmsWorkitemcomment)
                    .HasPrincipalKey(p => p.WorkItemTypeCode)
                    .HasForeignKey(d => d.WorkItemTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_workitemcomment_workItemType_fk");
            });

            modelBuilder.Entity<QmsWorkitemfile>(entity =>
            {
                entity.ToTable("qms_workitemfile");

                entity.HasIndex(e => e.UploadedByUserId)
                    .HasDatabaseName("qms_workitemfile_uploader_fk");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("qms_workitemfile_workItemType_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedat)
                    .HasColumnName("deletedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Filepath)
                    .IsRequired()
                    .HasColumnName("filepath")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Filetype)
                    .IsRequired()
                    .HasColumnName("filetype")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UploadedByUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.WorkItemId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.WorkItemTypeCode)
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.UploadedByUser)
                    .WithMany(p => p.QmsWorkitemfile)
                    .HasForeignKey(d => d.UploadedByUserId)
                    .HasConstraintName("qms_workitemfile_uploader_fk");

                entity.HasOne(d => d.WorkItemTypeCodeNavigation)
                    .WithMany(p => p.QmsWorkitemfile)
                    .HasPrincipalKey(p => p.WorkItemTypeCode)
                    .HasForeignKey(d => d.WorkItemTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_workitemfile_workItemType_fk");
            });

            modelBuilder.Entity<QmsWorkitemhistory>(entity =>
            {
                entity.ToTable("qms_workitemhistory");

                entity.HasIndex(e => e.ActionTakenByUserId)
                    .HasDatabaseName("qms_WorkItemHistory_secuser_fk");

                entity.HasIndex(e => e.PreviousAssignedByUserId)
                    .HasDatabaseName("qms_WorkItemHistory_assigner_fk");

                entity.HasIndex(e => e.PreviousAssignedToOrgId)
                    .HasDatabaseName("qms_WorkItemHistory_org_fk");

                entity.HasIndex(e => e.PreviousAssignedtoUserId)
                    .HasDatabaseName("qms_WorkItemHistory_assignee_fk");

                entity.HasIndex(e => e.PreviousStatusId)
                    .HasDatabaseName("qms_WorkItemHistory_status_fk_idx");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("qms_workitemhistory_workItemType_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ActionDescription)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ActionTakenByUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PreviousAssignedByUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.PreviousAssignedToOrgId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.PreviousAssignedtoUserId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.PreviousStatusId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.WorkItemId).HasColumnType("int(11)");

                entity.Property(e => e.WorkItemTypeCode)
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.ActionTakenByUser)
                    .WithMany(p => p.QmsWorkitemhistoryActionTakenByUser)
                    .HasForeignKey(d => d.ActionTakenByUserId)
                    .HasConstraintName("qms_WorkItemHistory_secuser_fk");

                entity.HasOne(d => d.PreviousAssignedByUser)
                    .WithMany(p => p.QmsWorkitemhistoryPreviousAssignedByUser)
                    .HasForeignKey(d => d.PreviousAssignedByUserId)
                    .HasConstraintName("qms_WorkItemHistory_assigner_fk");

                entity.HasOne(d => d.PreviousAssignedToOrg)
                    .WithMany(p => p.QmsWorkitemhistory)
                    .HasForeignKey(d => d.PreviousAssignedToOrgId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_WorkItemHistory_org_fk");

                entity.HasOne(d => d.PreviousAssignedtoUser)
                    .WithMany(p => p.QmsWorkitemhistoryPreviousAssignedtoUser)
                    .HasForeignKey(d => d.PreviousAssignedtoUserId)
                    .HasConstraintName("qms_WorkItemHistory_assignee_fk");

                entity.HasOne(d => d.PreviousStatus)
                    .WithMany(p => p.QmsWorkitemhistory)
                    .HasForeignKey(d => d.PreviousStatusId)
                    .HasConstraintName("qms_WorkItemHistory_status_fk");

                entity.HasOne(d => d.WorkItemTypeCodeNavigation)
                    .WithMany(p => p.QmsWorkitemhistory)
                    .HasPrincipalKey(p => p.WorkItemTypeCode)
                    .HasForeignKey(d => d.WorkItemTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_workitemhistory_workItemType_fk");
            });

            modelBuilder.Entity<QmsWorkitemtype>(entity =>
            {
                entity.HasKey(e => e.WorkItemTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("qms_workitemtype");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("WorkItemType_Code")
                    .IsUnique();

                entity.Property(e => e.WorkItemTypeId)
                    .HasColumnName("WorkItemType_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.WorkItemTypeCode)
                    .IsRequired()
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.WorkItemTypeLabel)
                    .IsRequired()
                    .HasColumnName("WorkItemType_Label")
                    .HasColumnType("varchar(75)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<QmsWorkitemviewlog>(entity =>
            {
                entity.ToTable("qms_workitemviewlog");

                entity.HasIndex(e => e.WorkItemTypeCode)
                    .HasDatabaseName("qms_workitemviewlog_workItemType_fk");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(10)");

                entity.Property(e => e.WorkItemTypeCode)
                    .HasColumnName("WorkItemType_Code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Workitemid)
                    .HasColumnName("workitemid")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.WorkItemTypeCodeNavigation)
                    .WithMany(p => p.QmsWorkitemviewlog)
                    .HasPrincipalKey(p => p.WorkItemTypeCode)
                    .HasForeignKey(d => d.WorkItemTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_workitemviewlog_workItemType_fk");
            });

            modelBuilder.Entity<SaStaffacquisitionlistitem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sa_staffacquisitionlistitem");

                entity.Property(e => e.AssignedAt)
                    .HasColumnName("assigned_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssignedByUserId)
                    .HasColumnName("assigned_by_user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedByUserName)
                    .HasColumnName("assigned_by_user_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.AssignedToOrgId)
                    .HasColumnName("assigned_to_org_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToOrgName)
                    .HasColumnName("assigned_to_org_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.AssignedToUserId)
                    .HasColumnName("assigned_to_user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AssignedToUserName)
                    .HasColumnName("assigned_to_user_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorDetails)
                    .IsRequired()
                    .HasColumnName("error_details")
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ErrorSummary)
                    .IsRequired()
                    .HasColumnName("error_summary")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsErrorCode)
                    .IsRequired()
                    .HasColumnName("qms_error_code")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsKey)
                    .IsRequired()
                    .HasColumnName("qms_key")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QmsStfacqErrorId)
                    .HasColumnName("qms_stfacq_error_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ResolvedAt)
                    .HasColumnName("resolved_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .HasColumnName("row_version")
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShortErrorDescription)
                    .IsRequired()
                    .HasColumnName("short_error_description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.StatusDescription)
                    .HasColumnName("status_description")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasColumnName("system_name")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SecOrg>(entity =>
            {
                entity.HasKey(e => e.OrgId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_org");

                entity.HasIndex(e => e.OrgCode)
                    .HasDatabaseName("sec_org_uk1")
                    .IsUnique();

                entity.HasIndex(e => e.OrgLabel)
                    .HasDatabaseName("sec_org_uk2")
                    .IsUnique();

                entity.HasIndex(e => e.ParentOrgId)
                    .HasDatabaseName("sec_org_parentorg_fk");

                entity.Property(e => e.OrgId)
                    .HasColumnName("org_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrgCode)
                    .IsRequired()
                    .HasColumnName("org_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.OrgLabel)
                    .IsRequired()
                    .HasColumnName("org_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.OrgtypeId)
                    .HasColumnName("orgtype_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ParentOrgId)
                    .HasColumnName("parent_org_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ParentOrg)
                    .WithMany(p => p.InverseParentOrg)
                    .HasForeignKey(d => d.ParentOrgId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sec_org_parentorg_fk");
            });

            modelBuilder.Entity<SecPermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_permission");

                entity.HasIndex(e => e.PermissionCode)
                    .HasDatabaseName("sec_permission_uk1")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionLabel)
                    .HasDatabaseName("sec_permission_uk2")
                    .IsUnique();

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PermissionCode)
                    .IsRequired()
                    .HasColumnName("permission_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.PermissionLabel)
                    .IsRequired()
                    .HasColumnName("permission_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SecRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_role");

                entity.HasIndex(e => e.RoleCode)
                    .HasDatabaseName("sec_role_uk1")
                    .IsUnique();

                entity.HasIndex(e => e.RoleLabel)
                    .HasDatabaseName("sec_role_uk2")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleCode)
                    .IsRequired()
                    .HasColumnName("role_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.RoleLabel)
                    .IsRequired()
                    .HasColumnName("role_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SecRolePermission>(entity =>
            {
                entity.HasKey(e => e.RolePermissionId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_role_permission");

                entity.HasIndex(e => e.PermissionId)
                    .HasDatabaseName("sec_role_permission_fk2");

                entity.HasIndex(e => new { e.RoleId, e.PermissionId })
                    .HasDatabaseName("sec_role_permission_uk1")
                    .IsUnique();

                entity.Property(e => e.RolePermissionId)
                    .HasColumnName("role_permission_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.SecRolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sec_role_permission_fk2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SecRolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sec_role_permission_fk1");
            });

            modelBuilder.Entity<SecSecurityitemtype>(entity =>
            {
                entity.HasKey(e => e.SecurityItemTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_securityitemtype");

                entity.Property(e => e.SecurityItemTypeId)
                    .HasColumnName("SecurityItemType_ID")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecurityItemTypeCode)
                    .IsRequired()
                    .HasColumnName("SecurityItemType_Code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SecurityItemTypeLabel)
                    .IsRequired()
                    .HasColumnName("SecurityItemType_Label")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<SecSecuritylog>(entity =>
            {
                entity.HasKey(e => e.SecurityLogId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_securitylog");

                entity.HasIndex(e => e.ActionTakenByUserId)
                    .HasDatabaseName("sec_SecurityLog_User_fk");

                entity.HasIndex(e => e.SecurityLogTypeId)
                    .HasDatabaseName("sec_SecurityLog_SecurityLogType_fk");

                entity.Property(e => e.SecurityLogId)
                    .HasColumnName("SecurityLog_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActionTakenByUserId).HasColumnType("int(11) unsigned");

                entity.Property(e => e.ActiontakenOnItemId).HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SecurityLogTypeId)
                    .HasColumnName("SecurityLogType_ID")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.ActionTakenByUser)
                    .WithMany(p => p.SecSecuritylog)
                    .HasForeignKey(d => d.ActionTakenByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sec_SecurityLog_User_fk");

                entity.HasOne(d => d.SecurityLogType)
                    .WithMany(p => p.SecSecuritylog)
                    .HasForeignKey(d => d.SecurityLogTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sec_SecurityLog_SecurityLogType_fk");
            });

            modelBuilder.Entity<SecSecuritylogtype>(entity =>
            {
                entity.HasKey(e => e.SecurityLogTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_securitylogtype");

                entity.HasIndex(e => e.SecurityItemTypeId)
                    .HasDatabaseName("qms_SecurityLogType_SecurityItemType_fk");

                entity.Property(e => e.SecurityLogTypeId)
                    .HasColumnName("SecurityLogType_ID")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecurityItemTypeId)
                    .HasColumnName("SecurityItemType_ID")
                    .HasColumnType("int(10)");

                entity.Property(e => e.SecurityLogTemplate)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SecurityLogTypeCode)
                    .IsRequired()
                    .HasColumnName("SecurityLogType_Code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SecurityLogTypeLabel)
                    .IsRequired()
                    .HasColumnName("SecurityLogType_Label")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.SecurityItemType)
                    .WithMany(p => p.SecSecuritylogtype)
                    .HasForeignKey(d => d.SecurityItemTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_SecurityLogType_SecurityItemType_fk");
            });

            modelBuilder.Entity<SecUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_user");

                entity.HasIndex(e => e.EmailAddress)
                    .HasDatabaseName("sec_user_uk1")
                    .IsUnique();

                entity.HasIndex(e => e.ManagerId)
                    .HasDatabaseName("sec_user_fk1");

                entity.HasIndex(e => e.OrgId)
                    .HasDatabaseName("sec_user_org_fk_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("email_address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.OrgId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("sec_user_fk1");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("sec_user_org_fk");
            });

            modelBuilder.Entity<SecUserRole>(entity =>
            {
                entity.HasKey(e => e.UserOrgRoleId)
                    .HasName("PRIMARY");

                entity.ToTable("sec_user_role");

                entity.HasIndex(e => e.RoleId)
                    .HasDatabaseName("sec_user_org_role_fk3");

                entity.HasIndex(e => new { e.UserId, e.RoleId })
                    .HasDatabaseName("sec_user_org_role_uk1")
                    .IsUnique();

                entity.Property(e => e.UserOrgRoleId)
                    .HasColumnName("user_org_role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SecUserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sec_user_org_role_fk3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SecUserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sec_user_org_role_fk1");
            });

            modelBuilder.Entity<SecUserlogin>(entity =>
            {
                entity.ToTable("sec_userlogin");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Emailaddress)
                    .IsRequired()
                    .HasColumnName("emailaddress")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.LoginEventType)
                    .IsRequired()
                    .HasColumnName("login_event_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<StfacqSysUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("stfacq_sys_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasColumnName("system_name")
                    .HasColumnType("varchar(4)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UserEmailAddress)
                    .IsRequired()
                    .HasColumnName("user_email_address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasColumnName("user_first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasColumnName("user_last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UserStatus)
                    .IsRequired()
                    .HasColumnName("user_status")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<SysMenuitem>(entity =>
            {
                entity.HasKey(e => e.MenuitemId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_menuitem");

                entity.HasIndex(e => e.ModuleId)
                    .HasDatabaseName("qms_menuitem_module_fk");

                entity.HasIndex(e => e.PermissionId)
                    .HasDatabaseName("permission_id")
                    .IsUnique();

                entity.Property(e => e.MenuitemId)
                    .HasColumnName("menuitem_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasColumnName("action_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasColumnName("controller_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayOrder)
                    .HasColumnName("display_order")
                    .HasColumnType("tinyint(3)");

                entity.Property(e => e.IconOff)
                    .HasColumnName("icon_off")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.IconOn)
                    .HasColumnName("icon_on")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.MenuitemCode)
                    .IsRequired()
                    .HasColumnName("menuitem_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.MenuitemLabel)
                    .IsRequired()
                    .HasColumnName("menuitem_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("module_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.QueryString)
                    .HasColumnName("query_string")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.SysMenuitem)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("qms_menuitem_module_fk");

                entity.HasOne(d => d.Permission)
                    .WithOne(p => p.SysMenuitem)
                    .HasForeignKey<SysMenuitem>(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("qms_menuitem_permission_fk");
            });

            modelBuilder.Entity<SysModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_module");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("module_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasColumnName("action_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasColumnName("controller_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayOrder)
                    .HasColumnName("display_order")
                    .HasColumnType("tinyint(3)");

                entity.Property(e => e.ModuleCode)
                    .IsRequired()
                    .HasColumnName("module_code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ModuleLabel)
                    .IsRequired()
                    .HasColumnName("module_label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.QueryString)
                    .HasColumnName("query_string")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SysModuleRole>(entity =>
            {
                entity.HasKey(e => e.ModuleRoleId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_module_role");

                entity.HasIndex(e => e.ModuleId)
                    .HasDatabaseName("qms_module_moduleid_fk");

                entity.HasIndex(e => e.RoleId)
                    .HasDatabaseName("qms_module_roleid_fk");

                entity.Property(e => e.ModuleRoleId)
                    .HasColumnName("module_role_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("module_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.SysModuleRole)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("qms_module_moduleid_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysModuleRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("qms_module_roleid_fk");
            });

            modelBuilder.Entity<SysProcessLog>(entity =>
            {
                entity.HasKey(e => e.SysId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_process_log");

                entity.Property(e => e.SysId)
                    .HasColumnName("SYS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MigrationCompleted)
                    .HasColumnName("Migration_Completed")
                    .HasColumnType("varchar(1)")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ProcessDate).HasColumnType("date");

                entity.Property(e => e.ProcessDeleteCount).HasColumnType("int(11)");

                entity.Property(e => e.ProcessEnd).HasColumnType("datetime");

                entity.Property(e => e.ProcessId)
                    .HasColumnName("ProcessID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProcessInputCount).HasColumnType("int(11)");

                entity.Property(e => e.ProcessInsertCount).HasColumnType("int(11)");

                entity.Property(e => e.ProcessSource)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ProcessStart).HasColumnType("datetime");

                entity.Property(e => e.ProcessUpdateCount).HasColumnType("int(11)");

                entity.Property(e => e.StagingCompleted)
                    .HasColumnName("Staging_Completed")
                    .HasColumnType("varchar(1)")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<SysReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_report");

                entity.Property(e => e.ReportId)
                    .HasColumnName("report_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasDefaultValueSql("'Y'")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ReportDescription)
                    .IsRequired()
                    .HasColumnName("report_description")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.ViewName)
                    .IsRequired()
                    .HasColumnName("view_name")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<SysSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_setting");

                entity.HasIndex(e => new { e.SettingTypeId, e.Environment })
                    .HasDatabaseName("sys_setting_environment_uc")
                    .IsUnique();

                entity.Property(e => e.SettingId).HasColumnType("int(10)");

                entity.Property(e => e.Environment)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SettingTypeId).HasColumnType("int(10)");

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.SettingType)
                    .WithMany(p => p.SysSetting)
                    .HasForeignKey(d => d.SettingTypeId)
                    .HasConstraintName("qms_setting_settingtype_fk");
            });

            modelBuilder.Entity<SysSettingtype>(entity =>
            {
                entity.HasKey(e => e.SettingTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_settingtype");

                entity.Property(e => e.SettingTypeId).HasColumnType("int(10)");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedat)
                    .HasColumnName("deletedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.SettingCode)
                    .IsRequired()
                    .HasColumnName("Setting_Code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.SettingDescription)
                    .IsRequired()
                    .HasColumnName("Setting_Description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
