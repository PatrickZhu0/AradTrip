using System;

namespace behaviac
{
	// Token: 0x0200304C RID: 12364
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node18 : Condition
	{
		// Token: 0x0601495F RID: 84319 RVA: 0x0063282B File Offset: 0x00630C2B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014960 RID: 84320 RVA: 0x00632860 File Offset: 0x00630C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2BC RID: 58044
		private int opl_p0;

		// Token: 0x0400E2BD RID: 58045
		private int opl_p1;

		// Token: 0x0400E2BE RID: 58046
		private int opl_p2;

		// Token: 0x0400E2BF RID: 58047
		private int opl_p3;
	}
}
