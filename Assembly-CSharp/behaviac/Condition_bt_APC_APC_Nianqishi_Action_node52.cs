using System;

namespace behaviac
{
	// Token: 0x02001DDC RID: 7644
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node52 : Condition
	{
		// Token: 0x0601256E RID: 75118 RVA: 0x0055B067 File Offset: 0x00559467
		public Condition_bt_APC_APC_Nianqishi_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601256F RID: 75119 RVA: 0x0055B084 File Offset: 0x00559484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF5E RID: 48990
		private BE_Target opl_p0;

		// Token: 0x0400BF5F RID: 48991
		private BE_Equal opl_p1;

		// Token: 0x0400BF60 RID: 48992
		private BE_State opl_p2;
	}
}
