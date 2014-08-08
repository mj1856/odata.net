//   OData .NET Libraries ver. 5.6.2
//   Copyright (c) Microsoft Corporation. All rights reserved.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System.Diagnostics.CodeAnalysis;

// Violations triggered by using terms from our spec could not solve them by adding the word(s) to the FxCop custom dictionary
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "Utils", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Utils", Scope = "type", Target = "Microsoft.Data.OData.ODataUtils")]
[module: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Utils", Scope = "type", Target = "Microsoft.Data.OData.Query.ODataUriUtils")]
[module: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Utils", Scope = "type", Target = "Microsoft.Data.OData.Query.ODataQueryUtils")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "mediaresource", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "src", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "The name of the src attribute on the atom:content element.")]

// Violations triggered by using various terms comming from other specs
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "dataservices", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "Part of an XML namespace URL, can't change.")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "Rel", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "LinkRel is a valid identifier used in the public API.")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "rel", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "ATOM attribute name, can't change.")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "Edm", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "orderby", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "$orderby is a keyword in the URL query language.")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "innererror", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "JSON property name, can't change.")]
[module: SuppressMessage("Microsoft.Naming", "CA1701:ResourceStringCompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", Scope = "resource", Target = "Microsoft.Data.OData.resources", Justification = "XmlNodeType.Whitespace is an existing API which we can't fix..")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "URIs", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "odata", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "setexpression", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "charset", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "Multi", Scope = "resource", Target = "Microsoft.Data.OData.resources")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "inlinecount", Scope = "resource", Target = "Microsoft.Data.OData.resources")]

// Violations in the generated Resource file; can't prevent these from being generated.
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.Error.#ArgumentNull(System.String)")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.Error.#ArgumentOutOfRange(System.String)")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.Error.#NotImplemented()")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.Error.#NotSupported()")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.TextRes.#GetObject(System.String)")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.TextRes.#Resources")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.TextRes.#GetString(System.String,System.Boolean&)")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.TextRes.#GetString(System.String,System.Object[])")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Data.OData.Strings.#get_ODataVersionChecker_ProtocolVersion3IsNotSupported()", Justification = "String is used if #INTERNAL_DROP is set.")]

// Violations caused by namespaces having too few public types.
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Data.OData.Metadata")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Data.OData.Evaluation")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Data.OData.JsonLight")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Data.OData.Query.Metadata")]

// Types forwarded from Astoria client to be shared with ODataLib.
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Services.Common", Justification = "Types are shared with Astoria client.")]

//// FxCop does not recognize the suppress message attributes on the members; have to make them global suppressions.
[module: SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.Data.OData.Query.BinaryOperator.#ctor(System.String,System.Int16,System.Boolean)", Scope = "member", Target = "Microsoft.Data.OData.Query.BinaryOperator.#.cctor()")]
[module: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "eq", Scope = "member", Target = "Microsoft.Data.OData.Query.BinaryOperator.#.cctor()")]
[module: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "gt", Scope = "member", Target = "Microsoft.Data.OData.Query.BinaryOperator.#.cctor()")]
[module: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "mul", Scope = "member", Target = "Microsoft.Data.OData.Query.BinaryOperator.#.cctor()")]

[module: SuppressMessage("Microsoft.Naming", "CA1701:ResourceStringCompoundWordsShouldBeCasedCorrectly", MessageId = "NonEntity", Scope = "resource", Target = "Microsoft.Data.OData.resources")]