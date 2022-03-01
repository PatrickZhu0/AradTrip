using System;

namespace behaviac
{
	// Token: 0x02001E66 RID: 7782
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node38 : Condition
	{
		// Token: 0x06012678 RID: 75384 RVA: 0x005617E6 File Offset: 0x0055FBE6
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012679 RID: 75385 RVA: 0x00561818 File Offset: 0x0055FC18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C060 RID: 49248
		private int opl_p0;

		// Token: 0x0400C061 RID: 49249
		private int opl_p1;

		// Token: 0x0400C062 RID: 49250
		private int opl_p2;

		// Token: 0x0400C063 RID: 49251
		private int opl_p3;
	}
}
