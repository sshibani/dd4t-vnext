using DD4T.ContentModel.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Utils
{
    public class DD4TConfiguration
    {

        public int PublicationId { get; set; }

        private string defaultPage = "index.html";
        public string DefaultPage
        {
            get
            {
                return defaultPage;
            }

            set
            {
                defaultPage = value;
            }
        }

        private ProviderVersion providerVersion = ProviderVersion.Tridion2013sp1;
        public ProviderVersion ProviderVersion
        {
            get
            {
                return providerVersion;
            }

            set
            {
                providerVersion = value;
            }
        }

        private string sessionPreviewClaimId = "taf:session:preview:preview_session";
        public string SessionPreviewClaimId
        {
            get
            {
                return sessionPreviewClaimId;
            }

        }

        private bool includeLastPublishedDate = false;
        public bool IncludeLastPublishedDate
        {
            get
            {
                return includeLastPublishedDate;
            }

            set
            {
                includeLastPublishedDate = value;
            }
        }


    }
}
