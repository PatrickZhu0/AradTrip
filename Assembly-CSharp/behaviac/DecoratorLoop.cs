using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200489C RID: 18588
	public class DecoratorLoop : DecoratorCount
	{
		// Token: 0x0601AB9B RID: 109467 RVA: 0x0083AFC0 File Offset: 0x008393C0
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "DoneWithinFrame" && property_t.value == "true")
				{
					this.m_bDoneWithinFrame = true;
				}
			}
		}

		// Token: 0x0601AB9C RID: 109468 RVA: 0x0083B028 File Offset: 0x00839428
		public int Count(Agent pAgent)
		{
			return base.GetCount(pAgent);
		}

		// Token: 0x0601AB9D RID: 109469 RVA: 0x0083B031 File Offset: 0x00839431
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorLoop && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB9E RID: 109470 RVA: 0x0083B050 File Offset: 0x00839450
		protected override BehaviorTask createTask()
		{
			return new DecoratorLoop.DecoratorLoopTask();
		}

		// Token: 0x04012A09 RID: 76297
		protected bool m_bDoneWithinFrame;

		// Token: 0x0200489D RID: 18589
		private class DecoratorLoopTask : DecoratorCount.DecoratorCountTask
		{
			// Token: 0x0601ABA0 RID: 109472 RVA: 0x0083B06C File Offset: 0x0083946C
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABA1 RID: 109473 RVA: 0x0083B075 File Offset: 0x00839475
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABA2 RID: 109474 RVA: 0x0083B07E File Offset: 0x0083947E
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABA3 RID: 109475 RVA: 0x0083B087 File Offset: 0x00839487
			protected override EBTStatus decorate(EBTStatus status)
			{
				if (this.m_n > 0)
				{
					this.m_n--;
					if (this.m_n == 0)
					{
						return EBTStatus.BT_SUCCESS;
					}
					return EBTStatus.BT_RUNNING;
				}
				else
				{
					if (this.m_n == -1)
					{
						return EBTStatus.BT_RUNNING;
					}
					return EBTStatus.BT_SUCCESS;
				}
			}

			// Token: 0x0601ABA4 RID: 109476 RVA: 0x0083B0C4 File Offset: 0x008394C4
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				DecoratorLoop decoratorLoop = (DecoratorLoop)this.m_node;
				if (decoratorLoop.m_bDoneWithinFrame)
				{
					for (int i = 0; i < this.m_n; i++)
					{
						EBTStatus ebtstatus = this.m_root.exec(pAgent, childStatus);
						if (decoratorLoop.m_bDecorateWhenChildEnds)
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
				return base.update(pAgent, childStatus);
			}
		}
	}
}
