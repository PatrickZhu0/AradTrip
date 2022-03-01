using System;

namespace behaviac
{
	// Token: 0x020027BF RID: 10175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node17 : Condition
	{
		// Token: 0x060138BD RID: 80061 RVA: 0x005D4562 File Offset: 0x005D2962
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060138BE RID: 80062 RVA: 0x005D4598 File Offset: 0x005D2998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D31B RID: 54043
		private int opl_p0;

		// Token: 0x0400D31C RID: 54044
		private int opl_p1;

		// Token: 0x0400D31D RID: 54045
		private int opl_p2;

		// Token: 0x0400D31E RID: 54046
		private int opl_p3;
	}
}
