using System;

namespace behaviac
{
	// Token: 0x02001EC3 RID: 7875
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node2 : Condition
	{
		// Token: 0x0601272D RID: 75565 RVA: 0x005659D8 File Offset: 0x00563DD8
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601272E RID: 75566 RVA: 0x005659F8 File Offset: 0x00563DF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C11B RID: 49435
		private BE_Target opl_p0;

		// Token: 0x0400C11C RID: 49436
		private BE_Equal opl_p1;

		// Token: 0x0400C11D RID: 49437
		private BE_State opl_p2;
	}
}
