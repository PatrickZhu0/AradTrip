using System;

namespace behaviac
{
	// Token: 0x0200303D RID: 12349
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node34 : Condition
	{
		// Token: 0x06014942 RID: 84290 RVA: 0x00631AE3 File Offset: 0x0062FEE3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014943 RID: 84291 RVA: 0x00631B18 File Offset: 0x0062FF18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E29F RID: 58015
		private int opl_p0;

		// Token: 0x0400E2A0 RID: 58016
		private int opl_p1;

		// Token: 0x0400E2A1 RID: 58017
		private int opl_p2;

		// Token: 0x0400E2A2 RID: 58018
		private int opl_p3;
	}
}
