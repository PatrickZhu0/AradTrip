using System;

namespace behaviac
{
	// Token: 0x02002E79 RID: 11897
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node145 : Condition
	{
		// Token: 0x060145CF RID: 83407 RVA: 0x0061C57E File Offset: 0x0061A97E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node145()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1800;
			this.opl_p2 = 1200;
			this.opl_p3 = 1500;
		}

		// Token: 0x060145D0 RID: 83408 RVA: 0x0061C5B4 File Offset: 0x0061A9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF58 RID: 57176
		private int opl_p0;

		// Token: 0x0400DF59 RID: 57177
		private int opl_p1;

		// Token: 0x0400DF5A RID: 57178
		private int opl_p2;

		// Token: 0x0400DF5B RID: 57179
		private int opl_p3;
	}
}
