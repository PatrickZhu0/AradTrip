using System;

namespace behaviac
{
	// Token: 0x02002702 RID: 9986
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node8 : Condition
	{
		// Token: 0x06013746 RID: 79686 RVA: 0x005CC059 File Offset: 0x005CA459
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node8()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06013747 RID: 79687 RVA: 0x005CC090 File Offset: 0x005CA490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D19C RID: 53660
		private int opl_p0;

		// Token: 0x0400D19D RID: 53661
		private int opl_p1;

		// Token: 0x0400D19E RID: 53662
		private int opl_p2;

		// Token: 0x0400D19F RID: 53663
		private int opl_p3;
	}
}
