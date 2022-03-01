using System;

namespace behaviac
{
	// Token: 0x02001E40 RID: 7744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node6 : Condition
	{
		// Token: 0x0601262D RID: 75309 RVA: 0x0055F8D0 File Offset: 0x0055DCD0
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node6()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601262E RID: 75310 RVA: 0x0055F904 File Offset: 0x0055DD04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C013 RID: 49171
		private int opl_p0;

		// Token: 0x0400C014 RID: 49172
		private int opl_p1;

		// Token: 0x0400C015 RID: 49173
		private int opl_p2;

		// Token: 0x0400C016 RID: 49174
		private int opl_p3;
	}
}
