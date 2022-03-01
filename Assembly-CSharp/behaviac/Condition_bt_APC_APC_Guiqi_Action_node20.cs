using System;

namespace behaviac
{
	// Token: 0x02001D39 RID: 7481
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node20 : Condition
	{
		// Token: 0x06012434 RID: 74804 RVA: 0x00553992 File Offset: 0x00551D92
		public Condition_bt_APC_APC_Guiqi_Action_node20()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06012435 RID: 74805 RVA: 0x005539C8 File Offset: 0x00551DC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE24 RID: 48676
		private int opl_p0;

		// Token: 0x0400BE25 RID: 48677
		private int opl_p1;

		// Token: 0x0400BE26 RID: 48678
		private int opl_p2;

		// Token: 0x0400BE27 RID: 48679
		private int opl_p3;
	}
}
