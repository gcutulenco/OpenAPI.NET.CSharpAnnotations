﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. 

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Microsoft.OpenApi.CSharpComment.Reader
{
    /// <summary>
    /// The class to store the configuration that will be used to generate the OpenAPI document from csharp
    /// documentation.
    /// </summary>
    public class CSharpCommentOpenApiGeneratorConfig
    {
        /// <summary>
        /// Creates a new instance of <see cref="CSharpCommentOpenApiGeneratorConfig"/>.
        /// </summary>
        /// <param name="annotationXmlDocuments">The XDocuments representing the annotation xmls.</param>
        /// <param name="assemblyPaths">The list of relative or absolute paths to the assemblies that will be used to
        /// reflect into the types provided in the xml.
        /// </param>
        /// <param name="openApiSpecificationVersion">The specification version of the OpenAPI document to generate.
        /// </param>
        public CSharpCommentOpenApiGeneratorConfig(
            IList<XDocument> annotationXmlDocuments,
            IList<string> assemblyPaths,
            OpenApiSpecVersion openApiSpecificationVersion) 
            : this(
                  annotationXmlDocuments,
                  assemblyPaths,
                  openApiSpecificationVersion,
                  new CSharpCommentOpenApiGeneratorFilterConfig())
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="CSharpCommentOpenApiGeneratorConfig"/>.
        /// </summary>
        /// <param name="annotationXmlDocuments">The XDocuments representing the annotation xmls.</param>
        /// <param name="assemblyPaths">The list of relative or absolute paths to the assemblies that will be used to
        /// reflect into the types provided in the xml.
        /// </param>
        /// <param name="openApiSpecificationVersion">The specification version of the OpenAPI document to generate.
        /// </param>
        /// <param name="cSharpCommentOpenApiGeneratorFilterConfig">The configuration encapsulating all the filters
        /// that will be applied while generating/processing OpenAPI document from C# comments.</param>
        public CSharpCommentOpenApiGeneratorConfig(
            IList<XDocument> annotationXmlDocuments,
            IList<string> assemblyPaths,
            OpenApiSpecVersion openApiSpecificationVersion,
            CSharpCommentOpenApiGeneratorFilterConfig cSharpCommentOpenApiGeneratorFilterConfig )
        {
            AnnotationXmlDocuments = annotationXmlDocuments
                ?? throw new ArgumentNullException(nameof(annotationXmlDocuments));

            AssemblyPaths = assemblyPaths
                ?? throw new ArgumentNullException(nameof(assemblyPaths));

            CSharpCommentOpenApiGeneratorFilterConfig = cSharpCommentOpenApiGeneratorFilterConfig
                ?? throw new ArgumentNullException(nameof(cSharpCommentOpenApiGeneratorFilterConfig));

            OpenApiSpecificationVersion = openApiSpecificationVersion;
        }

        /// <summary>
        /// The XDocument representing the advanced generation configuration.
        /// </summary>
        public XDocument AdvancedConfigurationXmlDocument { get; set; }

        /// <summary>
        /// The XDocuments representing the annotation xmls.
        /// </summary>
        public IList<XDocument> AnnotationXmlDocuments { get; }

        /// <summary>
        /// The list of relative or absolute paths to the assemblies that will be used to reflect into the
        /// types provided in the xml.
        /// </summary>
        public IList<string> AssemblyPaths { get; }

        /// <summary>
        /// The configuration encapsulating all the filters that will be applied while generating/processing OpenAPI
        /// document from C# comments.
        /// </summary>
        public CSharpCommentOpenApiGeneratorFilterConfig CSharpCommentOpenApiGeneratorFilterConfig { get; }

        /// <summary>
        /// The format (YAML or JSON) of the OpenAPI document to generate.
        /// </summary>
        public OpenApiFormat OpenApiFormat { get; set; } = OpenApiFormat.Json;

        /// <summary>
        /// The specification version of the OpenAPI document to generate.
        /// </summary>
        public OpenApiSpecVersion OpenApiSpecificationVersion { get; }
    }
}