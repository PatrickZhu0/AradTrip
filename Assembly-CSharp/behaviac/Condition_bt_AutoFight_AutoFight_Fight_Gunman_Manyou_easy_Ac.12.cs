using System;

namespace behaviac
{
	// Token: 0x02002117 RID: 8471
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node28 : Condition
	{
		// Token: 0x06012BC1 RID: 76737 RVA: 0x005812F7 File Offset: 0x0057F6F7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012BC2 RID: 76738 RVA: 0x0058132C File Offset: 0x0057F72C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5B3 RID: 50611
		private int opl_p0;

		// Token: 0x0400C5B4 RID: 50612
		private int opl_p1;

		// Token: 0x0400C5B5 RID: 50613
		private int opl_p2;

		// Token: 0x0400C5B6 RID: 50614
		private int opl_p3;
	}
}
