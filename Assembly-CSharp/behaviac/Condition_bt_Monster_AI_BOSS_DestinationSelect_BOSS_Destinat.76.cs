using System;

namespace behaviac
{
	// Token: 0x02003022 RID: 12322
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node34 : Condition
	{
		// Token: 0x0601490D RID: 84237 RVA: 0x006309EB File Offset: 0x0062EDEB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601490E RID: 84238 RVA: 0x00630A20 File Offset: 0x0062EE20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E26A RID: 57962
		private int opl_p0;

		// Token: 0x0400E26B RID: 57963
		private int opl_p1;

		// Token: 0x0400E26C RID: 57964
		private int opl_p2;

		// Token: 0x0400E26D RID: 57965
		private int opl_p3;
	}
}
