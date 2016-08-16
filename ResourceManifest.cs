using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace Rimango.Groups
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest.DefineScript("SemanticUI.Dropdown").SetUrl("SemanticUI/dropdown.min.js", "SemanticUI/dropwdown.js");

            manifest.DefineStyle("SemnanticUI.Dropdown").SetUrl("SemanticUI/dropdown.min.css");

        }
    }
}