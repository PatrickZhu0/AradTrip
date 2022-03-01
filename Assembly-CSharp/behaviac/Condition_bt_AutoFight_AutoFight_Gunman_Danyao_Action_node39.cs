using System;

namespace behaviac
{
	// Token: 0x020025B9 RID: 9657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node39 : Condition
	{
		// Token: 0x060134B9 RID: 79033 RVA: 0x005BCB1B File Offset: 0x005BAF1B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node39()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060134BA RID: 79034 RVA: 0x005BCB50 File Offset: 0x005BAF50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEF5 RID: 52981
		private int opl_p0;

		// Token: 0x0400CEF6 RID: 52982
		private int opl_p1;

		// Token: 0x0400CEF7 RID: 52983
		private int opl_p2;

		// Token: 0x0400CEF8 RID: 52984
		private int opl_p3;
	}
}
