using System;

namespace behaviac
{
	// Token: 0x02001DE3 RID: 7651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node23 : Condition
	{
		// Token: 0x0601257C RID: 75132 RVA: 0x0055B36A File Offset: 0x0055976A
		public Condition_bt_APC_APC_Nianqishi_Action_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601257D RID: 75133 RVA: 0x0055B39C File Offset: 0x0055979C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF6C RID: 49004
		private int opl_p0;

		// Token: 0x0400BF6D RID: 49005
		private int opl_p1;

		// Token: 0x0400BF6E RID: 49006
		private int opl_p2;

		// Token: 0x0400BF6F RID: 49007
		private int opl_p3;
	}
}
