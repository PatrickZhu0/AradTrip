using System;

namespace behaviac
{
	// Token: 0x02004884 RID: 18564
	internal class ConditionBaseTask : LeafTask
	{
		// Token: 0x0601AB27 RID: 109351 RVA: 0x0055019D File Offset: 0x0054E59D
		protected override bool onenter(Agent pAgent)
		{
			return true;
		}

		// Token: 0x0601AB28 RID: 109352 RVA: 0x005501A0 File Offset: 0x0054E5A0
		protected override void onexit(Agent pAgent, EBTStatus s)
		{
		}

		// Token: 0x0601AB29 RID: 109353 RVA: 0x005501A2 File Offset: 0x0054E5A2
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			return EBTStatus.BT_SUCCESS;
		}
	}
}
