using System;

namespace behaviac
{
	// Token: 0x020036BD RID: 14013
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4 : Condition
	{
		// Token: 0x06015593 RID: 87443 RVA: 0x00670B73 File Offset: 0x0066EF73
		public Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015594 RID: 87444 RVA: 0x00670BA8 File Offset: 0x0066EFA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF65 RID: 61285
		private int opl_p0;

		// Token: 0x0400EF66 RID: 61286
		private int opl_p1;

		// Token: 0x0400EF67 RID: 61287
		private int opl_p2;

		// Token: 0x0400EF68 RID: 61288
		private int opl_p3;
	}
}
