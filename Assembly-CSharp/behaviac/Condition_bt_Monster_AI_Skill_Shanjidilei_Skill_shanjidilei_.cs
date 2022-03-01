using System;

namespace behaviac
{
	// Token: 0x02003741 RID: 14145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_node1 : Condition
	{
		// Token: 0x0601568C RID: 87692 RVA: 0x00675B23 File Offset: 0x00673F23
		public Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_node1()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 1800;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x0601568D RID: 87693 RVA: 0x00675B58 File Offset: 0x00673F58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F05E RID: 61534
		private int opl_p0;

		// Token: 0x0400F05F RID: 61535
		private int opl_p1;

		// Token: 0x0400F060 RID: 61536
		private int opl_p2;

		// Token: 0x0400F061 RID: 61537
		private int opl_p3;
	}
}
