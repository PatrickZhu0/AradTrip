using System;

namespace behaviac
{
	// Token: 0x02002738 RID: 10040
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node17 : Condition
	{
		// Token: 0x060137B2 RID: 79794 RVA: 0x005CD73E File Offset: 0x005CBB3E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060137B3 RID: 79795 RVA: 0x005CD774 File Offset: 0x005CBB74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D20B RID: 53771
		private int opl_p0;

		// Token: 0x0400D20C RID: 53772
		private int opl_p1;

		// Token: 0x0400D20D RID: 53773
		private int opl_p2;

		// Token: 0x0400D20E RID: 53774
		private int opl_p3;
	}
}
