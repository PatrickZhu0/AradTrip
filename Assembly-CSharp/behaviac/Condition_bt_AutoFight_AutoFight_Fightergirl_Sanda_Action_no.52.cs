using System;

namespace behaviac
{
	// Token: 0x02001F67 RID: 8039
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node81 : Condition
	{
		// Token: 0x06012871 RID: 75889 RVA: 0x0056BC1F File Offset: 0x0056A01F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node81()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012872 RID: 75890 RVA: 0x0056BC54 File Offset: 0x0056A054
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C26B RID: 49771
		private int opl_p0;

		// Token: 0x0400C26C RID: 49772
		private int opl_p1;

		// Token: 0x0400C26D RID: 49773
		private int opl_p2;

		// Token: 0x0400C26E RID: 49774
		private int opl_p3;
	}
}
