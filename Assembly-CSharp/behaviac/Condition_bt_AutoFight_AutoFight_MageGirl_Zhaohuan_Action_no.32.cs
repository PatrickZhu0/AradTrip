using System;

namespace behaviac
{
	// Token: 0x02002773 RID: 10099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node69 : Condition
	{
		// Token: 0x06013827 RID: 79911 RVA: 0x005D0582 File Offset: 0x005CE982
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node69()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013828 RID: 79912 RVA: 0x005D05B8 File Offset: 0x005CE9B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D287 RID: 53895
		private int opl_p0;

		// Token: 0x0400D288 RID: 53896
		private int opl_p1;

		// Token: 0x0400D289 RID: 53897
		private int opl_p2;

		// Token: 0x0400D28A RID: 53898
		private int opl_p3;
	}
}
