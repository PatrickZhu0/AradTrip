using System;

namespace behaviac
{
	// Token: 0x02002745 RID: 10053
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node72 : Condition
	{
		// Token: 0x060137CC RID: 79820 RVA: 0x005CDCA3 File Offset: 0x005CC0A3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node72()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1200;
			this.opl_p3 = 1200;
		}

		// Token: 0x060137CD RID: 79821 RVA: 0x005CDCD8 File Offset: 0x005CC0D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D224 RID: 53796
		private int opl_p0;

		// Token: 0x0400D225 RID: 53797
		private int opl_p1;

		// Token: 0x0400D226 RID: 53798
		private int opl_p2;

		// Token: 0x0400D227 RID: 53799
		private int opl_p3;
	}
}
