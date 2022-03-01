using System;

namespace behaviac
{
	// Token: 0x02001D68 RID: 7528
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node10 : Condition
	{
		// Token: 0x0601248D RID: 74893 RVA: 0x00555ABF File Offset: 0x00553EBF
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node10()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601248E RID: 74894 RVA: 0x00555ADC File Offset: 0x00553EDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE7C RID: 48764
		private BE_Target opl_p0;

		// Token: 0x0400BE7D RID: 48765
		private BE_Equal opl_p1;

		// Token: 0x0400BE7E RID: 48766
		private BE_State opl_p2;
	}
}
