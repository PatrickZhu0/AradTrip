using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200489E RID: 18590
	public class DecoratorLoopUntil : DecoratorCount
	{
		// Token: 0x0601ABA5 RID: 109477 RVA: 0x00656FF0 File Offset: 0x006553F0
		public DecoratorLoopUntil()
		{
			this.m_until = true;
		}

		// Token: 0x0601ABA6 RID: 109478 RVA: 0x00657000 File Offset: 0x00655400
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Until")
				{
					if (property_t.value == "true")
					{
						this.m_until = true;
					}
					else if (property_t.value == "false")
					{
						this.m_until = false;
					}
				}
			}
		}

		// Token: 0x0601ABA7 RID: 109479 RVA: 0x0065708C File Offset: 0x0065548C
		protected override BehaviorTask createTask()
		{
			return new DecoratorLoopUntil.DecoratorLoopUntilTask();
		}

		// Token: 0x04012A0A RID: 76298
		protected bool m_until;

		// Token: 0x0200489F RID: 18591
		private class DecoratorLoopUntilTask : DecoratorCount.DecoratorCountTask
		{
			// Token: 0x0601ABA9 RID: 109481 RVA: 0x006570A8 File Offset: 0x006554A8
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABAA RID: 109482 RVA: 0x006570B1 File Offset: 0x006554B1
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABAB RID: 109483 RVA: 0x006570BA File Offset: 0x006554BA
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABAC RID: 109484 RVA: 0x006570C4 File Offset: 0x006554C4
			protected override EBTStatus decorate(EBTStatus status)
			{
				if (this.m_n > 0)
				{
					this.m_n--;
				}
				if (this.m_n == 0)
				{
					return EBTStatus.BT_SUCCESS;
				}
				DecoratorLoopUntil decoratorLoopUntil = (DecoratorLoopUntil)base.GetNode();
				if (decoratorLoopUntil.m_until)
				{
					if (status == EBTStatus.BT_SUCCESS)
					{
						return EBTStatus.BT_SUCCESS;
					}
				}
				else if (status == EBTStatus.BT_FAILURE)
				{
					return EBTStatus.BT_FAILURE;
				}
				return EBTStatus.BT_RUNNING;
			}
		}
	}
}
