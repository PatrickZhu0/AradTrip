using System;

namespace behaviac
{
	// Token: 0x02002A91 RID: 10897
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node4 : Condition
	{
		// Token: 0x06013E44 RID: 81476 RVA: 0x005F7360 File Offset: 0x005F5760
		public Condition_bt_Guanka_apc_Mofashi_li_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013E45 RID: 81477 RVA: 0x005F7380 File Offset: 0x005F5780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8B8 RID: 55480
		private BE_Target opl_p0;

		// Token: 0x0400D8B9 RID: 55481
		private BE_Equal opl_p1;

		// Token: 0x0400D8BA RID: 55482
		private BE_State opl_p2;
	}
}
