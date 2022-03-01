using System;

namespace behaviac
{
	// Token: 0x02001EA1 RID: 7841
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2 : Condition
	{
		// Token: 0x060126EB RID: 75499 RVA: 0x005642FE File Offset: 0x005626FE
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060126EC RID: 75500 RVA: 0x0056431C File Offset: 0x0056271C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0D7 RID: 49367
		private BE_Target opl_p0;

		// Token: 0x0400C0D8 RID: 49368
		private BE_Equal opl_p1;

		// Token: 0x0400C0D9 RID: 49369
		private BE_State opl_p2;
	}
}
