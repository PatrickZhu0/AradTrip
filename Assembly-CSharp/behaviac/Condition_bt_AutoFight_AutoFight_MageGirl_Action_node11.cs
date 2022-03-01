using System;

namespace behaviac
{
	// Token: 0x02002688 RID: 9864
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node11 : Condition
	{
		// Token: 0x06013654 RID: 79444 RVA: 0x005C67AA File Offset: 0x005C4BAA
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node11()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013655 RID: 79445 RVA: 0x005C67E0 File Offset: 0x005C4BE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0A7 RID: 53415
		private int opl_p0;

		// Token: 0x0400D0A8 RID: 53416
		private int opl_p1;

		// Token: 0x0400D0A9 RID: 53417
		private int opl_p2;

		// Token: 0x0400D0AA RID: 53418
		private int opl_p3;
	}
}
