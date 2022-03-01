using System;

namespace behaviac
{
	// Token: 0x0200303F RID: 12351
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node38 : Condition
	{
		// Token: 0x06014946 RID: 84294 RVA: 0x00631B87 File Offset: 0x0062FF87
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node38()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014947 RID: 84295 RVA: 0x00631BBC File Offset: 0x0062FFBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2A4 RID: 58020
		private int opl_p0;

		// Token: 0x0400E2A5 RID: 58021
		private int opl_p1;

		// Token: 0x0400E2A6 RID: 58022
		private int opl_p2;

		// Token: 0x0400E2A7 RID: 58023
		private int opl_p3;
	}
}
