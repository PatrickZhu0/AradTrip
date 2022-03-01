using System;

namespace behaviac
{
	// Token: 0x02003745 RID: 14149
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node1 : Condition
	{
		// Token: 0x06015693 RID: 87699 RVA: 0x00675D5A File Offset: 0x0067415A
		public Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node1()
		{
			this.opl_p0 = 2700;
			this.opl_p1 = 2700;
			this.opl_p2 = 2700;
			this.opl_p3 = 2700;
		}

		// Token: 0x06015694 RID: 87700 RVA: 0x00675D90 File Offset: 0x00674190
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F06A RID: 61546
		private int opl_p0;

		// Token: 0x0400F06B RID: 61547
		private int opl_p1;

		// Token: 0x0400F06C RID: 61548
		private int opl_p2;

		// Token: 0x0400F06D RID: 61549
		private int opl_p3;
	}
}
