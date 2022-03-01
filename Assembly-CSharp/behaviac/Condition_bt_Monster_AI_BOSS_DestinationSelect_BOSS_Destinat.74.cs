using System;

namespace behaviac
{
	// Token: 0x0200301F RID: 12319
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node30 : Condition
	{
		// Token: 0x06014907 RID: 84231 RVA: 0x006308FF File Offset: 0x0062ECFF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014908 RID: 84232 RVA: 0x00630934 File Offset: 0x0062ED34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E264 RID: 57956
		private int opl_p0;

		// Token: 0x0400E265 RID: 57957
		private int opl_p1;

		// Token: 0x0400E266 RID: 57958
		private int opl_p2;

		// Token: 0x0400E267 RID: 57959
		private int opl_p3;
	}
}
