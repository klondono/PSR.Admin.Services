[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PublicServiceRequest.Admin.Service.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PublicServiceRequest.Admin.Service.App_Start.NinjectWebCommon), "Stop")]

namespace PublicServiceRequest.Admin.Service.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using BLL.Repositories.Interface;
    using DAL.Repositories.Implementation;
    using BLL.Models;
    using System.Web.Http;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(ServiceTypeCustomFieldBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeOwnerGroupBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeOwnerGroupLocationBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeOwnerGroupMemberBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeRelationshipDefinitionBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeRequestActionTypeLinkBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ApplicationSourceBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeSearchKeywordBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(AttachmentTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeSearchKeywordLinkBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(CustomFieldDataTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(CustomFieldSelectListItemBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(CustomFieldTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestActionTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestActionTypeCustomFieldBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestFolioTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestOriginBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestPriorityBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestStatusBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestTaxpayerPreferredLanguageBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(RequestTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(ServiceTypeChildStartTriggerBLL)).ToSelf().InRequestScope();
            kernel.Bind(typeof(DbObjectBLL)).ToSelf().InRequestScope();

            kernel.Bind(typeof(IServiceTypeCustomFieldsRepository)).To(typeof(ServiceTypeCustomFieldsRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeOwnerGroupsRepository)).To(typeof(ServiceTypeOwnerGroupsRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeOwnerGroupLocationsRepository)).To(typeof(ServiceTypeOwnerGroupLocationsRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeOwnerGroupMembersRepository)).To(typeof(ServiceTypeOwnerGroupMembersRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeRelationshipDefinitionsRepository)).To(typeof(ServiceTypeRelationshipDefinitionsRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeRequestActionTypeLinksRepository)).To(typeof(ServiceTypeRequestActionTypeLinksRepository)).InRequestScope();
            kernel.Bind(typeof(IApplicationSourcesRepository)).To(typeof(ApplicationSourcesRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeSearchKeywordsRepository)).To(typeof(ServiceTypeSearchKeywordsRepository)).InRequestScope();
            kernel.Bind(typeof(IAttachmentTypesRepository)).To(typeof(AttachmentTypesRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeSearchKeywordLinksRepository)).To(typeof(ServiceTypeSearchKeywordLinksRepository)).InRequestScope();
            kernel.Bind(typeof(ICustomFieldDataTypesRepository)).To(typeof(CustomFieldDataTypesRepository)).InRequestScope();
            kernel.Bind(typeof(ICustomFieldSelectListItemsRepository)).To(typeof(CustomFieldSelectListItemsRepository)).InRequestScope();
            kernel.Bind(typeof(ICustomFieldTypesRepository)).To(typeof(CustomFieldTypesRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestActionTypesRepository)).To(typeof(RequestActionTypesRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestActionTypeCustomFieldsRepository)).To(typeof(RequestActionTypeCustomFieldsRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestFolioTypesRepository)).To(typeof(RequestFolioTypesRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestOriginsRepository)).To(typeof(RequestOriginsRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestPrioritiesRepository)).To(typeof(RequestPrioritiesRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestStatusesRepository)).To(typeof(RequestStatusesRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestTaxpayerPreferredLanguagesRepository)).To(typeof(RequestTaxpayerPreferredLanguagesRepository)).InRequestScope();
            kernel.Bind(typeof(IRequestTypesRepository)).To(typeof(RequestTypesRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypesRepository)).To(typeof(ServiceTypesRepository)).InRequestScope();
            kernel.Bind(typeof(IServiceTypeChildStartTriggersRepository)).To(typeof(ServiceTypeChildStartTriggersRepository)).InRequestScope();
            kernel.Bind(typeof(IDbObjectsRepository)).To(typeof(DbObjectsRepository)).InRequestScope();
        }        
    }
}
