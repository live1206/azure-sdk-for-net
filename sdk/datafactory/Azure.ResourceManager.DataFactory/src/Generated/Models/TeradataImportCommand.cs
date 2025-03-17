// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Teradata import command settings. </summary>
    public partial class TeradataImportCommand : ImportSettings
    {
        /// <summary> Initializes a new instance of <see cref="TeradataImportCommand"/>. </summary>
        public TeradataImportCommand()
        {
            ImportSettingsType = "TeradataImportCommand";
        }

        /// <summary> Initializes a new instance of <see cref="TeradataImportCommand"/>. </summary>
        /// <param name="importSettingsType"> The import setting type. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="additionalFormatOptions"> Additional format options for Teradata Copy Command. The format options only applies to direct copy from CSV source. Type: key value pairs (value should be string type) (or Expression with resultType object). Example: "additionalFormatOptions": { "timeFormat": "HHhMImSSs" }. </param>
        internal TeradataImportCommand(string importSettingsType, IDictionary<string, BinaryData> additionalProperties, DataFactoryElement<IDictionary<string, string>> additionalFormatOptions) : base(importSettingsType, additionalProperties)
        {
            AdditionalFormatOptions = additionalFormatOptions;
            ImportSettingsType = importSettingsType ?? "TeradataImportCommand";
        }

        /// <summary> Additional format options for Teradata Copy Command. The format options only applies to direct copy from CSV source. Type: key value pairs (value should be string type) (or Expression with resultType object). Example: "additionalFormatOptions": { "timeFormat": "HHhMImSSs" }. </summary>
        public DataFactoryElement<IDictionary<string, string>> AdditionalFormatOptions { get; set; }
    }
}
