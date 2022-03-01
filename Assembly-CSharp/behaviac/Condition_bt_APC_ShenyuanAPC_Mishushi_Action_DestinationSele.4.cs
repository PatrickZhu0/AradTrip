using System;

namespace behaviac
{
	// Token: 0x02001EA6 RID: 7846
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node9 : Condition
	{
		// Token: 0x060126F5 RID: 75509 RVA: 0x00564471 File Offset: 0x00562871
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node9()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060126F6 RID: 75510 RVA: 0x005644A8 File Offset: 0x005628A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0E1 RID: 49377
		private int opl_p0;

		// Token: 0x0400C0E2 RID: 49378
		private int opl_p1;

		// Token: 0x0400C0E3 RID: 49379
		private int opl_p2;

		// Token: 0x0400C0E4 RID: 49380
		private int opl_p3;
	}
}
