using System;
using System.Collections.Generic;
using System.Xml;

namespace DD4T.Mvc.SiteEdit
{
    /// <summary>
    /// SiteEdit version
    /// </summary>
    public enum SiteEditStyle
    {
        /// <summary>
        /// SiteEdit 2009 SP3
        /// </summary>
        SiteEdit,
        /// <summary>
        /// UI 2012 (SDL Tridion – The New Experience)
        /// </summary>
        SiteEdit2012
    }

    public class SiteEditSettings : Dictionary<string, SiteEditSetting>
    {
        public static string SiteEditConfigurationPath = "~/SiteEdit_config.xml";

        /**
         * Boolean indicating whether or not SiteEdit is enabled for the entire web application
         */
        public bool Enabled { get; set; }
        public SiteEditStyle Style { get; set; }
        public string TridionHostUrl { get; set; }

        public SiteEditSettings() 
        {
        }

        public SiteEditSettings(string pathToSiteEditConfiguration)
        {

            
            //TODO: fix configuration
            SiteEditSetting seSetting = new SiteEditSetting(true);
            base.Add(seSetting.ContextPublication, seSetting);
            Style = SiteEditStyle.SiteEdit2012;
            
          
        }


        /**
         * Retrieve siteedit setting for a specific publication id.
         * 
         * @param pubid The publication ID
         * @return SiteEditSetting for given pubid
         */

        public new SiteEditSetting this[string key]
        {
            get
            {
                if (!base.ContainsKey(key))
                {
                    return new SiteEditSetting(); // return a blank SiteEditSetting, which has 'enabled' false
                }
                return base[key];
            }
        }
    }


    /**
     * Used to represent settings for a specific
     * Tridion publication.
     */
    public class SiteEditSetting
    {

        /**
         * Boolean indicating whether or not SiteEdit is enabled for the current site 
         */
        public bool Enabled { get; set; }
        /**
         * Context publication ID (publication for which the settings must be looked up)
         */
        public string ContextPublication { get; set; }
        /**
         * publication ID where the components are to be edited in
         */
        public string ComponentPublication { get; set; }
        /**
         * publication ID where the pages are to be edited in
         */
        public string PagePublication { get; set; }
        /**
         * publication ID where the pages and component need to be published to
         */
        public string PublishPublication { get; set; }

        public SiteEditSetting()
        {
            this.Enabled = false;
        }

        //public SiteEditSetting(XmlElement contextPublicationElmt)
        //{
        //    this.Enabled = true;
        //    this.ContextPublication = contextPublicationElmt.GetAttribute("id");
        //    this.ComponentPublication = contextPublicationElmt.GetAttribute("componentPublication");
        //    this.PagePublication = contextPublicationElmt.GetAttribute("pagePublication");
        //    this.PublishPublication = contextPublicationElmt.GetAttribute("publishPublication");
        //}

        public SiteEditSetting(bool enabled = true)
        {
            this.Enabled = true;
            this.ContextPublication = "23";
            this.ComponentPublication = "23";
            this.PagePublication = "23";
            this.PublishPublication = "23";
        }
    }
}
