using System;

namespace behaviac
{
	// Token: 0x02001DB1 RID: 7601
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node5 : Condition
	{
		// Token: 0x0601251B RID: 75035 RVA: 0x005591C1 File Offset: 0x005575C1
		public Condition_bt_APC_APC_Kuangzhan_Action_node5()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601251C RID: 75036 RVA: 0x005591E0 File Offset: 0x005575E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF0C RID: 48908
		private BE_Target opl_p0;

		// Token: 0x0400BF0D RID: 48909
		private BE_Equal opl_p1;

		// Token: 0x0400BF0E RID: 48910
		private BE_State opl_p2;
	}
}
