using System;

namespace behaviac
{
	// Token: 0x0200302B RID: 12331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node10 : Condition
	{
		// Token: 0x0601491E RID: 84254 RVA: 0x0063155B File Offset: 0x0062F95B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601491F RID: 84255 RVA: 0x00631590 File Offset: 0x0062F990
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E27B RID: 57979
		private int opl_p0;

		// Token: 0x0400E27C RID: 57980
		private int opl_p1;

		// Token: 0x0400E27D RID: 57981
		private int opl_p2;

		// Token: 0x0400E27E RID: 57982
		private int opl_p3;
	}
}
