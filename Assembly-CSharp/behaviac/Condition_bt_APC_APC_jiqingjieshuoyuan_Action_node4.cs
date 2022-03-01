using System;

namespace behaviac
{
	// Token: 0x02001D63 RID: 7523
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node4 : Condition
	{
		// Token: 0x06012483 RID: 74883 RVA: 0x005558AF File Offset: 0x00553CAF
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012484 RID: 74884 RVA: 0x005558CC File Offset: 0x00553CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE71 RID: 48753
		private BE_Target opl_p0;

		// Token: 0x0400BE72 RID: 48754
		private BE_Equal opl_p1;

		// Token: 0x0400BE73 RID: 48755
		private BE_State opl_p2;
	}
}
