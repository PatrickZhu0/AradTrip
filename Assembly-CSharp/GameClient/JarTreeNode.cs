using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012A5 RID: 4773
	public class JarTreeNode
	{
		// Token: 0x0600B799 RID: 47001 RVA: 0x0029EE50 File Offset: 0x0029D250
		public JarTreeNode GetChild(int a_nKey)
		{
			if (this.children != null)
			{
				for (int i = 0; i < this.children.Count; i++)
				{
					if (this.children[i].nKey == a_nKey)
					{
						return this.children[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600B79A RID: 47002 RVA: 0x0029EEAC File Offset: 0x0029D2AC
		public void AddChild(JarTreeNode a_node)
		{
			if (this.children == null)
			{
				this.children = new List<JarTreeNode>();
			}
			for (int i = 0; i < this.children.Count; i++)
			{
				if (this.children[i].nKey == a_node.nKey)
				{
					return;
				}
			}
			this.children.Add(a_node);
		}

		// Token: 0x04006793 RID: 26515
		public JarTreeNode parent;

		// Token: 0x04006794 RID: 26516
		public List<JarTreeNode> children;

		// Token: 0x04006795 RID: 26517
		public int nKey;

		// Token: 0x04006796 RID: 26518
		public object value;
	}
}
