using System;

namespace behaviac
{
	// Token: 0x0200306A RID: 12394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node22 : Condition
	{
		// Token: 0x0601499A RID: 84378 RVA: 0x00633A0F File Offset: 0x00631E0F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601499B RID: 84379 RVA: 0x00633A44 File Offset: 0x00631E44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2F7 RID: 58103
		private int opl_p0;

		// Token: 0x0400E2F8 RID: 58104
		private int opl_p1;

		// Token: 0x0400E2F9 RID: 58105
		private int opl_p2;

		// Token: 0x0400E2FA RID: 58106
		private int opl_p3;
	}
}
