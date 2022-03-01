using System;

namespace behaviac
{
	// Token: 0x02004853 RID: 18515
	public abstract class DecoratorTask : SingeChildTask
	{
		// Token: 0x0601AA0C RID: 109068 RVA: 0x00550715 File Offset: 0x0054EB15
		protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
		{
			return base.update_current(pAgent, childStatus);
		}

		// Token: 0x0601AA0D RID: 109069 RVA: 0x00550720 File Offset: 0x0054EB20
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			DecoratorNode decoratorNode = (DecoratorNode)this.m_node;
			if (childStatus != EBTStatus.BT_RUNNING && (!decoratorNode.m_bDecorateWhenChildEnds || childStatus != EBTStatus.BT_RUNNING))
			{
				EBTStatus ebtstatus = this.decorate(childStatus);
				if (ebtstatus != EBTStatus.BT_RUNNING)
				{
					return ebtstatus;
				}
				return EBTStatus.BT_RUNNING;
			}
			else
			{
				EBTStatus ebtstatus2 = base.update(pAgent, childStatus);
				if (!decoratorNode.m_bDecorateWhenChildEnds || ebtstatus2 != EBTStatus.BT_RUNNING)
				{
					return this.decorate(ebtstatus2);
				}
				return EBTStatus.BT_RUNNING;
			}
		}

		// Token: 0x0601AA0E RID: 109070
		protected abstract EBTStatus decorate(EBTStatus status);
	}
}
