using System;

namespace behaviac
{
	// Token: 0x02001D6C RID: 7532
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node15 : Condition
	{
		// Token: 0x06012495 RID: 74901 RVA: 0x00555C89 File Offset: 0x00554089
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node15()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06012496 RID: 74902 RVA: 0x00555C9C File Offset: 0x0055409C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE86 RID: 48774
		private float opl_p0;
	}
}
