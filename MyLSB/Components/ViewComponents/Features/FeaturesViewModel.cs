﻿using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class FeaturesViewModel
    {
        public int NodeID { get; set; }
        public string Heading { get; set; }
        public IEnumerable<Feature> Features { get; set; }

        public static FeaturesViewModel GetViewModel(Features features, FeatureRepository featureRepository)
        {
            return new FeaturesViewModel
            {
                NodeID = features.NodeID,
                Heading = features.FeaturesHeading,
                Features = featureRepository.GetFeatures(features.NodeAliasPath).Take(3)
            };
        }
    }
}
