using System;

namespace behaviac
{
	// Token: 0x02002748 RID: 10056
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node74 : Condition
	{
		// Token: 0x060137D1 RID: 79825 RVA: 0x005CF261 File Offset: 0x005CD661
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node74()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137D2 RID: 79826 RVA: 0x005CF298 File Offset: 0x005CD698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D22A RID: 53802
		private int opl_p0;

		// Token: 0x0400D22B RID: 53803
		private int opl_p1;

		// Token: 0x0400D22C RID: 53804
		private int opl_p2;

		// Token: 0x0400D22D RID: 53805
		private int opl_p3;
	}
}
