using System;

namespace behaviac
{
	// Token: 0x02002AD4 RID: 10964
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Yindao_Aganzhuo_node4 : Condition
	{
		// Token: 0x06013EC2 RID: 81602 RVA: 0x005FA919 File Offset: 0x005F8D19
		public Condition_bt_Guanka_apc_Yindao_Aganzhuo_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013EC3 RID: 81603 RVA: 0x005FA938 File Offset: 0x005F8D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D935 RID: 55605
		private BE_Target opl_p0;

		// Token: 0x0400D936 RID: 55606
		private BE_Equal opl_p1;

		// Token: 0x0400D937 RID: 55607
		private BE_State opl_p2;
	}
}
