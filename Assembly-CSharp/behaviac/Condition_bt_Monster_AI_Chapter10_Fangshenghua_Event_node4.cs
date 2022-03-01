using System;

namespace behaviac
{
	// Token: 0x020030F6 RID: 12534
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Fangshenghua_Event_node4 : Condition
	{
		// Token: 0x06014A9B RID: 84635 RVA: 0x00638F3F File Offset: 0x0063733F
		public Condition_bt_Monster_AI_Chapter10_Fangshenghua_Event_node4()
		{
			this.opl_p0 = 2000;
		}

		// Token: 0x06014A9C RID: 84636 RVA: 0x00638F54 File Offset: 0x00637354
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveTargetInArea(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E410 RID: 58384
		private int opl_p0;
	}
}
