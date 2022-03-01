using System;

namespace behaviac
{
	// Token: 0x02003034 RID: 12340
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node22 : Condition
	{
		// Token: 0x06014930 RID: 84272 RVA: 0x0063181F File Offset: 0x0062FC1F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014931 RID: 84273 RVA: 0x00631854 File Offset: 0x0062FC54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E28D RID: 57997
		private int opl_p0;

		// Token: 0x0400E28E RID: 57998
		private int opl_p1;

		// Token: 0x0400E28F RID: 57999
		private int opl_p2;

		// Token: 0x0400E290 RID: 58000
		private int opl_p3;
	}
}
