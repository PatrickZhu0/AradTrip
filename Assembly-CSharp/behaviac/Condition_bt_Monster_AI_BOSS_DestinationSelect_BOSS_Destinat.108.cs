using System;

namespace behaviac
{
	// Token: 0x02003055 RID: 12373
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node30 : Condition
	{
		// Token: 0x06014971 RID: 84337 RVA: 0x00632AEF File Offset: 0x00630EEF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014972 RID: 84338 RVA: 0x00632B24 File Offset: 0x00630F24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2CE RID: 58062
		private int opl_p0;

		// Token: 0x0400E2CF RID: 58063
		private int opl_p1;

		// Token: 0x0400E2D0 RID: 58064
		private int opl_p2;

		// Token: 0x0400E2D1 RID: 58065
		private int opl_p3;
	}
}
