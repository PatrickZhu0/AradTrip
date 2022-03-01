using System;

namespace behaviac
{
	// Token: 0x02002A1D RID: 10781
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node20 : Condition
	{
		// Token: 0x06013D69 RID: 81257 RVA: 0x005F0BB7 File Offset: 0x005EEFB7
		public Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node20()
		{
			this.opl_p0 = 2508;
		}

		// Token: 0x06013D6A RID: 81258 RVA: 0x005F0BCC File Offset: 0x005EEFCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7D7 RID: 55255
		private int opl_p0;
	}
}
