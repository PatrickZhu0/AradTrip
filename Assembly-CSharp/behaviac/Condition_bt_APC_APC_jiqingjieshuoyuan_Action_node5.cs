using System;

namespace behaviac
{
	// Token: 0x02001D64 RID: 7524
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node5 : Condition
	{
		// Token: 0x06012485 RID: 74885 RVA: 0x0055590B File Offset: 0x00553D0B
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node5()
		{
			this.opl_p0 = 8007;
		}

		// Token: 0x06012486 RID: 74886 RVA: 0x00555920 File Offset: 0x00553D20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE74 RID: 48756
		private int opl_p0;
	}
}
