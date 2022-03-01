using System;

namespace behaviac
{
	// Token: 0x02002698 RID: 9880
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node21 : Condition
	{
		// Token: 0x06013674 RID: 79476 RVA: 0x005C6E7A File Offset: 0x005C527A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node21()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013675 RID: 79477 RVA: 0x005C6EB0 File Offset: 0x005C52B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0C7 RID: 53447
		private int opl_p0;

		// Token: 0x0400D0C8 RID: 53448
		private int opl_p1;

		// Token: 0x0400D0C9 RID: 53449
		private int opl_p2;

		// Token: 0x0400D0CA RID: 53450
		private int opl_p3;
	}
}
