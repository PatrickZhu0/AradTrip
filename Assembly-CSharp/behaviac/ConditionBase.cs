using System;

namespace behaviac
{
	// Token: 0x02004883 RID: 18563
	public abstract class ConditionBase : BehaviorNode
	{
		// Token: 0x0601AB24 RID: 109348 RVA: 0x0054F916 File Offset: 0x0054DD16
		public ConditionBase()
		{
		}

		// Token: 0x0601AB25 RID: 109349 RVA: 0x0054F91E File Offset: 0x0054DD1E
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is ConditionBase && base.IsValid(pAgent, pTask);
		}
	}
}
