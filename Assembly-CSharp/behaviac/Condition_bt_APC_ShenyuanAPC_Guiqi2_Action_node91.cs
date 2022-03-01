using System;

namespace behaviac
{
	// Token: 0x02001E48 RID: 7752
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node91 : Condition
	{
		// Token: 0x0601263D RID: 75325 RVA: 0x0055FC36 File Offset: 0x0055E036
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node91()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x0601263E RID: 75326 RVA: 0x0055FC6C File Offset: 0x0055E06C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C023 RID: 49187
		private int opl_p0;

		// Token: 0x0400C024 RID: 49188
		private int opl_p1;

		// Token: 0x0400C025 RID: 49189
		private int opl_p2;

		// Token: 0x0400C026 RID: 49190
		private int opl_p3;
	}
}
