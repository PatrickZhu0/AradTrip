using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004889 RID: 18569
	public class True : ConditionBase
	{
		// Token: 0x0601AB3E RID: 109374 RVA: 0x0083A848 File Offset: 0x00838C48
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB3F RID: 109375 RVA: 0x0083A853 File Offset: 0x00838C53
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is True && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB40 RID: 109376 RVA: 0x0083A870 File Offset: 0x00838C70
		protected override BehaviorTask createTask()
		{
			return new True.TrueTask();
		}

		// Token: 0x0200488A RID: 18570
		private class TrueTask : ConditionBaseTask
		{
			// Token: 0x0601AB42 RID: 109378 RVA: 0x0083A88C File Offset: 0x00838C8C
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB43 RID: 109379 RVA: 0x0083A895 File Offset: 0x00838C95
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB44 RID: 109380 RVA: 0x0083A89E File Offset: 0x00838C9E
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB45 RID: 109381 RVA: 0x0083A8A7 File Offset: 0x00838CA7
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				return EBTStatus.BT_SUCCESS;
			}
		}
	}
}
