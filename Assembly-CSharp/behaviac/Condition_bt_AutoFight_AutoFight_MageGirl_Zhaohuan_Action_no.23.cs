using System;

namespace behaviac
{
	// Token: 0x02002767 RID: 10087
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node42 : Condition
	{
		// Token: 0x0601380F RID: 79887 RVA: 0x005D0066 File Offset: 0x005CE466
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node42()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013810 RID: 79888 RVA: 0x005D009C File Offset: 0x005CE49C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D26F RID: 53871
		private int opl_p0;

		// Token: 0x0400D270 RID: 53872
		private int opl_p1;

		// Token: 0x0400D271 RID: 53873
		private int opl_p2;

		// Token: 0x0400D272 RID: 53874
		private int opl_p3;
	}
}
