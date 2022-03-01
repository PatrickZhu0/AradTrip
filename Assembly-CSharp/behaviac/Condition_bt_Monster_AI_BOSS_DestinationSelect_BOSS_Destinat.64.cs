using System;

namespace behaviac
{
	// Token: 0x02003010 RID: 12304
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node10 : Condition
	{
		// Token: 0x060148E9 RID: 84201 RVA: 0x00630463 File Offset: 0x0062E863
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060148EA RID: 84202 RVA: 0x00630498 File Offset: 0x0062E898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E246 RID: 57926
		private int opl_p0;

		// Token: 0x0400E247 RID: 57927
		private int opl_p1;

		// Token: 0x0400E248 RID: 57928
		private int opl_p2;

		// Token: 0x0400E249 RID: 57929
		private int opl_p3;
	}
}
