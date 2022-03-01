using System;

namespace behaviac
{
	// Token: 0x0200305A RID: 12378
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node38 : Condition
	{
		// Token: 0x0601497B RID: 84347 RVA: 0x00632C7F File Offset: 0x0063107F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node38()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601497C RID: 84348 RVA: 0x00632CB4 File Offset: 0x006310B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2D9 RID: 58073
		private int opl_p0;

		// Token: 0x0400E2DA RID: 58074
		private int opl_p1;

		// Token: 0x0400E2DB RID: 58075
		private int opl_p2;

		// Token: 0x0400E2DC RID: 58076
		private int opl_p3;
	}
}
