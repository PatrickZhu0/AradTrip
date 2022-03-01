using System;

namespace behaviac
{
	// Token: 0x02001D6D RID: 7533
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node16 : Condition
	{
		// Token: 0x06012497 RID: 74903 RVA: 0x00555CCF File Offset: 0x005540CF
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node16()
		{
			this.opl_p0 = 8009;
		}

		// Token: 0x06012498 RID: 74904 RVA: 0x00555CE4 File Offset: 0x005540E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE87 RID: 48775
		private int opl_p0;
	}
}
