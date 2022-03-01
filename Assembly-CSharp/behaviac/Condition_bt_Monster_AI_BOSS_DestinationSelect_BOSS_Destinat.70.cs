using System;

namespace behaviac
{
	// Token: 0x02003019 RID: 12313
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node22 : Condition
	{
		// Token: 0x060148FB RID: 84219 RVA: 0x00630727 File Offset: 0x0062EB27
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060148FC RID: 84220 RVA: 0x0063075C File Offset: 0x0062EB5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E258 RID: 57944
		private int opl_p0;

		// Token: 0x0400E259 RID: 57945
		private int opl_p1;

		// Token: 0x0400E25A RID: 57946
		private int opl_p2;

		// Token: 0x0400E25B RID: 57947
		private int opl_p3;
	}
}
