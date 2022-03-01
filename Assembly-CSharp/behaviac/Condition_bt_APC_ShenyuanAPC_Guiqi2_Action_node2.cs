using System;

namespace behaviac
{
	// Token: 0x02001E4C RID: 7756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node2 : Condition
	{
		// Token: 0x06012645 RID: 75333 RVA: 0x0055FDEA File Offset: 0x0055E1EA
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012646 RID: 75334 RVA: 0x0055FE1C File Offset: 0x0055E21C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C02B RID: 49195
		private int opl_p0;

		// Token: 0x0400C02C RID: 49196
		private int opl_p1;

		// Token: 0x0400C02D RID: 49197
		private int opl_p2;

		// Token: 0x0400C02E RID: 49198
		private int opl_p3;
	}
}
