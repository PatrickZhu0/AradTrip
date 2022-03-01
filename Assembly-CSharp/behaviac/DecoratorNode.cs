using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004848 RID: 18504
	public abstract class DecoratorNode : BehaviorNode
	{
		// Token: 0x0601A9A3 RID: 108963 RVA: 0x00550279 File Offset: 0x0054E679
		public DecoratorNode()
		{
			this.m_bDecorateWhenChildEnds = false;
		}

		// Token: 0x0601A9A4 RID: 108964 RVA: 0x00550288 File Offset: 0x0054E688
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "DecorateWhenChildEnds" && property_t.value == "true")
				{
					this.m_bDecorateWhenChildEnds = true;
				}
			}
		}

		// Token: 0x0601A9A5 RID: 108965 RVA: 0x005502F0 File Offset: 0x0054E6F0
		public override bool IsManagingChildrenAsSubTrees()
		{
			return true;
		}

		// Token: 0x0601A9A6 RID: 108966 RVA: 0x005502F3 File Offset: 0x0054E6F3
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorNode && base.IsValid(pAgent, pTask);
		}

		// Token: 0x040129A6 RID: 76198
		public bool m_bDecorateWhenChildEnds;
	}
}
