using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048A2 RID: 18594
	public class DecoratorRepeat : DecoratorCount
	{
		// Token: 0x0601ABB8 RID: 109496 RVA: 0x0083B1EC File Offset: 0x008395EC
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601ABB9 RID: 109497 RVA: 0x0083B1F7 File Offset: 0x008395F7
		public int Count(Agent pAgent)
		{
			return base.GetCount(pAgent);
		}

		// Token: 0x0601ABBA RID: 109498 RVA: 0x0083B200 File Offset: 0x00839600
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorRepeat && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601ABBB RID: 109499 RVA: 0x0083B21C File Offset: 0x0083961C
		protected override BehaviorTask createTask()
		{
			return new DecoratorRepeat.DecoratorRepeatTask();
		}

		// Token: 0x020048A3 RID: 18595
		private class DecoratorRepeatTask : DecoratorCount.DecoratorCountTask
		{
			// Token: 0x0601ABBD RID: 109501 RVA: 0x0083B238 File Offset: 0x00839638
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABBE RID: 109502 RVA: 0x0083B241 File Offset: 0x00839641
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABBF RID: 109503 RVA: 0x0083B24A File Offset: 0x0083964A
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABC0 RID: 109504 RVA: 0x0083B253 File Offset: 0x00839653
			protected override EBTStatus decorate(EBTStatus status)
			{
				return EBTStatus.BT_INVALID;
			}

			// Token: 0x0601ABC1 RID: 109505 RVA: 0x0083B258 File Offset: 0x00839658
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				DecoratorNode decoratorNode = (DecoratorNode)this.m_node;
				for (int i = 0; i < this.m_n; i++)
				{
					EBTStatus ebtstatus = this.m_root.exec(pAgent, childStatus);
					if (decoratorNode.m_bDecorateWhenChildEnds)
					{
						while (ebtstatus == EBTStatus.BT_RUNNING)
						{
							ebtstatus = base.update(pAgent, childStatus);
						}
					}
					if (ebtstatus == EBTStatus.BT_FAILURE)
					{
						return EBTStatus.BT_FAILURE;
					}
				}
				return EBTStatus.BT_SUCCESS;
			}
		}
	}
}
