using System;

namespace behaviac
{
	// Token: 0x02002759 RID: 10073
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node2 : Condition
	{
		// Token: 0x060137F3 RID: 79859 RVA: 0x005CFA26 File Offset: 0x005CDE26
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node2()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137F4 RID: 79860 RVA: 0x005CFA5C File Offset: 0x005CDE5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D251 RID: 53841
		private int opl_p0;

		// Token: 0x0400D252 RID: 53842
		private int opl_p1;

		// Token: 0x0400D253 RID: 53843
		private int opl_p2;

		// Token: 0x0400D254 RID: 53844
		private int opl_p3;
	}
}
