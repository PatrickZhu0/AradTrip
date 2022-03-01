using System;

namespace behaviac
{
	// Token: 0x02002DE9 RID: 11753
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node19 : Condition
	{
		// Token: 0x060144AF RID: 83119 RVA: 0x00618BFA File Offset: 0x00616FFA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node19()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1800;
			this.opl_p2 = 1200;
			this.opl_p3 = 1500;
		}

		// Token: 0x060144B0 RID: 83120 RVA: 0x00618C30 File Offset: 0x00617030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE66 RID: 56934
		private int opl_p0;

		// Token: 0x0400DE67 RID: 56935
		private int opl_p1;

		// Token: 0x0400DE68 RID: 56936
		private int opl_p2;

		// Token: 0x0400DE69 RID: 56937
		private int opl_p3;
	}
}
