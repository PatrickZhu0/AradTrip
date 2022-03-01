using System;

namespace behaviac
{
	// Token: 0x02001FAC RID: 8108
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node8 : Condition
	{
		// Token: 0x060128F6 RID: 76022 RVA: 0x005701BF File Offset: 0x0056E5BF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128F7 RID: 76023 RVA: 0x005701F4 File Offset: 0x0056E5F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2E7 RID: 49895
		private int opl_p0;

		// Token: 0x0400C2E8 RID: 49896
		private int opl_p1;

		// Token: 0x0400C2E9 RID: 49897
		private int opl_p2;

		// Token: 0x0400C2EA RID: 49898
		private int opl_p3;
	}
}
