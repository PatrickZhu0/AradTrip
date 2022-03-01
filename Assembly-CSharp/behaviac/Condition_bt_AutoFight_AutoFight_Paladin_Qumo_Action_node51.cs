using System;

namespace behaviac
{
	// Token: 0x020027DB RID: 10203
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node51 : Condition
	{
		// Token: 0x060138F5 RID: 80117 RVA: 0x005D514E File Offset: 0x005D354E
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node51()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060138F6 RID: 80118 RVA: 0x005D5184 File Offset: 0x005D3584
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D353 RID: 54099
		private int opl_p0;

		// Token: 0x0400D354 RID: 54100
		private int opl_p1;

		// Token: 0x0400D355 RID: 54101
		private int opl_p2;

		// Token: 0x0400D356 RID: 54102
		private int opl_p3;
	}
}
