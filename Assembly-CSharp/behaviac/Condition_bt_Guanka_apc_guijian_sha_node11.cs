using System;

namespace behaviac
{
	// Token: 0x02002A6F RID: 10863
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node11 : Condition
	{
		// Token: 0x06013E05 RID: 81413 RVA: 0x005F5621 File Offset: 0x005F3A21
		public Condition_bt_Guanka_apc_guijian_sha_node11()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013E06 RID: 81414 RVA: 0x005F5640 File Offset: 0x005F3A40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D879 RID: 55417
		private BE_Target opl_p0;

		// Token: 0x0400D87A RID: 55418
		private BE_Equal opl_p1;

		// Token: 0x0400D87B RID: 55419
		private BE_State opl_p2;
	}
}
