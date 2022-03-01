using System;

namespace behaviac
{
	// Token: 0x02002707 RID: 9991
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node74 : Condition
	{
		// Token: 0x06013750 RID: 79696 RVA: 0x005CC26E File Offset: 0x005CA66E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node74()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06013751 RID: 79697 RVA: 0x005CC2A4 File Offset: 0x005CA6A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1A7 RID: 53671
		private int opl_p0;

		// Token: 0x0400D1A8 RID: 53672
		private int opl_p1;

		// Token: 0x0400D1A9 RID: 53673
		private int opl_p2;

		// Token: 0x0400D1AA RID: 53674
		private int opl_p3;
	}
}
