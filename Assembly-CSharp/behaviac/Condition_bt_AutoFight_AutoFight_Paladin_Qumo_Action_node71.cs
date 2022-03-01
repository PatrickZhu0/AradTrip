using System;

namespace behaviac
{
	// Token: 0x020027EF RID: 10223
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node71 : Condition
	{
		// Token: 0x0601391D RID: 80157 RVA: 0x005D59D2 File Offset: 0x005D3DD2
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node71()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601391E RID: 80158 RVA: 0x005D5A08 File Offset: 0x005D3E08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D37B RID: 54139
		private int opl_p0;

		// Token: 0x0400D37C RID: 54140
		private int opl_p1;

		// Token: 0x0400D37D RID: 54141
		private int opl_p2;

		// Token: 0x0400D37E RID: 54142
		private int opl_p3;
	}
}
