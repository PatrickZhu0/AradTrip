using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004890 RID: 18576
	public class DecoratorAlwaysSuccess : DecoratorNode
	{
		// Token: 0x0601AB5F RID: 109407 RVA: 0x00550317 File Offset: 0x0054E717
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB60 RID: 109408 RVA: 0x00550322 File Offset: 0x0054E722
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorAlwaysSuccess && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB61 RID: 109409 RVA: 0x00550340 File Offset: 0x0054E740
		protected override BehaviorTask createTask()
		{
			return new DecoratorAlwaysSuccess.DecoratorAlwaysSuccessTask();
		}

		// Token: 0x02004891 RID: 18577
		private class DecoratorAlwaysSuccessTask : DecoratorTask
		{
			// Token: 0x0601AB63 RID: 109411 RVA: 0x00550797 File Offset: 0x0054EB97
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB64 RID: 109412 RVA: 0x005507A0 File Offset: 0x0054EBA0
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB65 RID: 109413 RVA: 0x005507A9 File Offset: 0x0054EBA9
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB66 RID: 109414 RVA: 0x005507B2 File Offset: 0x0054EBB2
			protected override EBTStatus decorate(EBTStatus status)
			{
				return EBTStatus.BT_SUCCESS;
			}
		}
	}
}
