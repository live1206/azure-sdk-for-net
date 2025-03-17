// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Microsoft Fabric Lakehouse Table. </summary>
    public partial class LakeHouseTableDataset : DataFactoryDatasetProperties
    {
        /// <summary> Initializes a new instance of <see cref="LakeHouseTableDataset"/>. </summary>
        /// <param name="linkedServiceName"> Linked service reference. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="linkedServiceName"/> is null. </exception>
        public LakeHouseTableDataset(DataFactoryLinkedServiceReference linkedServiceName) : base(linkedServiceName)
        {
            Argument.AssertNotNull(linkedServiceName, nameof(linkedServiceName));

            DatasetType = "LakehouseTable";
        }

        /// <summary> Initializes a new instance of <see cref="LakeHouseTableDataset"/>. </summary>
        /// <param name="datasetType"> Type of dataset. </param>
        /// <param name="description"> Dataset description. </param>
        /// <param name="structure"> Columns that define the structure of the dataset. Type: array (or Expression with resultType array), itemType: DatasetDataElement. </param>
        /// <param name="schema"> Columns that define the physical type schema of the dataset. Type: array (or Expression with resultType array), itemType: DatasetSchemaDataElement. </param>
        /// <param name="linkedServiceName"> Linked service reference. </param>
        /// <param name="parameters"> Parameters for dataset. </param>
        /// <param name="annotations"> List of tags that can be used for describing the Dataset. </param>
        /// <param name="folder"> The folder that this Dataset is in. If not specified, Dataset will appear at the root level. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="schemaTypePropertiesSchema"> The schema name of Microsoft Fabric Lakehouse Table. Type: string (or Expression with resultType string). </param>
        /// <param name="table"> The name of Microsoft Fabric Lakehouse Table. Type: string (or Expression with resultType string). </param>
        internal LakeHouseTableDataset(string datasetType, string description, DataFactoryElement<IList<DatasetDataElement>> structure, DataFactoryElement<IList<DatasetSchemaDataElement>> schema, DataFactoryLinkedServiceReference linkedServiceName, IDictionary<string, EntityParameterSpecification> parameters, IList<BinaryData> annotations, DatasetFolder folder, IDictionary<string, BinaryData> additionalProperties, DataFactoryElement<string> schemaTypePropertiesSchema, DataFactoryElement<string> table) : base(datasetType, description, structure, schema, linkedServiceName, parameters, annotations, folder, additionalProperties)
        {
            SchemaTypePropertiesSchema = schemaTypePropertiesSchema;
            Table = table;
            DatasetType = datasetType ?? "LakehouseTable";
        }

        /// <summary> Initializes a new instance of <see cref="LakeHouseTableDataset"/> for deserialization. </summary>
        internal LakeHouseTableDataset()
        {
        }

        /// <summary> The schema name of Microsoft Fabric Lakehouse Table. Type: string (or Expression with resultType string). </summary>
        public DataFactoryElement<string> SchemaTypePropertiesSchema { get; set; }
        /// <summary> The name of Microsoft Fabric Lakehouse Table. Type: string (or Expression with resultType string). </summary>
        public DataFactoryElement<string> Table { get; set; }
    }
}
