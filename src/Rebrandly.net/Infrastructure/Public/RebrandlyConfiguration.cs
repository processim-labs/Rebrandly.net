using Newtonsoft.Json;
using Rebrandly.Exceptions;
using Rebrandly.Infrastructure;
using Rebrandly.Infrastructure.Interfaces;
using Rebrandly.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Rebrandly
{
    /// <summary>
    /// Global configuration class for Rebrandly.net settings.
    /// </summary>
    public static class RebrandlyConfiguration
    {
        private static string apiKey;

        private static string clientId;

        private static IRebrandlyClient rebrandlyClient;

        static RebrandlyConfiguration()
        {
            RebrandlyNetVersion = new AssemblyName(typeof(RebrandlyConfiguration).GetTypeInfo().Assembly.FullName).Version.ToString(3);
        }

        /// <summary>Gets or sets the API key.</summary>
        /// <remarks>
        /// You can also set the API key using the <c>RebrandlyApiKey</c> key in
        /// <see cref="System.Configuration.ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(apiKey) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["RebrandlyApiKey"]))
                {
                    apiKey = ConfigurationManager.AppSettings["RebrandlyApiKey"];
                }

                return apiKey;
            }

            set
            {
                if (value != apiKey)
                {
                    RebrandlyClient = null;
                }

                apiKey = value;
            }
        }

        /// <summary>Gets or sets the client ID.</summary>
        /// <remarks>
        /// You can also set the client ID using the <c>RebrandlyClientId</c> key in
        /// <see cref="System.Configuration.ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string ClientId
        {
            get
            {
                if (string.IsNullOrEmpty(apiKey) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["RebrandlyClientId"]))
                {
                    clientId = ConfigurationManager.AppSettings["RebrandlyClientId"];
                }

                return clientId;
            }

            set
            {
                if (value != clientId)
                {
                    RebrandlyClient = null;
                }

                clientId = value;
            }
        }


        /// <summary>
        /// Gets or sets a custom <see cref="RebrandlyClient"/> for sending requests to Rebrandly's
        /// API. You can use this to use a custom message handler, set proxy parameters, etc.
        /// </summary>
        public static IRebrandlyClient RebrandlyClient
        {
            get
            {
                if (rebrandlyClient == null)
                {
                    rebrandlyClient = BuildDefaultRebrandlyClient();
                }

                return rebrandlyClient;
            }

            set => rebrandlyClient = value;
        }

        /// <summary>Gets the version of the Rebrandly.net client library.</summary>
        public static string RebrandlyNetVersion { get; }

        private static RebrandlyClient BuildDefaultRebrandlyClient()
        {
            if (ApiKey != null && ApiKey.Length == 0)
            {
                var message = "Your API key is invalid, as it is an empty string. You can "
                    + "double-check your API key from the Rebrandly Dashboard. See "
                    + "https://developers.rebrandly.com/docs/api-key-authentication for details or contact support "
                    + "at https://support.rebrandly.com/hc/en-us/requests/new if you have any questions.";
                throw new RebrandlyException(message);
            }

            if (ApiKey != null && StringUtils.ContainsWhitespace(ApiKey))
            {
                var message = "Your API key is invalid, as it contains whitespace. You can "
                    + "double-check your API key from the Rebrandly Dashboard. See "
                    + "https://developers.rebrandly.com/docs/api-key-authentication for details or contact support "
                    + "at https://support.rebrandly.com/hc/en-us/requests/new if you have any questions.";
                throw new RebrandlyException(message);
            }

            var httpClient = new RebrandlyHttpClient(httpClient: null);
            return new RebrandlyClient(ApiKey, ClientId, httpClient: httpClient);
        }
    }
}

