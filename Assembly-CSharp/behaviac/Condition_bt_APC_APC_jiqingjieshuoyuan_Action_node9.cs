using System;

namespace behaviac
{
	// Token: 0x02001D67 RID: 7527
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node9 : Condition
	{
		// Token: 0x0601248B RID: 74891 RVA: 0x00555A79 File Offset: 0x00553E79
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node9()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601248C RID: 74892 RVA: 0x00555A8C File Offset: 0x00553E8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE7B RID: 48763
		private float opl_p0;
	}
}
