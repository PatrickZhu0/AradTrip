using System;

namespace behaviac
{
	// Token: 0x02002A83 RID: 10883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node4 : Condition
	{
		// Token: 0x06013E2A RID: 81450 RVA: 0x005F6944 File Offset: 0x005F4D44
		public Condition_bt_Guanka_apc_Mofashi_hua_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013E2B RID: 81451 RVA: 0x005F6964 File Offset: 0x005F4D64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D89E RID: 55454
		private BE_Target opl_p0;

		// Token: 0x0400D89F RID: 55455
		private BE_Equal opl_p1;

		// Token: 0x0400D8A0 RID: 55456
		private BE_State opl_p2;
	}
}
