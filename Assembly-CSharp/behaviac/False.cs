using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004885 RID: 18565
	public class False : ConditionBase
	{
		// Token: 0x0601AB2B RID: 109355 RVA: 0x0083A6E0 File Offset: 0x00838AE0
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB2C RID: 109356 RVA: 0x0083A6EB File Offset: 0x00838AEB
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is False && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB2D RID: 109357 RVA: 0x0083A708 File Offset: 0x00838B08
		protected override BehaviorTask createTask()
		{
			return new False.FalseTask();
		}

		// Token: 0x02004886 RID: 18566
		private class FalseTask : ConditionBaseTask
		{
			// Token: 0x0601AB2F RID: 109359 RVA: 0x0083A724 File Offset: 0x00838B24
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB30 RID: 109360 RVA: 0x0083A72D File Offset: 0x00838B2D
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB31 RID: 109361 RVA: 0x0083A736 File Offset: 0x00838B36
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB32 RID: 109362 RVA: 0x0083A73F File Offset: 0x00838B3F
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				return EBTStatus.BT_FAILURE;
			}
		}
	}
}
