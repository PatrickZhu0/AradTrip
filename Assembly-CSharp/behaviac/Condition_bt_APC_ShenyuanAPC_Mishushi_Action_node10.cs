using System;

namespace behaviac
{
	// Token: 0x02001E8C RID: 7820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node10 : Condition
	{
		// Token: 0x060126C2 RID: 75458 RVA: 0x00563445 File Offset: 0x00561845
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node10()
		{
			this.opl_p0 = 0;
			this.opl_p1 = 500;
			this.opl_p2 = 500;
			this.opl_p3 = 500;
		}

		// Token: 0x060126C3 RID: 75459 RVA: 0x00563478 File Offset: 0x00561878
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0AF RID: 49327
		private int opl_p0;

		// Token: 0x0400C0B0 RID: 49328
		private int opl_p1;

		// Token: 0x0400C0B1 RID: 49329
		private int opl_p2;

		// Token: 0x0400C0B2 RID: 49330
		private int opl_p3;
	}
}
