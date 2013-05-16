﻿namespace ClariusLabs.NuGetToolkit
{
    using Microsoft.VisualStudio.GraphModel;
    using Microsoft.VisualStudio.GraphModel.Schemas;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class GraphNodeExtensions
    {
        internal static bool IsRootNode(this GraphNode node)
        {
            return node.IsPropertiesNode() || node.IsConfigNode();
        }

        internal static bool IsPropertiesNode(this GraphNode node)
        {
            return node.HasCategory("ProjectFolder") && node.Label == "Properties";
        }

        internal static bool IsConfigNode(this GraphNode node)
        {
            return node.HasCategory(CodeNodeCategories.ProjectItem) && node.Label == global::NuGet.Constants.PackageReferenceFile;
        }

        internal static bool IsPackageNode(this GraphNode node)
        {
            return node.HasCategory(ReferencesGraphSchema.PackageCategory);
        }
    }
}
