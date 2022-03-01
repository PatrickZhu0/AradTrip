using System;

namespace behaviac
{
	// Token: 0x0200278B RID: 10123
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node7 : Condition
	{
		// Token: 0x06013856 RID: 79958 RVA: 0x005D21F6 File Offset: 0x005D05F6
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node7()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013857 RID: 79959 RVA: 0x005D222C File Offset: 0x005D062C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2B5 RID: 53941
		private int opl_p0;

		// Token: 0x0400D2B6 RID: 53942
		private int opl_p1;

		// Token: 0x0400D2B7 RID: 53943
		private int opl_p2;

		// Token: 0x0400D2B8 RID: 53944
		private int opl_p3;
	}
}
