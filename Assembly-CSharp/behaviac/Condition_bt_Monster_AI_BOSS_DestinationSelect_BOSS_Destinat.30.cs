using System;

namespace behaviac
{
	// Token: 0x02002FD9 RID: 12249
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node34 : Condition
	{
		// Token: 0x0601487E RID: 84094 RVA: 0x0062DC37 File Offset: 0x0062C037
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601487F RID: 84095 RVA: 0x0062DC6C File Offset: 0x0062C06C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1DC RID: 57820
		private int opl_p0;

		// Token: 0x0400E1DD RID: 57821
		private int opl_p1;

		// Token: 0x0400E1DE RID: 57822
		private int opl_p2;

		// Token: 0x0400E1DF RID: 57823
		private int opl_p3;
	}
}
