using System;

namespace behaviac
{
	// Token: 0x02001EBA RID: 7866
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node3 : Condition
	{
		// Token: 0x0601271C RID: 75548 RVA: 0x00564F66 File Offset: 0x00563366
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node3()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601271D RID: 75549 RVA: 0x00564F9C File Offset: 0x0056339C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C109 RID: 49417
		private int opl_p0;

		// Token: 0x0400C10A RID: 49418
		private int opl_p1;

		// Token: 0x0400C10B RID: 49419
		private int opl_p2;

		// Token: 0x0400C10C RID: 49420
		private int opl_p3;
	}
}
