using System;

namespace behaviac
{
	// Token: 0x02001E86 RID: 7814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node2 : Condition
	{
		// Token: 0x060126B7 RID: 75447 RVA: 0x00562AFE File Offset: 0x00560EFE
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060126B8 RID: 75448 RVA: 0x00562B30 File Offset: 0x00560F30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0A0 RID: 49312
		private int opl_p0;

		// Token: 0x0400C0A1 RID: 49313
		private int opl_p1;

		// Token: 0x0400C0A2 RID: 49314
		private int opl_p2;

		// Token: 0x0400C0A3 RID: 49315
		private int opl_p3;
	}
}
