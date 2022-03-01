using System;

namespace behaviac
{
	// Token: 0x02003007 RID: 12295
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node30 : Condition
	{
		// Token: 0x060148D8 RID: 84184 RVA: 0x0062F9DB File Offset: 0x0062DDDB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060148D9 RID: 84185 RVA: 0x0062FA10 File Offset: 0x0062DE10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E235 RID: 57909
		private int opl_p0;

		// Token: 0x0400E236 RID: 57910
		private int opl_p1;

		// Token: 0x0400E237 RID: 57911
		private int opl_p2;

		// Token: 0x0400E238 RID: 57912
		private int opl_p3;
	}
}
