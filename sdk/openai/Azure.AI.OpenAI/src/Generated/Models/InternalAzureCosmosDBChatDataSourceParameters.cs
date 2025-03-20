// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureCosmosDBChatDataSourceParameters
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalAzureCosmosDBChatDataSourceParameters(string containerName, string databaseName, string indexName, DataSourceAuthentication authentication, DataSourceFieldMappings fieldMappings, DataSourceVectorizer vectorizationSource)
        {
            Argument.AssertNotNull(containerName, nameof(containerName));
            Argument.AssertNotNull(databaseName, nameof(databaseName));
            Argument.AssertNotNull(indexName, nameof(indexName));
            Argument.AssertNotNull(authentication, nameof(authentication));
            Argument.AssertNotNull(fieldMappings, nameof(fieldMappings));
            Argument.AssertNotNull(vectorizationSource, nameof(vectorizationSource));

            ContainerName = containerName;
            DatabaseName = databaseName;
            IndexName = indexName;
            Authentication = authentication;
            FieldMappings = fieldMappings;
            VectorizationSource = vectorizationSource;
            _internalIncludeContexts = new ChangeTrackingList<string>();
        }

        internal InternalAzureCosmosDBChatDataSourceParameters(int? topNDocuments, bool? inScope, int? strictness, int? maxSearchQueries, bool? allowPartialResult, string containerName, string databaseName, string indexName, DataSourceAuthentication authentication, DataSourceFieldMappings fieldMappings, DataSourceVectorizer vectorizationSource, IList<string> internalIncludeContexts, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            TopNDocuments = topNDocuments;
            InScope = inScope;
            Strictness = strictness;
            MaxSearchQueries = maxSearchQueries;
            AllowPartialResult = allowPartialResult;
            ContainerName = containerName;
            DatabaseName = databaseName;
            IndexName = indexName;
            Authentication = authentication;
            FieldMappings = fieldMappings;
            VectorizationSource = vectorizationSource;
            _internalIncludeContexts = internalIncludeContexts;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The configured number of documents to feature in the query. </summary>
        public int? TopNDocuments { get; set; }

        /// <summary> Whether queries should be restricted to use of the indexed data. </summary>
        public bool? InScope { get; set; }

        /// <summary>
        /// The configured strictness of the search relevance filtering.
        /// Higher strictness will increase precision but lower recall of the answer.
        /// </summary>
        public int? Strictness { get; set; }

        /// <summary>
        /// The maximum number of rewritten queries that should be sent to the search provider for a single user message.
        /// By default, the system will make an automatic determination.
        /// </summary>
        public int? MaxSearchQueries { get; set; }

        /// <summary>
        /// If set to true, the system will allow partial search results to be used and the request will fail if all
        /// partial queries fail. If not specified or specified as false, the request will fail if any search query fails.
        /// </summary>
        public bool? AllowPartialResult { get; set; }

        /// <summary> Gets the ContainerName. </summary>
        public string ContainerName { get; set; }

        /// <summary> Gets the DatabaseName. </summary>
        public string DatabaseName { get; set; }

        /// <summary> Gets the IndexName. </summary>
        public string IndexName { get; set; }

        /// <summary></summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
