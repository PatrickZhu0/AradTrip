using System;

namespace behaviac
{
	// Token: 0x02002A37 RID: 10807
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node4 : Condition
	{
		// Token: 0x06013D9A RID: 81306 RVA: 0x005F2545 File Offset: 0x005F0945
		public Condition_bt_Guanka_apc_guijian_cha_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013D9B RID: 81307 RVA: 0x005F2564 File Offset: 0x005F0964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D80A RID: 55306
		private BE_Target opl_p0;

		// Token: 0x0400D80B RID: 55307
		private BE_Equal opl_p1;

		// Token: 0x0400D80C RID: 55308
		private BE_State opl_p2;
	}
}
