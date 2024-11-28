// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// Base type for skills.
    /// Please note <see cref="SearchIndexerSkill"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AzureMachineLearningSkill"/>, <see cref="WebApiSkill"/>, <see cref="AzureOpenAIEmbeddingSkill"/>, <see cref="CustomEntityLookupSkill"/>, <see cref="EntityRecognitionSkill"/>, <see cref="KeyPhraseExtractionSkill"/>, <see cref="LanguageDetectionSkill"/>, <see cref="MergeSkill"/>, <see cref="PiiDetectionSkill"/>, <see cref="SentimentSkill"/>, <see cref="SplitSkill"/>, <see cref="TextTranslationSkill"/>, <see cref="EntityLinkingSkill"/>, <see cref="ConditionalSkill"/>, <see cref="DocumentExtractionSkill"/>, <see cref="DocumentIntelligenceLayoutSkill"/>, <see cref="ShaperSkill"/>, <see cref="ImageAnalysisSkill"/>, <see cref="OcrSkill"/> and <see cref="VisionVectorizeSkill"/>.
    /// </summary>
    public partial class SearchIndexerSkill
    {
        /// <summary> Initializes a new instance of <see cref="SearchIndexerSkill"/>. </summary>
        /// <param name="oDataType"> A URI fragment specifying the type of skill. </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character '#'. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        internal SearchIndexerSkill(string oDataType, string name, string description, string context, IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs)
        {
            ODataType = oDataType;
            Name = name;
            Description = description;
            Context = context;
            Inputs = inputs;
            Outputs = outputs;
        }

        /// <summary> A URI fragment specifying the type of skill. </summary>
        internal string ODataType { get; set; }
        /// <summary> The description of the skill which describes the inputs, outputs, and usage of the skill. </summary>
        public string Description { get; set; }
        /// <summary> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </summary>
        public string Context { get; set; }
    }
}
