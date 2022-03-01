using System;

namespace behaviac
{
	// Token: 0x02002A17 RID: 10775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node10 : Condition
	{
		// Token: 0x06013D5D RID: 81245 RVA: 0x005F0816 File Offset: 0x005EEC16
		public Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node10()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D5E RID: 81246 RVA: 0x005F084C File Offset: 0x005EEC4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7C8 RID: 55240
		private int opl_p0;

		// Token: 0x0400D7C9 RID: 55241
		private int opl_p1;

		// Token: 0x0400D7CA RID: 55242
		private int opl_p2;

		// Token: 0x0400D7CB RID: 55243
		private int opl_p3;
	}
}
