using System;

namespace behaviac
{
	// Token: 0x0200272C RID: 10028
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node63 : Condition
	{
		// Token: 0x0601379A RID: 79770 RVA: 0x005CD222 File Offset: 0x005CB622
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node63()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601379B RID: 79771 RVA: 0x005CD258 File Offset: 0x005CB658
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1F3 RID: 53747
		private int opl_p0;

		// Token: 0x0400D1F4 RID: 53748
		private int opl_p1;

		// Token: 0x0400D1F5 RID: 53749
		private int opl_p2;

		// Token: 0x0400D1F6 RID: 53750
		private int opl_p3;
	}
}
