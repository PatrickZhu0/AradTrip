using System;

namespace behaviac
{
	// Token: 0x02001E44 RID: 7748
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node7 : Condition
	{
		// Token: 0x06012635 RID: 75317 RVA: 0x0055FA82 File Offset: 0x0055DE82
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node7()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06012636 RID: 75318 RVA: 0x0055FAB8 File Offset: 0x0055DEB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C01B RID: 49179
		private int opl_p0;

		// Token: 0x0400C01C RID: 49180
		private int opl_p1;

		// Token: 0x0400C01D RID: 49181
		private int opl_p2;

		// Token: 0x0400C01E RID: 49182
		private int opl_p3;
	}
}
