using System;

namespace behaviac
{
	// Token: 0x02001E90 RID: 7824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node88 : Condition
	{
		// Token: 0x060126CA RID: 75466 RVA: 0x005635FA File Offset: 0x005619FA
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node88()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060126CB RID: 75467 RVA: 0x00563630 File Offset: 0x00561A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0B7 RID: 49335
		private int opl_p0;

		// Token: 0x0400C0B8 RID: 49336
		private int opl_p1;

		// Token: 0x0400C0B9 RID: 49337
		private int opl_p2;

		// Token: 0x0400C0BA RID: 49338
		private int opl_p3;
	}
}
