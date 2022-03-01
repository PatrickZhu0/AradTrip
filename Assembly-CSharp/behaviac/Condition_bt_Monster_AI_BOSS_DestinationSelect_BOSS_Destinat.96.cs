using System;

namespace behaviac
{
	// Token: 0x02003043 RID: 12355
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node6 : Condition
	{
		// Token: 0x0601494D RID: 84301 RVA: 0x00632567 File Offset: 0x00630967
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601494E RID: 84302 RVA: 0x0063259C File Offset: 0x0063099C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2AA RID: 58026
		private int opl_p0;

		// Token: 0x0400E2AB RID: 58027
		private int opl_p1;

		// Token: 0x0400E2AC RID: 58028
		private int opl_p2;

		// Token: 0x0400E2AD RID: 58029
		private int opl_p3;
	}
}
