using System;

namespace behaviac
{
	// Token: 0x02001E9C RID: 7836
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node42 : Condition
	{
		// Token: 0x060126E2 RID: 75490 RVA: 0x00563B16 File Offset: 0x00561F16
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node42()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060126E3 RID: 75491 RVA: 0x00563B4C File Offset: 0x00561F4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0CF RID: 49359
		private int opl_p0;

		// Token: 0x0400C0D0 RID: 49360
		private int opl_p1;

		// Token: 0x0400C0D1 RID: 49361
		private int opl_p2;

		// Token: 0x0400C0D2 RID: 49362
		private int opl_p3;
	}
}
