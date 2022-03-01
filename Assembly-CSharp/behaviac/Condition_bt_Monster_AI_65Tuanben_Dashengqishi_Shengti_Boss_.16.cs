using System;

namespace behaviac
{
	// Token: 0x02002DE6 RID: 11750
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node23 : Condition
	{
		// Token: 0x060144A9 RID: 83113 RVA: 0x00618A8A File Offset: 0x00616E8A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node23()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1510;
			this.opl_p3 = 3010;
		}

		// Token: 0x060144AA RID: 83114 RVA: 0x00618AC0 File Offset: 0x00616EC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE5F RID: 56927
		private int opl_p0;

		// Token: 0x0400DE60 RID: 56928
		private int opl_p1;

		// Token: 0x0400DE61 RID: 56929
		private int opl_p2;

		// Token: 0x0400DE62 RID: 56930
		private int opl_p3;
	}
}
