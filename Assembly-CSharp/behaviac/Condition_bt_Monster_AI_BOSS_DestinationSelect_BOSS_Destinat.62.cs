using System;

namespace behaviac
{
	// Token: 0x0200300D RID: 12301
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node6 : Condition
	{
		// Token: 0x060148E3 RID: 84195 RVA: 0x00630377 File Offset: 0x0062E777
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060148E4 RID: 84196 RVA: 0x006303AC File Offset: 0x0062E7AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E240 RID: 57920
		private int opl_p0;

		// Token: 0x0400E241 RID: 57921
		private int opl_p1;

		// Token: 0x0400E242 RID: 57922
		private int opl_p2;

		// Token: 0x0400E243 RID: 57923
		private int opl_p3;
	}
}
