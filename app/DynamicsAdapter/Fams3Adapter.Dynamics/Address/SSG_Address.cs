﻿using Fams3Adapter.Dynamics.SearchRequest;
using Newtonsoft.Json;

namespace Fams3Adapter.Dynamics.Address
{
    public class SSG_Address : DynamicsEntity
    {
        [JsonProperty("ssg_addressfulltext")]
        public string FullText { get; set; }

        [JsonProperty("ssg_addresscategorytext")]
        public int? Category { get; set; }

        [JsonProperty("ssg_address")]
        public string AddressLine1 { get; set; }

        [JsonProperty("ssg_addresssecondaryunittext")]
        public string AddressLine2 { get; set; }

        [JsonProperty("ssg_addresslinethree")]
        public string AddressLine3 { get; set; }

        [JsonProperty("ssg_countrysubdivision")]
        public int? Province { get; set; }

        [JsonProperty("ssg_locationcityname")]
        public string City { get; set; }

        [JsonProperty("ssg_LocationCountry")]
        public virtual SSG_Country Country { get; set; }

        [JsonProperty("ssg_locationname")]
        public string Name { get; set; }

        [JsonProperty("ssg_locationpostalcode")]
        public string PostalCode { get; set; }

        [JsonProperty("ssg_SearchRequest")]
        public virtual SSG_SearchRequest SearchRequest { get; set; }

        [JsonProperty("ssg_informationsourcetext")]
        public int? InformationSource { get; set; }

        [JsonProperty("ssg_datadate")]
        public System.DateTime? EffectiveDate { get; set; }

        [JsonProperty("ssg_datadatelabel")]
        public string EffectiveDateLabel { get; set; }

        [JsonProperty("ssg_datadate2")]
        public System.DateTime? EndDate { get; set; }

        [JsonProperty("ssg_datadatelabel2")]
        public string EndDateLabel { get; set; }
    }
}
