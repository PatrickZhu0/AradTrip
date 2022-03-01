using System;

namespace behaviac
{
	// Token: 0x02001D62 RID: 7522
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node3 : Condition
	{
		// Token: 0x06012481 RID: 74881 RVA: 0x00555869 File Offset: 0x00553C69
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node3()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012482 RID: 74882 RVA: 0x0055587C File Offset: 0x00553C7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE70 RID: 48752
		private float opl_p0;
	}
}
