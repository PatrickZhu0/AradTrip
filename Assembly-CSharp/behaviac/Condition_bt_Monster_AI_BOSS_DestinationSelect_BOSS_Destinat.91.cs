using System;

namespace behaviac
{
	// Token: 0x0200303A RID: 12346
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node30 : Condition
	{
		// Token: 0x0601493C RID: 84284 RVA: 0x006319F7 File Offset: 0x0062FDF7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601493D RID: 84285 RVA: 0x00631A2C File Offset: 0x0062FE2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E299 RID: 58009
		private int opl_p0;

		// Token: 0x0400E29A RID: 58010
		private int opl_p1;

		// Token: 0x0400E29B RID: 58011
		private int opl_p2;

		// Token: 0x0400E29C RID: 58012
		private int opl_p3;
	}
}
