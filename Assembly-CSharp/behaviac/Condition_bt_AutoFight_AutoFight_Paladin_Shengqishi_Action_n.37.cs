using System;

namespace behaviac
{
	// Token: 0x02002843 RID: 10307
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node23 : Condition
	{
		// Token: 0x060139C4 RID: 80324 RVA: 0x005D993A File Offset: 0x005D7D3A
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139C5 RID: 80325 RVA: 0x005D9970 File Offset: 0x005D7D70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D41C RID: 54300
		private int opl_p0;

		// Token: 0x0400D41D RID: 54301
		private int opl_p1;

		// Token: 0x0400D41E RID: 54302
		private int opl_p2;

		// Token: 0x0400D41F RID: 54303
		private int opl_p3;
	}
}
