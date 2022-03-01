using System;

namespace behaviac
{
	// Token: 0x02002681 RID: 9857
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node2 : Condition
	{
		// Token: 0x06013646 RID: 79430 RVA: 0x005C648C File Offset: 0x005C488C
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node2()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06013647 RID: 79431 RVA: 0x005C64C0 File Offset: 0x005C48C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D098 RID: 53400
		private int opl_p0;

		// Token: 0x0400D099 RID: 53401
		private int opl_p1;

		// Token: 0x0400D09A RID: 53402
		private int opl_p2;

		// Token: 0x0400D09B RID: 53403
		private int opl_p3;
	}
}
