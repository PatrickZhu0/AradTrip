using System;

namespace behaviac
{
	// Token: 0x0200279F RID: 10143
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node22 : Condition
	{
		// Token: 0x0601387E RID: 79998 RVA: 0x005D2A7A File Offset: 0x005D0E7A
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node22()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601387F RID: 79999 RVA: 0x005D2AB0 File Offset: 0x005D0EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2DD RID: 53981
		private int opl_p0;

		// Token: 0x0400D2DE RID: 53982
		private int opl_p1;

		// Token: 0x0400D2DF RID: 53983
		private int opl_p2;

		// Token: 0x0400D2E0 RID: 53984
		private int opl_p3;
	}
}
