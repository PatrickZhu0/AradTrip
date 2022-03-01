using System;

namespace behaviac
{
	// Token: 0x02001E98 RID: 7832
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node54 : Condition
	{
		// Token: 0x060126DA RID: 75482 RVA: 0x00563962 File Offset: 0x00561D62
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node54()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060126DB RID: 75483 RVA: 0x00563998 File Offset: 0x00561D98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0C7 RID: 49351
		private int opl_p0;

		// Token: 0x0400C0C8 RID: 49352
		private int opl_p1;

		// Token: 0x0400C0C9 RID: 49353
		private int opl_p2;

		// Token: 0x0400C0CA RID: 49354
		private int opl_p3;
	}
}
