using System;

namespace behaviac
{
	// Token: 0x02001FB8 RID: 8120
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node23 : Condition
	{
		// Token: 0x0601290E RID: 76046 RVA: 0x005707F3 File Offset: 0x0056EBF3
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601290F RID: 76047 RVA: 0x00570828 File Offset: 0x0056EC28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2FF RID: 49919
		private int opl_p0;

		// Token: 0x0400C300 RID: 49920
		private int opl_p1;

		// Token: 0x0400C301 RID: 49921
		private int opl_p2;

		// Token: 0x0400C302 RID: 49922
		private int opl_p3;
	}
}
