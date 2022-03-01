using System;

namespace behaviac
{
	// Token: 0x02001EA3 RID: 7843
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node14 : Condition
	{
		// Token: 0x060126EF RID: 75503 RVA: 0x00564385 File Offset: 0x00562785
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node14()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060126F0 RID: 75504 RVA: 0x005643BC File Offset: 0x005627BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0DB RID: 49371
		private int opl_p0;

		// Token: 0x0400C0DC RID: 49372
		private int opl_p1;

		// Token: 0x0400C0DD RID: 49373
		private int opl_p2;

		// Token: 0x0400C0DE RID: 49374
		private int opl_p3;
	}
}
