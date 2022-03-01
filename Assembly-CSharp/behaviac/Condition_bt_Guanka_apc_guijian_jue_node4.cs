using System;

namespace behaviac
{
	// Token: 0x02002A57 RID: 10839
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node4 : Condition
	{
		// Token: 0x06013DD8 RID: 81368 RVA: 0x005F4195 File Offset: 0x005F2595
		public Condition_bt_Guanka_apc_guijian_jue_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013DD9 RID: 81369 RVA: 0x005F41B4 File Offset: 0x005F25B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D84C RID: 55372
		private BE_Target opl_p0;

		// Token: 0x0400D84D RID: 55373
		private BE_Equal opl_p1;

		// Token: 0x0400D84E RID: 55374
		private BE_State opl_p2;
	}
}
