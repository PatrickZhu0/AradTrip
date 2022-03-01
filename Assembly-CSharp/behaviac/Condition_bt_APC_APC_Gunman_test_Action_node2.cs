using System;

namespace behaviac
{
	// Token: 0x02001D3F RID: 7487
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Gunman_test_Action_node2 : Condition
	{
		// Token: 0x0601243F RID: 74815 RVA: 0x00554109 File Offset: 0x00552509
		public Condition_bt_APC_APC_Gunman_test_Action_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 500;
			this.opl_p3 = 500;
		}

		// Token: 0x06012440 RID: 74816 RVA: 0x00554140 File Offset: 0x00552540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE30 RID: 48688
		private int opl_p0;

		// Token: 0x0400BE31 RID: 48689
		private int opl_p1;

		// Token: 0x0400BE32 RID: 48690
		private int opl_p2;

		// Token: 0x0400BE33 RID: 48691
		private int opl_p3;
	}
}
