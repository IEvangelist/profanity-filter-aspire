// <auto-generated/>
using Microsoft.Kiota.Abstractions;
using ProfanityFilter.Client.Profanity.Data;
using ProfanityFilter.Client.Profanity.Filter;
using ProfanityFilter.Client.Profanity.Strategies;
using ProfanityFilter.Client.Profanity.Targets;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace ProfanityFilter.Client.Profanity
{
    /// <summary>
    /// Builds and executes requests for operations under \profanity
    /// </summary>
    public class ProfanityRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The data property</summary>
        public ProfanityFilter.Client.Profanity.Data.DataRequestBuilder Data
        {
            get => new ProfanityFilter.Client.Profanity.Data.DataRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The filter property</summary>
        public ProfanityFilter.Client.Profanity.Filter.FilterRequestBuilder Filter
        {
            get => new ProfanityFilter.Client.Profanity.Filter.FilterRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The strategies property</summary>
        public ProfanityFilter.Client.Profanity.Strategies.StrategiesRequestBuilder Strategies
        {
            get => new ProfanityFilter.Client.Profanity.Strategies.StrategiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The targets property</summary>
        public ProfanityFilter.Client.Profanity.Targets.TargetsRequestBuilder Targets
        {
            get => new ProfanityFilter.Client.Profanity.Targets.TargetsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="ProfanityFilter.Client.Profanity.ProfanityRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ProfanityRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/profanity", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="ProfanityFilter.Client.Profanity.ProfanityRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ProfanityRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/profanity", rawUrl)
        {
        }
    }
}
