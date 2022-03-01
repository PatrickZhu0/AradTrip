using System;

namespace behaviac
{
	// Token: 0x02001D47 RID: 7495
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Gunman_test_DestinationSelect_node4 : Condition
	{
		// Token: 0x0601244E RID: 74830 RVA: 0x005546DE File Offset: 0x00552ADE
		public Condition_bt_APC_APC_Gunman_test_DestinationSelect_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601244F RID: 74831 RVA: 0x005546FC File Offset: 0x00552AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE40 RID: 48704
		private BE_Target opl_p0;

		// Token: 0x0400BE41 RID: 48705
		private BE_Equal opl_p1;

		// Token: 0x0400BE42 RID: 48706
		private BE_State opl_p2;
	}
}
