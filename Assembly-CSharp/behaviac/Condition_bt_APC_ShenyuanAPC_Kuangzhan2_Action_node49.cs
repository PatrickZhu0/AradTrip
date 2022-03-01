using System;

namespace behaviac
{
	// Token: 0x02001E5E RID: 7774
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node49 : Condition
	{
		// Token: 0x06012668 RID: 75368 RVA: 0x0056112C File Offset: 0x0055F52C
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node49()
		{
			this.opl_p0 = 1503;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012669 RID: 75369 RVA: 0x00561160 File Offset: 0x0055F560
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C04E RID: 49230
		private int opl_p0;

		// Token: 0x0400C04F RID: 49231
		private int opl_p1;

		// Token: 0x0400C050 RID: 49232
		private int opl_p2;

		// Token: 0x0400C051 RID: 49233
		private int opl_p3;
	}
}
