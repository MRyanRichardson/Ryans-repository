// <copyright file="PexAssemblyInfo.cs" company="Hewlett-Packard">Copyright © Hewlett-Packard 2019</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("FlooringMastery")]
[assembly: PexInstrumentAssembly("FlooringMastery.BLL")]
[assembly: PexInstrumentAssembly("FlooringMasteryModels")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "FlooringMastery.BLL")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "FlooringMasteryModels")]

