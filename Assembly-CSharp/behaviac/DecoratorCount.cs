using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004892 RID: 18578
	public abstract class DecoratorCount : DecoratorNode
	{
		// Token: 0x0601AB68 RID: 109416 RVA: 0x00656E9C File Offset: 0x0065529C
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Count")
				{
					this.m_count = AgentMeta.ParseProperty(property_t.value, null);
				}
			}
		}

		// Token: 0x0601AB69 RID: 109417 RVA: 0x00656EFC File Offset: 0x006552FC
		protected virtual int GetCount(Agent pAgent)
		{
			if (this.m_count != null)
			{
				return ((CInstanceMember<int>)this.m_count).GetValue(pAgent);
			}
			return 0;
		}

		// Token: 0x04012A02 RID: 76290
		protected IInstanceMember m_count;

		// Token: 0x02004893 RID: 18579
		protected abstract class DecoratorCountTask : DecoratorTask
		{
			// Token: 0x0601AB6B RID: 109419 RVA: 0x00656F34 File Offset: 0x00655334
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				DecoratorCount.DecoratorCountTask decoratorCountTask = (DecoratorCount.DecoratorCountTask)target;
				decoratorCountTask.m_n = this.m_n;
			}

			// Token: 0x0601AB6C RID: 109420 RVA: 0x00656F5C File Offset: 0x0065535C
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("count");
				node.setAttr<int>(attrId, this.m_n);
			}

			// Token: 0x0601AB6D RID: 109421 RVA: 0x00656F89 File Offset: 0x00655389
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB6E RID: 109422 RVA: 0x00656F94 File Offset: 0x00655394
			protected override bool onenter(Agent pAgent)
			{
				base.onenter(pAgent);
				int count = this.GetCount(pAgent);
				if (count == 0)
				{
					return false;
				}
				this.m_n = count;
				return true;
			}

			// Token: 0x0601AB6F RID: 109423 RVA: 0x00656FC4 File Offset: 0x006553C4
			public int GetCount(Agent pAgent)
			{
				DecoratorCount decoratorCount = (DecoratorCount)base.GetNode();
				return (decoratorCount == null) ? 0 : decoratorCount.GetCount(pAgent);
			}

			// Token: 0x04012A03 RID: 76291
			protected int m_n;
		}
	}
}
