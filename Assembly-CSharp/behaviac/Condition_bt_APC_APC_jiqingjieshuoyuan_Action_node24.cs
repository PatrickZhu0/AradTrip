using System;

namespace behaviac
{
	// Token: 0x02001D72 RID: 7538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node24 : Condition
	{
		// Token: 0x060124A1 RID: 74913 RVA: 0x00555EFB File Offset: 0x005542FB
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node24()
		{
			this.opl_p0 = 8010;
		}

		// Token: 0x060124A2 RID: 74914 RVA: 0x00555F10 File Offset: 0x00554310
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE93 RID: 48787
		private int opl_p0;
	}
}
