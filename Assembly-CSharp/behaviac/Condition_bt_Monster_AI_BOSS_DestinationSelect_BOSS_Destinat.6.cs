using System;

namespace behaviac
{
	// Token: 0x02002FB3 RID: 12211
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node14 : Condition
	{
		// Token: 0x06014833 RID: 84019 RVA: 0x0062C8BF File Offset: 0x0062ACBF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node14()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014834 RID: 84020 RVA: 0x0062C8F4 File Offset: 0x0062ACF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E190 RID: 57744
		private int opl_p0;

		// Token: 0x0400E191 RID: 57745
		private int opl_p1;

		// Token: 0x0400E192 RID: 57746
		private int opl_p2;

		// Token: 0x0400E193 RID: 57747
		private int opl_p3;
	}
}
