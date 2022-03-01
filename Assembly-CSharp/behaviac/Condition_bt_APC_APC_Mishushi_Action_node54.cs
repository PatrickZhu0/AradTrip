using System;

namespace behaviac
{
	// Token: 0x02001DBF RID: 7615
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node54 : Condition
	{
		// Token: 0x06012536 RID: 75062 RVA: 0x00559D9A File Offset: 0x0055819A
		public Condition_bt_APC_APC_Mishushi_Action_node54()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012537 RID: 75063 RVA: 0x00559DD0 File Offset: 0x005581D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF2A RID: 48938
		private int opl_p0;

		// Token: 0x0400BF2B RID: 48939
		private int opl_p1;

		// Token: 0x0400BF2C RID: 48940
		private int opl_p2;

		// Token: 0x0400BF2D RID: 48941
		private int opl_p3;
	}
}
