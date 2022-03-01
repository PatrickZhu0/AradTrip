using System;

namespace behaviac
{
	// Token: 0x02002FCB RID: 12235
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node14 : Condition
	{
		// Token: 0x06014862 RID: 84066 RVA: 0x0062D7E3 File Offset: 0x0062BBE3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node14()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014863 RID: 84067 RVA: 0x0062D818 File Offset: 0x0062BC18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1BF RID: 57791
		private int opl_p0;

		// Token: 0x0400E1C0 RID: 57792
		private int opl_p1;

		// Token: 0x0400E1C1 RID: 57793
		private int opl_p2;

		// Token: 0x0400E1C2 RID: 57794
		private int opl_p3;
	}
}
