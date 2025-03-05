// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using System;
using System.ComponentModel.Composition;

namespace Azure.Generator.Mgmt
{
    /// <summary>
    /// The management-plane client plugin to generate the Azure mgmt client SDK.
    /// </summary>
    [Export(typeof(CodeModelPlugin))]
    [ExportMetadata("PluginName", nameof(MgmtClientPlugin))]
    public class MgmtClientPlugin : AzureClientPlugin
    {
        private static MgmtClientPlugin? _instance;
        internal static MgmtClientPlugin Instance => _instance ?? throw new InvalidOperationException("MgmtClientPlugin is not loaded.");
        /// <summary>
        /// The Azure client plugin to generate the Azure client SDK.
        /// </summary>
        /// <param name="context"></param>
        [ImportingConstructor]
        public MgmtClientPlugin(GeneratorContext context) : base(context)
        {
            _instance = this;
        }

        private MgmtOutputLibrary? _azureOutputLibrary;
        /// <inheritdoc/>
        public override MgmtOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

        internal ResourceDetection ResourceDetection { get; } = new();

        /// <summary>
        /// Customize the generation output for Azure client SDK.
        /// </summary>
        public override void Configure()
        {
            base.Configure();
            AddVisitor(new RestClientVisitor());
            AddVisitor(new ResourceVisitor());
        }
    }
}
