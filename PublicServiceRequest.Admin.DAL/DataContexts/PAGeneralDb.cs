namespace PublicServiceRequest.Admin.DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Common.Models;

    public partial class PAGeneralDb : BaseDbContext
    {
        public PAGeneralDb()
            : base("name=PAGeneralDb")
        {
        }

        public virtual DbSet<ApplicationSource> ApplicationSources { get; set; }
        public virtual DbSet<AttachmentType> AttachmentTypes { get; set; }
        public virtual DbSet<CustomFieldDataType> CustomFieldDataTypes { get; set; }
        public virtual DbSet<CustomFieldSelectListItem> CustomFieldSelectListItems { get; set; }
        public virtual DbSet<CustomFieldType> CustomFieldTypes { get; set; }
        public virtual DbSet<RequestActionType> RequestActionTypes { get; set; }
        public virtual DbSet<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }
        public virtual DbSet<RequestFolioType> RequestFolioTypes { get; set; }
        public virtual DbSet<RequestOrigin> RequestOrigins { get; set; }
        public virtual DbSet<RequestPriority> RequestPriorities { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<RequestTaxpayerPreferredLanguage> RequestTaxpayerPreferredLanguages { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<ServiceTypeChildStartTrigger> ServiceTypeChildStartTriggers { get; set; }
        public virtual DbSet<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }
        public virtual DbSet<ServiceTypeOwnerGroup> ServiceTypeOwnerGroups { get; set; }
        public virtual DbSet<ServiceTypeOwnerGroupLocation> ServiceTypeOwnerGroupLocations { get; set; }
        public virtual DbSet<ServiceTypeOwnerGroupMember> ServiceTypeOwnerGroupMembers { get; set; }
        public virtual DbSet<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions { get; set; }
        public virtual DbSet<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }
        public virtual DbSet<ServiceTypeSearchKeyword> ServiceTypeSearchKeywords { get; set; }
        public virtual DbSet<ServiceTypeSearchKeywordLink> ServiceTypeSearchKeywordLinks { get; set; }
        public virtual DbSet<DbObject> DbObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.ApplicationSourceName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AttachmentTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AttachmentDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.CustomFieldDataTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.CustomFieldDataTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.RegularExpression)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.ErrorMessage)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.CustomFieldSelectListItemLabel)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.CustomFieldSelectListItemValue)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.CustomFieldTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.CustomFieldTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .HasMany(e => e.CustomFieldSelectListItems)
                .WithRequired(e => e.CustomFieldType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.RequestActionTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.RequestActionTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.BackgroundColor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.TextColor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .HasMany(e => e.ServiceTypeRequestActionTypeLinks)
                .WithRequired(e => e.RequestActionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.LabelName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.PlaceholderText)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.TextAlignment)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.TooltipMessage)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.GroupingIdentifier1)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.GroupingIdentifier2)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.RequestFolioTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.RequestFoliotypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.RequestOriginName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.RequestOriginDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AutoSelectedForActiveDirectoryGroup)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.RequestPriorityName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.RequestPriorityDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.RequestStatusName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.RequestStatusDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.RequestStatusColor)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.ServiceTypes)
                .WithOptional(e => e.RequestStatusDefault)
                .HasForeignKey(e => e.DefaultRequestStatusID);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.ServiceTypes1)
                .WithOptional(e => e.RequestStatusEscalation)
                .HasForeignKey(e => e.EscalationExpectedStatusID);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.RequestTaxpayerPreferredLanguageName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.RequestTaxpayerPreferredLanguageDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.RequestTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.RequestTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeOwnerGroupOverrideMonthDayFrom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeOwnerGroupOverrideMonthDayTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeAvailableToActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.AttachmentTypes)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.ServiceTypeRelationshipDefinitions)
                .WithOptional(e => e.ServiceType)
                .HasForeignKey(e => e.ServiceTypeParentID);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.ServiceTypeRelationshipDefinitions1)
                .WithOptional(e => e.ServiceType1)
                .HasForeignKey(e => e.ServiceTypeChildID);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.ServiceTypeRequestActionTypeLinks)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.ServiceTypeChildStartTriggerName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.LabelName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.PlaceholderText)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.TextAlignment)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.TooltipMessage)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.GroupingIdentifier1)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.GroupingIdentifier2)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerAvailableToActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupMainEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupNotificationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupEscalationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupPhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .HasMany(e => e.ServiceTypes)
                .WithOptional(e => e.ServiceTypeOwnerGroup)
                .HasForeignKey(e => e.ServiceTypeOwnerGroupID);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .HasMany(e => e.ServiceTypes1)
                .WithOptional(e => e.ServiceTypeOwnerGroupOverride)
                .HasForeignKey(e => e.ServiceTypeOwnerGroupOverrideID);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.ServiceTypeOwnerGroupLocationName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AddActionActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.UpdateActionActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.DeleteActionActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.PrecedenceConstraintRequestActionTypeIDValue)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.ServiceTypeSearchKeywordName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<DbObject>()
                .Property(e => e.TableSchema)
                .IsUnicode(false);

            modelBuilder.Entity<DbObject>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<DbObject>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<DbObject>()
                .Property(e => e.DataType)
                .IsUnicode(false);

            modelBuilder.Entity<DbObject>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DbObject>()
                .Property(e => e.Tooltip)
                .IsUnicode(false);
        }
    }
}
