using System;

namespace behaviac
{
	// Token: 0x02001DD2 RID: 7634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_DestinationSelect_node2 : Condition
	{
		// Token: 0x0601255B RID: 75099 RVA: 0x0055AB0B File Offset: 0x00558F0B
		public Condition_bt_APC_APC_Mishushi_Action_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601255C RID: 75100 RVA: 0x0055AB28 File Offset: 0x00558F28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF4F RID: 48975
		private BE_Target opl_p0;

		// Token: 0x0400BF50 RID: 48976
		private BE_Equal opl_p1;

		// Token: 0x0400BF51 RID: 48977
		private BE_State opl_p2;
	}
}
