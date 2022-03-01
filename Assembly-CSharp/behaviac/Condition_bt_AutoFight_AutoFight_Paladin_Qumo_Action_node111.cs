using System;

namespace behaviac
{
	// Token: 0x0200280B RID: 10251
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node111 : Condition
	{
		// Token: 0x06013955 RID: 80213 RVA: 0x005D65BE File Offset: 0x005D49BE
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node111()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013956 RID: 80214 RVA: 0x005D65F4 File Offset: 0x005D49F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3B3 RID: 54195
		private int opl_p0;

		// Token: 0x0400D3B4 RID: 54196
		private int opl_p1;

		// Token: 0x0400D3B5 RID: 54197
		private int opl_p2;

		// Token: 0x0400D3B6 RID: 54198
		private int opl_p3;
	}
}
