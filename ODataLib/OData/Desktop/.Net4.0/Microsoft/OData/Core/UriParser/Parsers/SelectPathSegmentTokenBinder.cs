//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Core.UriParser.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Microsoft.OData.Core.UriParser.Syntactic;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Core.Metadata;
    using Microsoft.OData.Core.UriParser.Metadata;
    using Microsoft.OData.Core.UriParser.Semantic;
    using ODataErrorStrings = Microsoft.OData.Core.Strings;

    /// <summary>
    /// Builds segments from tokens within $select.
    /// </summary>
    internal static class SelectPathSegmentTokenBinder
    {
        /// <summary>
        /// Build a segment from a token.
        /// </summary>
        /// <param name="tokenIn">the token to bind</param>
        /// <param name="model">The model.</param>
        /// <param name="edmType">the type of the current scope based on type segments.</param>
        /// <returns>The segment created from the token.</returns>
        public static ODataPathSegment ConvertNonTypeTokenToSegment(PathSegmentToken tokenIn, IEdmModel model, IEdmStructuredType edmType)
        {
            ODataPathSegment nextSegment;
            if (TryBindAsDeclaredProperty(tokenIn, edmType, out nextSegment))
            {
                return nextSegment;
            }

            // for open types, operations must be container-qualified, and because the token type indicates it was not a .-seperated identifier, we should not try to look up operations.
            if (!edmType.IsOpen || tokenIn.IsNamespaceOrContainerQualified())
            {
                if (TryBindAsOperation(tokenIn, model, edmType, out nextSegment))
                {
                    return nextSegment;
                }
            }

            if (edmType.IsOpen)
            {
                return new OpenPropertySegment(tokenIn.Identifier);
            }

            throw new ODataException(ODataErrorStrings.MetadataBinder_PropertyNotDeclared(edmType.ODataFullName(), tokenIn.Identifier));
        }

        /// <summary>
        /// Build a wildcard selection item
        /// </summary>
        /// <param name="tokenIn">the token to bind to a wildcard</param>
        /// <param name="model">the model to search for this wildcard</param>
        /// <param name="item">the new wildcard selection item, if we found one</param>
        /// <returns>true if we successfully bound to a wildcard, false otherwise</returns>
        public static bool TryBindAsWildcard(PathSegmentToken tokenIn, IEdmModel model, out SelectItem item)
        {
            bool isTypeToken = tokenIn.IsNamespaceOrContainerQualified();
            bool wildcard = tokenIn.Identifier.EndsWith("*", StringComparison.Ordinal);

            IEdmEntityContainer container;
            if (isTypeToken && wildcard && UriEdmHelpers.TryGetEntityContainer(tokenIn.Identifier.Substring(0, tokenIn.Identifier.LastIndexOf('.')), model, out container))
            {
                item = new ContainerQualifiedWildcardSelectItem(container);
                return true;
            }

            if (tokenIn.Identifier == "*")
            {
                item = new WildcardSelectItem();
                return true;
            }

            item = null;
            return false;
        }

        /// <summary>
        /// Tries to bind a given token as an Operation.
        /// </summary>
        /// <param name="pathToken">Token to bind.</param>
        /// <param name="model">The model.</param>
        /// <param name="entityType">the current entity type to use as the binding type when looking for operations.</param>
        /// <param name="segment">Bound segment if the token was bound to an operation successfully, or null.</param>
        /// <returns>True if the token was bound successfully, or false otherwise.</returns>
        [SuppressMessage("DataWeb.Usage", "AC0003:MethodCallNotAllowed", Justification = "Rule only applies to ODataLib Serialization code.")]
        private static bool TryBindAsOperation(PathSegmentToken pathToken, IEdmModel model, IEdmStructuredType entityType, out ODataPathSegment segment)
        {
            Debug.Assert(pathToken != null, "pathToken != null");
            Debug.Assert(entityType != null, "bindingType != null");

            IEnumerable<IEdmOperationImport> operationImports;
            var resolver = model as IODataUriParserModelExtensions;
            if (resolver != null)
            {
                operationImports = resolver.FindFunctionImportsByBindingParameterTypeHierarchy(entityType, pathToken.Identifier);
            }
            else
            {
                operationImports = model.FindFunctionImportsByBindingParameterTypeHierarchy(entityType, pathToken.Identifier);
            }

            List<IEdmOperationImport> possibleFunctions = operationImports.ToList();

            if (possibleFunctions.Count <= 0)
            {
                segment = null;
                return false;
            }

            segment = new OperationSegment(possibleFunctions, null /*entitySet*/);
            return true;
        }

        /// <summary>
        /// Tries to bind a given token as an a declared structural or navigation property.
        /// </summary>
        /// <param name="tokenIn">Token to bind.</param>
        /// <param name="edmType">the type to search for this property</param>
        /// <param name="segment">Bound segment if the token was bound to a declared property successfully, or null.</param>
        /// <returns>True if the token was bound successfully, or false otherwise.</returns>
        [SuppressMessage("DataWeb.Usage", "AC0003:MethodCallNotAllowed", Justification = "Rule only applies to ODataLib Serialization code.")]
        private static bool TryBindAsDeclaredProperty(PathSegmentToken tokenIn, IEdmStructuredType edmType, out ODataPathSegment segment)
        {
            IEdmProperty prop = edmType.FindProperty(tokenIn.Identifier);
            if (prop == null)
            {
                segment = null;
                return false;
            }

            if (prop.PropertyKind == EdmPropertyKind.Structural)
            {
                segment = new PropertySegment((IEdmStructuralProperty)prop);
                return true;
            }

            if (prop.PropertyKind == EdmPropertyKind.Navigation)
            {
                segment = new NavigationPropertySegment((IEdmNavigationProperty)prop, null /*TODO set*/);
                return true;
            }

            throw new ODataException(ODataErrorStrings.SelectExpandBinder_UnknownPropertyType(prop.Name));
        }
    }
}