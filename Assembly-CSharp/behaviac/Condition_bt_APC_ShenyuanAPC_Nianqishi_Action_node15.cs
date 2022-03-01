using System;

namespace behaviac
{
	// Token: 0x02001EB2 RID: 7858
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node15 : Condition
	{
		// Token: 0x0601270C RID: 75532 RVA: 0x00564BFE File Offset: 0x00562FFE
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x0601270D RID: 75533 RVA: 0x00564C34 File Offset: 0x00563034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0F9 RID: 49401
		private int opl_p0;

		// Token: 0x0400C0FA RID: 49402
		private int opl_p1;

		// Token: 0x0400C0FB RID: 49403
		private int opl_p2;

		// Token: 0x0400C0FC RID: 49404
		private int opl_p3;
	}
}
