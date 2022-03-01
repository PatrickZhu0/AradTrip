using System;

namespace behaviac
{
	// Token: 0x0200301C RID: 12316
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node26 : Condition
	{
		// Token: 0x06014901 RID: 84225 RVA: 0x00630813 File Offset: 0x0062EC13
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014902 RID: 84226 RVA: 0x00630848 File Offset: 0x0062EC48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E25E RID: 57950
		private int opl_p0;

		// Token: 0x0400E25F RID: 57951
		private int opl_p1;

		// Token: 0x0400E260 RID: 57952
		private int opl_p2;

		// Token: 0x0400E261 RID: 57953
		private int opl_p3;
	}
}
