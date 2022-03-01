using System;

namespace behaviac
{
	// Token: 0x02001E87 RID: 7815
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node10 : Condition
	{
		// Token: 0x060126B9 RID: 75449 RVA: 0x00562B75 File Offset: 0x00560F75
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060126BA RID: 75450 RVA: 0x00562BAC File Offset: 0x00560FAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0A4 RID: 49316
		private int opl_p0;

		// Token: 0x0400C0A5 RID: 49317
		private int opl_p1;

		// Token: 0x0400C0A6 RID: 49318
		private int opl_p2;

		// Token: 0x0400C0A7 RID: 49319
		private int opl_p3;
	}
}
