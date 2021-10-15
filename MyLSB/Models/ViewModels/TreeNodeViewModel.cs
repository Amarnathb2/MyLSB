using CMS.DocumentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Models
{
    public abstract class TreeNodeViewModel
    {
        public Guid NodeGUID { get; set; }

        public int NodeID { get; set; }

        public string NodeAliasPath { get; set; }

        public string ClassName { get; set; }

        public TreeNodeViewModel()
        {
        }

        public TreeNodeViewModel(TreeNode node)
        {
            NodeGUID = node.NodeGUID;
            NodeID = node.NodeID;
            NodeAliasPath = node.NodeAliasPath;
            ClassName = node.ClassName;
        }
    }
}
