using System;

namespace behaviac
{
	// Token: 0x02002750 RID: 10064
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node53 : Condition
	{
		// Token: 0x060137E1 RID: 79841 RVA: 0x005CF5E2 File Offset: 0x005CD9E2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node53()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137E2 RID: 79842 RVA: 0x005CF618 File Offset: 0x005CDA18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D23C RID: 53820
		private int opl_p0;

		// Token: 0x0400D23D RID: 53821
		private int opl_p1;

		// Token: 0x0400D23E RID: 53822
		private int opl_p2;

		// Token: 0x0400D23F RID: 53823
		private int opl_p3;
	}
}
