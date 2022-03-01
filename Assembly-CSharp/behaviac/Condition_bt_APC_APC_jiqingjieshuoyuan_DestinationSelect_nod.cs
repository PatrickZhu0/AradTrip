using System;

namespace behaviac
{
	// Token: 0x02001D75 RID: 7541
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node2 : Condition
	{
		// Token: 0x060124A6 RID: 74918 RVA: 0x005565E9 File Offset: 0x005549E9
		public Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060124A7 RID: 74919 RVA: 0x00556608 File Offset: 0x00554A08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE96 RID: 48790
		private BE_Target opl_p0;

		// Token: 0x0400BE97 RID: 48791
		private BE_Equal opl_p1;

		// Token: 0x0400BE98 RID: 48792
		private BE_State opl_p2;
	}
}
