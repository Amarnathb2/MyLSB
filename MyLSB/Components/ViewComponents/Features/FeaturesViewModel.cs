using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class FeaturesViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<Feature> Features { get; set; }

        public static FeaturesViewModel GetViewModel(Features features, FeatureRepository featureRepository)
        {
            return new FeaturesViewModel
            {
                Heading = features.Fields.Heading,
                Features = featureRepository.GetFeatures(features.NodeAliasPath).Take(3)
            };
        }
    }
}
